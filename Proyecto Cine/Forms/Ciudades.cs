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
    public partial class Ciudades : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;
        const int MODIFICAR = 2;    //CONSTANTES
        const int PROVINCIAS = 3;
        const int CIUDADES = 4;

        Conexion BD = new Conexion();
        DataTable DTProvincias = new DataTable();
        DataTable DTCiudades = new DataTable();
        SqlDataAdapter adaptador;
        SqlCommand comando;

        int Operacion = 0; //INDICADOR DE OPERACION ACTUAL
        int Entidad = 0; //INDICADOR DE ENTIDAD QUE ESTA OPERANDO

        public Ciudades()
        {
            InitializeComponent();

            dgvProvincias.DataSource = DTProvincias; //INDICARLE AL DATAGRIDVIEW DE PROVINCIAS QUE SU FUENTE DE DATOS VA A SER EL DATATABLE DE PROVINCIAS
            dgvCiudades.DataSource = DTCiudades; //INDICARLE AL DATAGRIDVIEW DE CIUDADES QUE SU FUENTE DE DATOS VA A SER EL DATATABLE DE CIUDADES

            if (BD.Abrir()) //SI SE PUEDE ABRIR LA CONEXION CON LA BASE DE DATOS
            {
                ActualizarDgvProvincias(); //ACTUALIZAR DATAGRID DE PROVINCIAS
                ActualizarDgvCiudades(); //ACTUALIZAR DATAGRID DE CIUDADES
            } 

            ConfigurarGrids(); //CONFIGURACION RELACIONADA CON LA APARIENCIA DE LOS DATAGRIDVIEW
        }

        private void ConfigurarGrids()
        {
            dgvProvincias.Columns[0].HeaderText = "Codigo";
            dgvProvincias.Columns[1].HeaderText = "Provincia";

            dgvProvincias.Size = new Size(450, dgvProvincias.Size.Height);
            dgvProvincias.Columns[0].Visible = false;
            dgvProvincias.ReadOnly = true;
            dgvProvincias.AllowUserToAddRows = false;
            dgvProvincias.RowHeadersVisible = false;
            dgvProvincias.AllowUserToResizeColumns = false;
            dgvProvincias.AllowUserToResizeRows = false;
            dgvProvincias.MultiSelect = false;
            dgvProvincias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProvincias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProvincias.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProvincias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProvincias.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProvincias.Sort(dgvProvincias.Columns[1], ListSortDirection.Ascending);

            dgvCiudades.Columns[0].HeaderText = "Codigo Provincia";
            dgvCiudades.Columns[1].HeaderText = "Codigo Ciudad";
            dgvCiudades.Columns[2].HeaderText = "Ciudad";

            dgvCiudades.Size = new Size(455, dgvCiudades.Size.Height);
            dgvCiudades.Location = new Point(480, dgvCiudades.Location.Y);
            dgvCiudades.Columns[0].Visible = false;
            dgvCiudades.Columns[1].Visible = false;
            dgvCiudades.ReadOnly = true;
            dgvCiudades.AllowUserToAddRows = false;
            dgvCiudades.RowHeadersVisible = false;
            dgvCiudades.AllowUserToResizeColumns = false;
            dgvCiudades.AllowUserToResizeRows = false;
            dgvCiudades.MultiSelect = false;
            dgvCiudades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCiudades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCiudades.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCiudades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCiudades.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCiudades.Sort(dgvCiudades.Columns[2], ListSortDirection.Ascending);
        }

        private void AbrirPanel()
        {
            dgvProvincias.Width = 300; //ACHICAR DATAGRID
            dgvCiudades.Width = 300; //ACHICAR DATAGRID
            dgvCiudades.Location = new Point(636, dgvCiudades.Location.Y); //REUBICAR DATAGRID
            panel1.Visible = true; //HACER VISIBLE EL PANEL
        }

        private void CerrarPanel()
        {
            panel1.Visible = false; //OCULTAR PANEL
            dgvProvincias.Width = 450; //AGRANDAR DATAGRID
            dgvCiudades.Width = 455; //AGRANDAR DATAGRID
            dgvCiudades.Location = new Point(480, dgvCiudades.Location.Y); //REUBICAR DATAGRID
            txtDescripcion.Clear(); //LIMPIAR CONTENEDOR
            label2.Text = ""; //LIMPIAR LABEL
            Operacion = NULL; //NO HAY OPERACION EN CURSO

            //AL CERRAR EL PANEL SE PREGUNTA QUE ENTIDAD ESTABA OPERANDO PARA VOLVERLE A DAR EL FOCO Y PODER NAVEGAR CON EL TECLADO
            if (Entidad == PROVINCIAS) dgvProvincias.Focus();
            if (Entidad == CIUDADES) dgvCiudades.Focus();

            Entidad = NULL; //NO HAY ENTIDAD OPERANDO
        }

        private void ActualizarDgvProvincias()
        {
            adaptador = new SqlDataAdapter("Select * from Provincias", BD.getSqlCn()); //CARGAR AL ADAPTADOR TODAS LAS PROVINCIAS
            DTProvincias.Clear(); //LIMPIAR EL DATATABLE DE PROVINCIAS DE VIEJOS REGISTROS
            adaptador.Fill(DTProvincias); //LLENAR EL DATATABLE DE PROVINCIAS CON LOS NUEVOS REGISTROS
        }

        private void ActualizarDgvCiudades()
        {
            adaptador = new SqlDataAdapter("Select * from Ciudades where CodProvincia_Ciud = " + dgvProvincias.CurrentRow.Cells[0].Value, BD.getSqlCn()); //CARGAR AL ADAPTADOR TODAS LAS CIUDADES DE LA PROVINCIA SELECCIONADA
            DTCiudades.Clear(); //LIMPIAR EL DATATABLE DE CIUDADES DE VIEJOS REGISTROS
            adaptador.Fill(DTCiudades); //LLENAR EL DATATABLE DE CIUDADES CON LOS NUEVOS REGISTROS
        }

        private void ActualizarGrids()
        {
            adaptador = new SqlDataAdapter("Select * from Provincias", BD.getSqlCn()); //CARGAR AL ADAPTADOR TODAS LAS PROVINCIAS
            DTProvincias.Clear(); //LIMPIAR EL DATATABLE DE PROVINCIAS DE VIEJOS REGISTROS
            adaptador.Fill(DTProvincias); //LLENAR EL DATATABLE DE PROVINCIAS CON LOS NUEVOS REGISTROS

            adaptador = new SqlDataAdapter("Select * from Ciudades where CodProvincia_Ciud = " + dgvProvincias.CurrentRow.Cells[0].Value, BD.getSqlCn()); //CARGAR AL ADAPTADOR TODAS LAS CIUDADES DE LA PROVINCIA SELECCIONADA
            DTCiudades.Clear(); //LIMPIAR EL DATATABLE DE CIUDADES DE VIEJOS REGISTROS
            adaptador.Fill(DTCiudades); //LLENAR EL DATATABLE DE CIUDADES CON LOS NUEVOS REGISTROS
        }

        private void dgvProvincias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarDgvCiudades(); //ACTUALIZAR DATAGRID CIUDADES DE LA PROVINCIA SELECCIONADA
            }
            catch (Exception x){}
        
            if(Entidad == PROVINCIAS && Operacion == MODIFICAR) //SI SE ESTA MODIFICANDO UNA PROVINCIA
            {
                try
                {
                    txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString(); //LLENAR TEXTBOX CON LA PROVINCIA SELECCIONADA
                    txtDescripcion.SelectAll(); //SELECCIONAR TODO EL TEXTO DEL TEXTBOX
                    txtDescripcion.Focus(); //DARLE EL FOCO AL TEXTBOX
                }
                catch (Exception x) { }
            }
            
            if(Entidad == CIUDADES && Operacion == MODIFICAR) //SI SE ESTA MODIFICANDO UNA CIUDAD
            {
                if(dgvCiudades.RowCount == 0) //Y NO HAY CIUDADES CARGADAS EN LA PROVNCIA
                {   
                    CerrarPanel(); //CERRAR EL PANEL
                }
            }
        }

        private void dgvCiudades_SelectionChanged(object sender, EventArgs e)
        {
            if(Entidad == CIUDADES && Operacion == MODIFICAR) //SI SE ESTA MODIFICANDO UNA CIUDAD
            {
                try
                {
                    txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString(); //LLENAR TEXTBOX CON LA CIUDAD SELECCIONADA
                    txtDescripcion.SelectAll(); //SELECCIONAR TODO EL TEXTO DEL TEXTBOX
                    txtDescripcion.Focus(); //DARLE EL FOCO AL TEXTBOX
                }
                catch (Exception x) { }
            
            }
        }

        private void btnNuevaProvincia_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
            {
                AbrirPanel(); //ABRIR EL PANEL
                label2.Text = "AGREGAR NUEVA PROVINCIA"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                label2.Location = new Point(45,label2.Location.Y); //REACOMODAR LABEL
                txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                Entidad = PROVINCIAS; //LA ENTIDAD QUE OPERA ES PROVINCIAS
                Operacion = NUEVO; //LA OPERACION EN CURSO ES AGREGAR UN NUEVO REGISTRO
            }
        }

        private void btnNuevaCiudad_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
            {
                AbrirPanel(); //ABRIR EL PANEL
                label2.Text = "AGREGAR NUEVA CIUDAD"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                label2.Location = new Point(60, label2.Location.Y); //REACOMODAR LABEL
                txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                Entidad = CIUDADES; //LA ENTIDAD QUE OPERA ES CIUDADES
                Operacion = NUEVO; //LA OPERACION EN CURSO ES AGREGAR UN NUEVO REGISTRO
            }
        }

        private void btnModificarProvincia_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
            {
                if(dgvProvincias.RowCount != 0) //SI HAY PROVINCIAS CARGADAS
                {
                    AbrirPanel(); //ABRIR EL PANEL
                    label2.Text = "MODIFICAR PROVINCIA"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                    label2.Location = new Point(60, label2.Location.Y); //UBICAR LABEL
                    txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString(); //CARGAR EN EL TEXTBOX LA PROVINCIA SELECCIONADA
                    txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    Entidad = PROVINCIAS; //LA ENTIDAD QUE OPERA ES PROVINCIAS
                    Operacion = MODIFICAR; //LA OPERACION EN CURSO ES MODIFICAR UN REGISTRO EXISTENTE
                }
            }
        }

        private void btnModificarCiudad_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
            {
                if(dgvCiudades.RowCount != 0) //SI HAY CIUDADES CARGADAS EN LA PROVINCIA SELECCIONADA
                {
                    AbrirPanel(); //ABRIR EL PANEL
                    label2.Text = "MODIFICAR CIUDAD"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                    label2.Location = new Point(75, label2.Location.Y); //REACOMODAR LABEL
                    txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString(); //CARGAR EN EL TEXTBOX LA CIUDAD SELECCIONADA
                    txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    Entidad = CIUDADES; //LA ENTIDAD QUE OPERA ES CIUDADES
                    Operacion = MODIFICAR; //LA OPERACION EN CURSO ES MODIFICAR UN REGISTRO EXISTENTE
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel(); //CERRAR EL PANEL
        }

        private void Guardar()
        {
            if (txtDescripcion.TextLength != 0) //SI EL TEXTBOX NO ESTA EN BLANCO
            {
                if (Operacion == NUEVO) //SI SE VA A AGREGAR UN NUEVO REGISTRO
                {
                    int NuevoCodigo = 0; //VARIABLE QUE GUARDA EL CODIGO PARA EL NUEVO REGISTRO

                    if (Entidad == PROVINCIAS) //SI LA ENTIDAD QUE OPERA ES PROVINCIAS
                    {
                        NuevoCodigo = Int32.Parse(DTProvincias.Compute("MAX(CodProvincia_Prov)", "").ToString()) + 1; //OBTENER ULTIMO CODIGO DE PROVINCIA REGISTRADO Y SUMARLE 1

                        comando = new SqlCommand("INSERT INTO Provincias (CodProvincia_Prov, Descripcion_Prov) VALUES (" + NuevoCodigo + ", '" + txtDescripcion.Text + "')", BD.getSqlCn()); //INSERTAR EN PROVINCIAS EL NUEVO REGISTRO
                        comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                        ActualizarDgvProvincias(); //ACTUALIZAR DATAGRID PROVINCIAS
                        ActualizarDgvCiudades(); //ACTUALIZAR DATAGRID CIUDADES

                        seleccionarFilaProvincias(NuevoCodigo); //SELECCIONAR EL NUEVO REGISTRO

                        ActualizarDgvCiudades(); //ACTUALIZAR EL DATAGRID CIUDADES
                        txtDescripcion.Clear(); //LIMPIAR EL TEXTBOX
                        txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    }

                    if (Entidad == CIUDADES) //SI LA ENTIDAD QUE OPERA ES CIUDADES
                    {
                        if (dgvCiudades.RowCount != 0) //SI LA PROVINCIA TIENE CIUDADES CARGADAS
                        {
                            NuevoCodigo = Int32.Parse(DTCiudades.Compute("MAX(CodCiudad_Ciud)", "CodProvincia_Ciud = " + dgvProvincias.CurrentRow.Cells[0].Value).ToString()) + 1; //TOMAR EL ULTIMO CODIGO DE CIUDAD Y SUMARLE 1
                        }
                        else
                        {
                            NuevoCodigo = 1; //SI LA PROVINCIA NO TIENE CIUDADES CARGADAS, EMPEZAR POR EL CODIGO DE CIUDAD 1
                        }

                        comando = new SqlCommand("INSERT INTO Ciudades (CodProvincia_Ciud, CodCiudad_Ciud, Descripcion_Ciud) VALUES (" + dgvProvincias.CurrentRow.Cells[0].Value + ", " + NuevoCodigo + ", '" + txtDescripcion.Text + "')", BD.getSqlCn()); //INSERTAR EN CIUDADES EL NUEVO REGISTRO
                        comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                        ActualizarDgvCiudades(); //ACTUALIZAR DATAGRID CIUDADES

                        seleccionarFilaCiudades(NuevoCodigo); //SELECCIONAR EL NUEVO REGISTRO

                        txtDescripcion.Clear(); //LIMPIAR EL TEXTBOX
                        txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    }
                }

                if (Operacion == MODIFICAR) //SI SE VA A MODIFICAR
                {
                    if (Entidad == PROVINCIAS) //SI LA ENTIDAD QUE OPERA ES PROVINCIAS
                    {
                        int ProvSelectedIndex = dgvProvincias.CurrentRow.Index; //GUARDAR EL INDEX DEL REGISTRO SELECCIONADO EN PROVINCIAS
                        int CodProvincia = Int32.Parse(dgvProvincias.CurrentRow.Cells[0].Value.ToString());

                        comando = new SqlCommand("UPDATE Provincias SET Descripcion_Prov = '" + txtDescripcion.Text + "' WHERE CodProvincia_Prov = " + CodProvincia, BD.getSqlCn()); //CONSULTA PARA ACTUALIZAR EL NOMBRE DE LA PROVINCIA
                        comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                        ActualizarDgvProvincias(); //ACTUALIZAR DATAGRID PROVINCIAS

                        seleccionarFilaProvincias(CodProvincia);

                        ActualizarDgvCiudades(); //ACTUALIZAR DATAGRID CIUDADES

                        txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString(); //LLENAR TEXTBOX CON LA PROVINCIA SELECCIONADA
                        txtDescripcion.SelectAll(); //SELECCIONAR TODO EL TEXTO DEL TEXTBOX
                        txtDescripcion.Focus(); //DARLE EL FOCO AL TEXTBOX
                    }

                    if (Entidad == CIUDADES) //SI LA ENTIDAD QUE OPERA ES CIUDADES
                    {
                        string CodProvincia = dgvProvincias.CurrentRow.Cells[0].Value.ToString(); //GUARDAR EL CODIGO DE LA PROVINCIA SELECCIONADA
                        string CodCiudad = dgvCiudades.CurrentRow.Cells[1].Value.ToString(); //GUARDAR EL CODIGO DE LA CIUDAD SELECCIONADA
                        int CiudSelectedIndex = dgvCiudades.CurrentRow.Index; //GUARDAR EL INDEX DEL REGISTRO SELECCIONADO EN CIUDADES

                        comando = new SqlCommand("UPDATE Ciudades SET Descripcion_Ciud = '" + txtDescripcion.Text + "' WHERE CodProvincia_Ciud = " + CodProvincia + " AND CodCiudad_Ciud = " + CodCiudad, BD.getSqlCn()); //ACTUALIZAR LA CIUDAD
                        comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                        ActualizarDgvCiudades(); //ACTUALIZAR DATAGRID CIUDADES

                        seleccionarFilaCiudades(Int32.Parse(CodCiudad)); //VOLVER A SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO

                        txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString(); //LLENAR TEXTBOX CON LA CIUDAD SELECCIONADA
                        txtDescripcion.SelectAll(); //SELECCIONAR TODO EL TEXTO DEL TEXTBOX
                        txtDescripcion.Focus(); //DARLE EL FOCO AL TEXTBOX
                    }
                }
            }
            else //SI EL TEXTBOX ESTA VACIO
            {
                MessageBox.Show("El nombre no puede quedar vacio.\nPor favor ingrese una descripcion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(); //GUARDAR LA OPERACION
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) //SI SE APRIETA ENTER CUANDO SE CREA O MODIFICA
            {
                Guardar(); //GUARDAR LA OPERACION
            }

            if (Convert.ToInt32(e.KeyChar) == 27) //SI SE APRIETA ESCAPE CUANDO SE CREA O MODIFICA
            {
                CerrarPanel(); //CERRAR EL PANEL
            }
        }

        private void dgvProvincias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N) //SI LA TECLA APRETADA ES N
            {
                if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
                {
                    AbrirPanel(); //ABRIR EL PANEL
                    label2.Text = "AGREGAR NUEVA PROVINCIA"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                    label2.Location = new Point(25, label2.Location.Y); //REACOMODAR LABEL
                    txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    Entidad = PROVINCIAS; //LA ENTIDAD QUE OPERA ES PROVINCIAS
                    Operacion = NUEVO; //LA OPERACION EN CURSO ES AGREGAR UN NUEVO REGISTRO
                }
            }

            if (e.KeyCode == Keys.M) //SI LA TECLA APRETADA ES M
            {
                if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
                {
                    if (dgvProvincias.RowCount != 0) //SI HAY PROVINCIAS CARGADAS
                    {
                        AbrirPanel(); //ABRIR EL PANEL
                        label2.Text = "MODIFICAR PROVINCIA"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                        label2.Location = new Point(50, label2.Location.Y); //UBICAR LABEL
                        txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString(); //CARGAR EN EL TEXTBOX LA PROVINCIA SELECCIONADA
                        txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                        Entidad = PROVINCIAS; //LA ENTIDAD QUE OPERA ES PROVINCIAS
                        Operacion = MODIFICAR; //LA OPERACION EN CURSO ES MODIFICAR UN REGISTRO EXISTENTE
                    }
                }
            }

            if (e.KeyCode == Keys.Right) //SI LA TECLA ES LA FLECHA DERECHA
            {
                if (dgvCiudades.RowCount != 0) dgvCiudades.Focus(); //SI EL DATAGRID DE CIUDADES NO ESTA VACIO, DARLE EL FOCO
            }
        }

        private void dgvCiudades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N) //SI LA TECLA APRETADA ES N o n
            {
                if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
                {
                    AbrirPanel(); //ABRIR EL PANEL
                    label2.Text = "AGREGAR NUEVA CIUDAD"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                    label2.Location = new Point(35, label2.Location.Y); //REACOMODAR LABEL
                    txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    Entidad = CIUDADES; //LA ENTIDAD QUE OPERA ES CIUDADES
                    Operacion = NUEVO; //LA OPERACION EN CURSO ES AGREGAR UN NUEVO REGISTRO
                }
            }

            if (e.KeyCode == Keys.M) //SI LA TECLA APRETADA ES M o m
            {
                if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
                {
                    if (dgvCiudades.RowCount != 0) //SI HAY CIUDADES CARGADAS EN LA PROVINCIA SELECCIONADA
                    {
                        AbrirPanel(); //ABRIR EL PANEL
                        label2.Text = "MODIFICAR CIUDAD"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                        label2.Location = new Point(65, label2.Location.Y); //REACOMODAR LABEL
                        txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString(); //CARGAR EN EL TEXTBOX LA CIUDAD SELECCIONADA
                        txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                        Entidad = CIUDADES; //LA ENTIDAD QUE OPERA ES CIUDADES
                        Operacion = MODIFICAR; //LA OPERACION EN CURSO ES MODIFICAR UN REGISTRO EXISTENTE
                    }
                }
            }

            if (e.KeyCode == Keys.Left) dgvProvincias.Focus(); //SI LA TECLA ES LA FLECHA IZQUIERDA, DARLE FOCO AL DATAGRID PROVINCIAS
        }

        private void seleccionarFilaProvincias(int codigo)
        {
            for (int i = 0; i < dgvProvincias.RowCount; i++) //RECORRER TODO EL DATAGRID PROVINCIAS
            {
                if (dgvProvincias.Rows[i].Cells[0].Value.ToString() == codigo.ToString()) //SE BUSCA LA FILA A TRAVES DEL CODIGO PROVINCIA. SI SE ENCUENTRA...
                {
                    dgvProvincias.CurrentCell = dgvProvincias.Rows[i].Cells[1]; 
                    dgvProvincias.Rows[i].Selected = true; //SELECCIONAR EL REGISTRO                
                }
            }
        }

        private void seleccionarFilaCiudades(int codigo)
        {
            for (int i = 0; i < dgvCiudades.RowCount; i++) //RECORRER TODO EL DATAGRID CIUDADES
            {
                if (dgvCiudades.Rows[i].Cells[1].Value.ToString() == codigo.ToString()) //SI LA FILA COINCIDE CON EL CODIGO CIUDAD
                {
                    dgvCiudades.CurrentCell = dgvCiudades.Rows[i].Cells[2]; //SELECCIONAR EL REGISTRO
                    dgvCiudades.Rows[i].Selected = true; //SELECCIONAR EL REGISTRO  
                }
            }
        }
    }
}
