using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cine.Forms
{
    public partial class Cines : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;        //CONSTANTES
        const int MODIFICAR = 2;

        Conexion BD = new Conexion();
        DataTable DTProvincias = new DataTable();
        DataTable DTCiudades = new DataTable();
        DataTable DTCines = new DataTable();
        SqlDataAdapter adaptador;
        SqlCommand comando;

        int Operacion = 0; //INDICADOR DE OPERACION ACTUAL

        public Cines()
        {
            InitializeComponent();

            if (BD.abrir()) //SI SE PUDO CONECTAR CON LA BASE DE DATOS...
            {
                dgvCines.DataSource = DTCines; //INDICARLE AL DGVCINES QUE SU FUENTE DE DATOS SERA EL DATATABLE DE CINES
                boxProvincia.DataSource = DTProvincias; //INDICARLE AL BOX DE PROVINCIAS QUE SU FUENTE DE DATOS SERA EL DATATABLE DE PROVINCIAS
                boxCiudad.DataSource = DTCiudades; //INDICARLE AL BOX DE CIUDADES QUE SU FUENTE DE DATOS SERA EL DATATABLE DE CIUDADES

                ActualizarDataGrid(); //ACTUALIZA EL DATAGRID DE CINES
                ActualizarBoxs(); //ACTUALIZA LOS BOXS DE PROVINCIA Y CIUDAD
            }

            SetearConfigDataGrid(); //CONFIGURACION RELACIONADA CON LA APARENCIA DEL DATAGRIDVIEW
        }

        private void ActualizarDataGrid()
        {
            adaptador = new SqlDataAdapter("Select CodCine_Cine, Nombre_Cine, Descripcion_Prov, Descripcion_Ciud, Direccion_Cine, Descripcion_Cine, CodProvincia_Cine, CodCiudad_Cine, Estado_Cine from Cines inner join Provincias on CodProvincia_Prov = CodProvincia_Cine inner join Ciudades on CodProvincia_Cine = CodProvincia_Ciud AND CodCiudad_Cine = CodCiudad_Ciud", BD.getSqlConnection()); //CONSULTA PARA TRAER TODOS LOS CINES
            DTCines.Clear(); //LIMPIAR EL DATATABLE DE CINES DE VIEJOS REGISTROS
            adaptador.Fill(DTCines); //LLENAR EL DATATABLE DE CINES CON NUEVOS REGISTROS
        }

        private void ActualizarBoxs()
        {
            adaptador = new SqlDataAdapter("Select * from Provincias", BD.getSqlConnection()); //CONSULTA PARA TRAER TODAS LAS PROVINCIAS
            DTProvincias.Clear(); //LIMPIAR EL DATATABLE DE PROVINCIAS DE VIEJOS REGISTROS
            adaptador.Fill(DTProvincias); //LENAR EL DATATABLE DE PROVINCIAS CON NUEVOS REGISTROS
            DTProvincias.DefaultView.Sort = "Descripcion_Prov"; //ORDENAR EL DATATABLE ALFABETICAMENTE

            adaptador = new SqlDataAdapter("Select * from Ciudades where CodProvincia_Ciud = 1", BD.getSqlConnection()); //TRAER TODAS LAS CIUDADES, INICIALMENTE DE LA PRIMERA PROVINCIA
            DTCiudades.Clear(); //LIMPIAR EL DATATABLE DE CIUDADES DE VIEJOS REGISTROS
            adaptador.Fill(DTCiudades); //LLENAR EL DATATABLE DE CIUDADES CON NUEVOS
            DTCiudades.DefaultView.Sort = "Descripcion_Ciud"; //ORDENAR EL DATATABLE ALFABETICAMENTE

            boxProvincia.DisplayMember = "Descripcion_Prov"; //LOS DATOS QUE SE VERAN EN EL BOX DE PROVINCIAS SERAN LA DESCRIPCION DE LAS PROVINCIAS
            boxProvincia.ValueMember = "CodProvincia_Prov"; //Y SE ASIGANARA A CADA ITEM EL CODIGO DE PROVINCIA PERTENECIENTE
            
            boxCiudad.DisplayMember = "Descripcion_Ciud"; //LOS DATOS QUE SE VERAN EN EL BOX DE CIUDADES SERAN LA DESCRIPCION DE LAS CIUDADES
            boxCiudad.ValueMember = "CodCiudad_Ciud"; //Y SE ASIGNARA A CADA ITEM EL CODIGO DE CIUDAD PERTENECIENTE
        }

        private void SetearConfigDataGrid()
        {
            dgvCines.Columns[0].HeaderText = "Codigo";
            dgvCines.Columns[1].HeaderText = "Nombre";
            dgvCines.Columns[2].HeaderText = "Provincia";
            dgvCines.Columns[3].HeaderText = "Ciudad";
            dgvCines.Columns[4].HeaderText = "Direccion";
            dgvCines.Columns[5].HeaderText = "Descripcion";
            dgvCines.Columns[8].HeaderText = "Activo";

            dgvCines.Columns[0].Visible = false;
            dgvCines.Columns[6].Visible = false;
            dgvCines.Columns[7].Visible = false;
            dgvCines.ReadOnly = true;
            dgvCines.AllowUserToAddRows = false;
            dgvCines.RowHeadersVisible = false;
            dgvCines.AllowUserToResizeColumns = false;
            dgvCines.AllowUserToResizeRows = false;
            dgvCines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCines.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCines.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCines.Sort(dgvCines.Columns[1], ListSortDirection.Ascending);
            dgvCines.Height = 388;
        }

        private void AbrirPanel()
        {
            btnNuevo.Visible = false; //OCULTAR EL BOTON DE "NUEVO"
            btnModificar.Visible = false; //OCULTAR EL BOTON DE MODIFICAR
            dgvCines.Height = 241;
            panel1.Visible = true; //HACER VISIBLE EL PANEL
        }

        private void CerrarPanel()
        {
            Operacion = NULL; //INDICAR QUE NO HAY OPERACION EN CURSO
            panel1.Visible = false; //OCULTAR PANEL
            dgvCines.Height = 388; //VOLVER A AGRANDAR EL DATAGRIDVIEW
            btnNuevo.Visible = true; //VOLVER A MOSTRAR EL BOTON DE "NUEVO"
            btnModificar.Visible = true; //VOLVER A MOSTRAR EL BOTON DE MODIFICAR
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Operacion = NUEVO; //INDICAR QUE LA OPERACION ACTUAL ES AGREGAR UN NUEVO REGISTRO

            //LIMPIAR TODOS LOS TEXTBOXS DE VIEJOS REGISTROS 
            txtCodigo.Clear();
            txtNombre.Clear();
            boxProvincia.SelectedIndex = 0;
            boxCiudad.SelectedIndex = 0;
            txtDireccion.Clear();
            txtDescripcion.Clear();
            checkActivo.Checked = true;

            AbrirPanel(); //ABRIR EL PANEL
            txtNombre.Focus(); //DARLE EL FOCO AL TEXTBOX DE NOMBRE
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Operacion = MODIFICAR; //INDICAR QUE LA OPERACION ACTUAL ES MODIFICAR

            //LLENAR TODOS LOS TEXTBOX CON LOS DATOS DEL CINE SELECCIONADO SOLO AL MOMENTO DE CLICKEAR EL BOTON DE MODIFICAR
            txtCodigo.Text = dgvCines.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvCines.CurrentRow.Cells[1].Value.ToString();
            boxProvincia.SelectedValue = dgvCines.CurrentRow.Cells[6].Value;
            boxCiudad.SelectedValue = dgvCines.CurrentRow.Cells[7].Value;
            txtDireccion.Text = dgvCines.CurrentRow.Cells[4].Value.ToString();
            txtDescripcion.Text = dgvCines.CurrentRow.Cells[5].Value.ToString();
            checkActivo.Checked = bool.Parse(dgvCines.CurrentRow.Cells[8].Value.ToString());

            AbrirPanel(); //ABRIR EL PANEL
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Operacion == NUEVO) //SI SE DESEA AGREGAR UN NUEVO CINE...
            {
                if(txtNombre.TextLength != 0) //CONTINUAR SOLO SI EL TEXTBOX NOMBRE CONTIENE DATOS
                {
                    if(txtDireccion.TextLength != 0) //CONTINUAR SOLO SI EL TEXTBOX DIRECCION CONTIENE DATOS
                    {
                        if (boxCiudad.SelectedItem != null) //CONTINUAR SOLO SI SE SELECCIONO UNA CIUDAD. YA QUE ES POSIBLE QUE LA PROVINCIA SELECCIONADA NO CONTENGA CIUDADES
                        {
                            int NuevoCodigo = Int32.Parse(DTCines.Compute("MAX(CodCine_Cine)", "").ToString()) + 1; //OBTENER ULTIMO CODIGO DE CINE REGISTRADO Y SUMARLE 1

                            comando = new SqlCommand("INSERT INTO Cines(CodCine_Cine, Nombre_Cine, CodProvincia_Cine, CodCiudad_Cine, Direccion_Cine, Descripcion_Cine, Estado_Cine) VALUES(" + NuevoCodigo + ", '" + txtNombre.Text + "', " + boxProvincia.SelectedValue + ", " + boxCiudad.SelectedValue + ", '" + txtDireccion.Text + "', '" + txtDescripcion.Text + "', '" + checkActivo.Checked + "')", BD.getSqlConnection()); //INSERTAR EN LA BASE DE DATOS EL NUEVO CINE
                            comando.ExecuteNonQuery(); //EJECUTAR CONSULTA
                            ActualizarDataGrid(); //ACTUALIZAR EL DATATABLE DE CINES

                            seleccionarFila(NuevoCodigo); //SELECCIONAR EL NUEVO REGISTRO

                            txtCodigo.Clear();
                            txtNombre.Clear();
                            txtNombre.Focus();
                            boxProvincia.SelectedIndex = 0;     //LIMPIAR LOS CONTENEDORES PARA INGRESAR OTRO NUEVO REGISTRO
                            boxCiudad.SelectedIndex = 0;
                            txtDireccion.Clear();
                            txtDescripcion.Clear();
                            checkActivo.Checked = true;
                        }
                        else //SI EL BOX DE CIUDAD ESTA VACIO...
                        {
                            MessageBox.Show("La provincia que ha seleccionado, actualmente no posee ciudades.\nAdemas de la provincia, es necesaria una ciudad.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else //SI EL TEXTBOX DIRECCION ESTA VACIO...
                    {
                        MessageBox.Show("La direccion no puede quedar vacia.\nPor favor ingrese una descripcion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDireccion.Focus();
                    }
                }
                else //SI EL TEXTBOX NOMBRE ESTA VACIO...
                {
                    MessageBox.Show("El nombre no puede quedar vacio.\nPor favor ingrese una descripcion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                } 
            }

            if(Operacion == MODIFICAR) //SI SE DESEA MODIFICAR UN CINE
            {
                if(txtNombre.TextLength != 0) //CONTINUAR SOLO SI EL TEXTBOX NOMBRE CONTIENE DATOS
                {
                    if(txtDireccion.TextLength != 0) //CONTINUAR SOLO SI EL TEXTBOX DIRECCION CONTIENE DATOS
                    {
                        if(boxCiudad.SelectedItem != null) //CONTINUAR SOLO SI SE SELECCIONO UNA CIUDAD. YA QUE ES POSIBLE QUE LA PROVINCIA SELECCIONADA NO CONTENGA CIUDADES
                        {
                            if (dgvCines.CurrentRow.Cells[8].Value.ToString() == "True" && checkActivo.Checked == false) //SI SE QUIERE DESHABILITAR UN CINE
                            {
                                //MOSTRAR MENSAJE
                                DialogResult result = MessageBox.Show("Al deshabilitar el cine, tambien se deshabilitaran todas sus salas y funciones asociadas a este.\nPara habilitarlas debera hacerlo manulamente.\n¿Desea continuar?", "Atencion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes) //SI SE SELECCIONO "SI"
                                {
                                    actualizarCine(); //ACTUALIZAR EL REGISTRO
                                    deshabilitarSalas(txtCodigo.Text); //DESHABILITA LAS SALAS ASOCIADAS A DICHO CINE
                                    deshabilitarFunciones(txtCodigo.Text); //DESHABILITA LAS FUNCIONES ASOCIADAS A DICHO CINE
                                }
                            }
                            else //SI LA ACTUALIZACION NO TIENE QUE VER CON DESHABILITAR EL CINE
                            {
                                actualizarCine(); //SIMPLEMENTE ACTUALIZAR REGISTRO
                            }
                        }
                        else //SI EL BOX DE CIUDAD ESTA VACIO...
                        {
                            MessageBox.Show("La provincia que ha seleccionado, actualmente no posee ciudades.\nAdemas de la provincia, es necesaria una ciudad.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else //SI EL TEXTBOX DIRECCION ESTA VACIO...
                    {
                        MessageBox.Show("La direccion no puede quedar vacia.\nPor favor ingrese una descripcion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDireccion.Focus();
                    }
                }
                else //SI EL TEXTBOX NOMBRE ESTA VACIO...
                {
                    MessageBox.Show("El nombre no puede quedar vacio.\nPor favor ingrese una descripcion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Operacion == MODIFICAR) //SI SE VA A MODIFICAR, LLENAR CADA TEXTBOX CON LOS DATOS DEL CINE SELECCIONADO APARTIR DEL DATAGRIDVIEW
            {
                try
                {
                    txtCodigo.Text = dgvCines.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dgvCines.CurrentRow.Cells[1].Value.ToString();
                    boxProvincia.SelectedValue = dgvCines.CurrentRow.Cells[6].Value;
                    boxCiudad.SelectedValue = dgvCines.CurrentRow.Cells[7].Value;
                    txtDireccion.Text = dgvCines.CurrentRow.Cells[4].Value.ToString();
                    txtDescripcion.Text = dgvCines.CurrentRow.Cells[5].Value.ToString();
                    checkActivo.Checked = bool.Parse(dgvCines.CurrentRow.Cells[8].Value.ToString());
                }
                catch(Exception ex) { }
            }
        }

        private void boxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            adaptador = new SqlDataAdapter("Select * from Ciudades where CodProvincia_Ciud = " + boxProvincia.SelectedValue, BD.getSqlConnection()); //TRAER LAS CIUDADES DE LA PROVINCIA SELECCIONADA
            DTCiudades.Clear(); //LIMPIAR EL DATATABLE DE CIUDADES DE VIEJOS REGISTROS
            adaptador.Fill(DTCiudades); //LLENAR EL DATATABLE DE CIUDADES CON NUEVOS REGISTROS

            boxCiudad.DisplayMember = "Descripcion_Ciud"; //LOS DATOS QUE SE VERAN EN EL BOX DE CIUDADES SERAN LA DESCRIPCION DE LAS CIUDADES
            boxCiudad.ValueMember = "CodCiudad_Ciud"; //Y SE ASIGNARA A CADA ITEM EL CODIGO DE CIUDAD PERTENECIENTE
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel(); //CIERRA EL PANEL
        }

        private void seleccionarFila(int codigo)
        {
            for(int i=0; i<dgvCines.RowCount; i++) //RECORRER TODO EL DATAGRID
            {
                if(dgvCines.Rows[i].Cells[0].Value.ToString() == codigo.ToString()) //SI LA FILA COINCIDE CON EL CODIGO
                {
                    dgvCines.CurrentCell = dgvCines.Rows[i].Cells[1]; //SELECCIONAR EL REGISTRO
                    dgvCines.Rows[i].Selected = true; //SELECCIONAR EL REGISTRO  
                }
            }
        }

        private void actualizarCine()
        {
            int CodCine = Int32.Parse(txtCodigo.Text);

            comando = new SqlCommand("UPDATE Cines SET Nombre_Cine = '" + txtNombre.Text + "', CodProvincia_Cine = " + boxProvincia.SelectedValue + ", CodCiudad_Cine = " + boxCiudad.SelectedValue + ", Direccion_Cine = '" + txtDireccion.Text + "', Descripcion_Cine = '" + txtDescripcion.Text + "', Estado_Cine = '" + checkActivo.Checked + "' WHERE CodCine_Cine = " + CodCine, BD.getSqlConnection()); //GENERAR CONSULTA
            comando.ExecuteNonQuery(); //EJECUTAR CONSULTA
            ActualizarDataGrid(); //ACTUALIZAR DATAGRIDVIEW

            seleccionarFila(CodCine); //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO

            txtCodigo.Text = dgvCines.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvCines.CurrentRow.Cells[1].Value.ToString();
            boxProvincia.SelectedValue = dgvCines.CurrentRow.Cells[6].Value;        //LLENAR CADA TEXTBOX CON LOS DATOS DEL CINE SELECCIONADO
            boxCiudad.SelectedValue = dgvCines.CurrentRow.Cells[7].Value;
            txtDireccion.Text = dgvCines.CurrentRow.Cells[4].Value.ToString();
            txtDescripcion.Text = dgvCines.CurrentRow.Cells[5].Value.ToString();
            checkActivo.Checked = bool.Parse(dgvCines.CurrentRow.Cells[8].Value.ToString());
        }

        private void deshabilitarSalas(String CodCine)
        {
            comando = new SqlCommand("UPDATE SalasXCine SET Estado_SXC = 'False' WHERE CodCine_SXC = " + CodCine, BD.getSqlConnection());
            comando.ExecuteNonQuery();
        }

        private void deshabilitarFunciones(String CodCine)
        {
            comando = new SqlCommand("UPDATE Funciones SET Estado_Func = 'False' WHERE CodCine_Func = " + CodCine, BD.getSqlConnection());
            comando.ExecuteNonQuery();
        }
    }
}
