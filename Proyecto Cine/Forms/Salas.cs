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
    public partial class Salas : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;        //CONSTANTES
        const int MODIFICAR = 2;

        Conexion BD = new Conexion();
        DataTable DT_TDS = new DataTable();
        DataTable DT_TDS2 = new DataTable();
        DataTable DTSalas = new DataTable();
        DataTable DTCines = new DataTable();
        SqlDataAdapter adaptador;
        SqlCommand comando;
        SqlDataReader reader;

        int OperacionTDS = 0; //INDICADOR DE OPERACION ACTUAL EN TIPOS DE SALAS
        int OperacionSalas = 0; //INDICADOR DE OPERACION ACTUAL EN SALAS

        public Salas()
        {
            InitializeComponent();

            if (BD.Abrir()) //SI LA CONEXION CON LA BASE DE DATOS SE PUEDE ABRIR...
            {
                dgvTDS.DataSource = DT_TDS; //INDICARLE AL DATAGRID DE TIPO DE SALAS QUE SU FUENTE DE DATOS SERA EL DATATABLE DE TIPO DE SALAS
                boxTDS.DataSource = DT_TDS2; //INDICARLE AL BOX DE TIPO DE SALAS QUE FUENTE DE DATOS SERA EL DATATABLE DE TIPO DE SALAS 2
                dgvSalas.DataSource = DTSalas; //INDICARLE AL DATAGRID DE SALAS QUE SU FUENTE DE DATOS SERA EL DATATABLE DE SALAS
                boxCines.DataSource = DTCines; //INDICARLE AL BOX DE CINES QUE SU FUENTE DE DATOS SERA EL DATATABLE DE CINES

                ActualizarBoxCine(); //ACTUALIZAR EL BOX DE CINES
                ActualizarDgvTDS(); //ACTUALIZAR EL DATAGRID DE TIPO DE SALAS
                ActualizarDgvSalas(); //ACTUALIZAR EL DATAGRID DE SALAS
                ActualizarBoxTDS(); //ACTUALIZAR EL BOX DE TIPOS DE SALAS
            }

            ConfigurarGrids(); //CONFIGURACION RELACIONADA CON LA APARIENCIA DE LOS DATAGRIDS
        }

        private void ActualizarBoxTDS()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM TiposDeSalas", BD.conectarBD); //TRAER TODOS LOS TIPOS DE SALAS
            DT_TDS2.Clear(); //LIMPIAR EL DATATABLE DEL BOX
            adaptador.Fill(DT_TDS2); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            DT_TDS2.DefaultView.Sort = "Descripcion_TDS"; //ORDENAR DATATABLE POR DESCRIPCION

            boxTDS.DisplayMember = "Descripcion_TDS"; //LOS DATOS QUE SE VERAN EN EL BOX SERAN LAS DESCRIPCIONES
            boxTDS.ValueMember = "CodTipoDeSala_TDS"; //Y ASIGNARA A CADA ITEM EL CODIGO DE TIPO DE SALA PERTENECIENTE
        }

        private void ActualizarBoxCine()
        {
            adaptador = new SqlDataAdapter("Select CodCine_Cine, Nombre_Cine from Cines", BD.conectarBD); //TRAER LOS CINES
            DTCines.Clear(); //LIMPIAR EL DATATABLE DE CINES DE VIEJOS REGISTROS
            adaptador.Fill(DTCines); //LLENAR EL DATATABLE DE CINES CON NUEVOS 

            DTCines.DefaultView.Sort = "Nombre_Cine"; //ORDENAR EL DATATABLE POR NOMBRE

            boxCines.DisplayMember = "Nombre_Cine"; //LOS DATOS QUE SE VERAN EN EL BOX DE CINES SERAN LOS NOMBRES
            boxCines.ValueMember = "CodCine_Cine"; //Y SE ASIGANARA A CADA ITEM EL CODIGO DE CINE PERTENECIENTE
        }

        private void ActualizarDgvSalas()
        {
            adaptador = new SqlDataAdapter("SELECT CodSala_SXC, CodTipoDeSala_SXC, Descripcion_SXC, Descripcion_TDS, Estado_SXC FROM SalasXCine INNER JOIN TiposDeSalas ON CodTipoDeSala_SXC = CodTipoDeSala_TDS WHERE CodCine_SXC = " + boxCines.SelectedValue, BD.conectarBD); //TRAER TODAS LAS SALAS DEL CINE SELECCIONADO
            DTSalas.Clear(); //LIMPIAR EL DATATABLE DE SALAS DE VIEJOS REGISTROS
            adaptador.Fill(DTSalas); //LLENAR EL DATATABLE DE SALAS CON LOS NUEVOS REGISTROS
        }

        private void ActualizarDgvTDS()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM TiposDeSalas", BD.conectarBD); //TRAER TODOS LOS TIPOS DE SALAS
            DT_TDS.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DT_TDS); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void ConfigurarGrids()
        {
            dgvTDS.Columns[0].HeaderText = "Codigo";
            dgvTDS.Columns[1].HeaderText = "Tipo de Salas";

            dgvTDS.Height = 377;
            dgvTDS.Columns[0].Visible = false;
            dgvTDS.ReadOnly = true;
            dgvTDS.AllowUserToAddRows = false;
            dgvTDS.RowHeadersVisible = false;
            dgvTDS.AllowUserToResizeColumns = false;
            dgvTDS.AllowUserToResizeRows = false;
            dgvTDS.MultiSelect = false;
            dgvTDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTDS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTDS.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTDS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTDS.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTDS.Sort(dgvTDS.Columns[1], ListSortDirection.Ascending);

            dgvSalas.Columns[0].HeaderText = "Codigo de sala";
            dgvSalas.Columns[1].HeaderText = "Codigo tipo de sala";
            dgvSalas.Columns[2].HeaderText = "Nombre";
            dgvSalas.Columns[3].HeaderText = "Tipo";
            dgvSalas.Columns[4].HeaderText = "Habilitada";

            dgvSalas.Height = 350;
            dgvSalas.Columns[0].Visible = false;
            dgvSalas.Columns[1].Visible = false;
            dgvSalas.ReadOnly = true;
            dgvSalas.AllowUserToAddRows = false;
            dgvSalas.RowHeadersVisible = false;
            dgvSalas.AllowUserToResizeColumns = false;
            dgvSalas.AllowUserToResizeRows = false;
            dgvSalas.MultiSelect = false;
            dgvSalas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalas.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalas.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSalas.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSalas.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSalas.Sort(dgvSalas.Columns[2], ListSortDirection.Ascending);
        }

        private void AbrirPanelTDS()
        {
            btnNuevoTDS.Visible = false; //OCULTAR EL BOTON DE "NUEVO"
            btnModificarTDS.Visible = false; //OCULTAR EL BOTON DE MODIFICAR
            dgvTDS.Height = 283;
            PanelTDS.Visible = true; //HACER VISIBLE EL PANEL
        }

        private void CerrarPanelTDS()
        {
            PanelTDS.Visible = false; //HACER INVISIBLE EL PANEL
            txtDescripcionTDS.Clear(); //LIMPIAR EL TEXTBOX
            dgvTDS.Height = 377; //AGRANDAR EL DGV
            btnNuevoTDS.Visible = true; //MOSTRAR EL BOTON DE "NUEVO"
            btnModificarTDS.Visible = true; //MOSTRAR EL BOTON DE "MODIFICAR"
            OperacionTDS = NULL; //NO HAY OPERACION EN CURSO PARA TIPO DE SALAS
        }

        private void AbrirPanelSalas()
        {
            btnNuevoSalas.Visible = false; //OCULTAR EL BOTON DE "NUEVO"
            btnModificarSalas.Visible = false; //OCULTAR EL BOTON DE "MODIFICAR"
            dgvSalas.Height = 256;
            PanelSalas.Visible = true; //HACER VISIBLE EL PANEL
        }

        private void CerrarPanelSalas()
        {
            PanelSalas.Visible = false; //HACER INVISIBLE EL PANEL
            txtDescripcionSalas.Clear(); //LIMPIAR EL TEXTBOX
            boxTDS.SelectedIndex = 0; //SELECCIONAR POR DEFECTO EL PRIMER REGISTRO DEL BOX DE TIPOS DE SALAS
            checkSala.Checked = true; //POR DEFECTO LA SALA ESTA HABILITADA
            dgvSalas.Height = 350; //AGRANDAR EL DGV
            btnNuevoSalas.Visible = true; //MOSTRAR EL BOTON DE "NUEVO"
            btnModificarSalas.Visible = true; //MOSTRAR EL BOTON DE "MODIFICAR"
            OperacionSalas = NULL; //NO HAY OPERACION EN CURSO PARA SALAS
        }

        private void btnNuevoTDS_Click(object sender, EventArgs e)
        {
            OperacionTDS = NUEVO; //MARCAR COMO "NUEVO" LA OPERACION ACTUAL DE TIPO DE SALAS
            AbrirPanelTDS(); //ABRIR EL PANEL DE TIPO DE SALAS
            txtDescripcionTDS.Focus(); //DARLE FOCO AL TEXTBOX
        }

        private void btnModificarTDS_Click(object sender, EventArgs e)
        {
            if(dgvTDS.RowCount != 0) //SI EXISTEN REGISTROS...
            {
                OperacionTDS = MODIFICAR; //MARCAR COMO "MODIFICAR" LA OPERACION ACTUAL DE TIPO DE SALAS
                AbrirPanelTDS(); //ABRIR EL PANEL DE TIPO DE SALAS

                txtDescripcionTDS.Text = dgvTDS.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
                txtDescripcionTDS.Focus(); //DARLE FOCO AL TEXTBOX
                txtDescripcionTDS.SelectAll(); //SELECCIONAR TODO EL TEXTO
            }
        }

        private void btnVolverTDS_Click(object sender, EventArgs e)
        {
            CerrarPanelTDS(); //CERRAR EL PANEL DE TIPO DE SALAS
        }

        private void btnNuevoSalas_Click(object sender, EventArgs e)
        {
            OperacionSalas = NUEVO; //MARCAR COMO "NUEVO" LA OPERACION ACTUAL DE SALAS
            AbrirPanelSalas(); //ABRIR EL PANEL DE SALAS
            txtDescripcionSalas.Focus(); //DARLE FOCO AL TEXTBOX
        }

        private void btnModificarSalas_Click(object sender, EventArgs e)
        {
            if(dgvSalas.RowCount != 0) //SI EXISTEN REGISTROS...
            {
                OperacionSalas = MODIFICAR; //MARCAR COMO "MODIFICAR" LA OPERACION ACTUAL DE SALAS
                AbrirPanelSalas(); //ABRIR EL PANEL DE SALAS

                txtDescripcionSalas.Text = dgvSalas.CurrentRow.Cells[2].Value.ToString(); //LLENAR EL TEXTBOX CON LA DESCRIPCION DEL REGISTRO SELECCIONADO
                txtDescripcionSalas.Focus(); //DARLE FOCO AL TEXTBOX
                txtDescripcionSalas.SelectAll(); //SELECCIONAR TODO EL TEXTO
                boxTDS.SelectedValue = dgvSalas.CurrentRow.Cells[1].Value; //SELECCIONAR EL ELEMENTO CORRESPONDIENTE DEL BOX
                checkSala.Checked = bool.Parse(dgvSalas.CurrentRow.Cells[4].Value.ToString()); //MARCAR SI LA SALA ESTA HABILITADA O NO
            }
        }

        private void btnVolverSalas_Click(object sender, EventArgs e)
        {
            CerrarPanelSalas(); //CERRAR EL PANEL DE SALAS
        }

        private void boxCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDgvSalas(); //ACTUALIZAR DATAGRID DE SALAS

            if (OperacionSalas == MODIFICAR) //SI SE ESTA MODIFICANDO LAS SALAS
            {
                if (dgvSalas.RowCount == 0) CerrarPanelSalas(); //Y EL CINE SELECCIONADO NO TIENE SALAS CARGADAS. CERRAR EL PANEL
            }
        }

        private void dgvTDS_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionTDS == MODIFICAR) //SI SE ESTAN HACIENDO MODIFICACIONES
            {
                try
                {
                    txtDescripcionTDS.Clear(); //LIMPIAR EL TEXTBOX
                    txtDescripcionTDS.Text = dgvTDS.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
                    txtDescripcionTDS.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionTDS.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
                catch(Exception ex) { }
            }
        }

        private void dgvSalas_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionSalas == MODIFICAR) //SI LA OPERACION ACTUAL ES MODIFICAR...
            {
                try
                {
                    txtDescripcionSalas.Text = dgvSalas.CurrentRow.Cells[2].Value.ToString(); //LLENAR EL TEXTBOX CON LA SALA SELECCIONADA
                    txtDescripcionSalas.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionSalas.SelectAll(); //SELECCIONAR TODO EL TEXTO
                    boxTDS.SelectedValue = dgvSalas.CurrentRow.Cells[1].Value; //SELECCIONAR EL ITEM CORRESPONDIENTE
                    checkSala.Checked = bool.Parse(dgvSalas.CurrentRow.Cells[4].Value.ToString()); //MARCAR SI LA SALA ESTA HABILITADA O NO
                }
                catch(Exception ex) { }
            }
        }

        private void btnGuardarTDS_Click(object sender, EventArgs e)
        {
            if (txtDescripcionTDS.TextLength != 0) //SI EL TEXTBOX NO ESTA VACIO
            {
                if (OperacionTDS == NUEVO) //SI SE VA A AGREGAR UN NUEVO TIPO DE SALA...
                {
                    int NuevoCodigo = Int32.Parse(DT_TDS.Compute("MAX(CodTipoDeSala_TDS)", "").ToString()) + 1; //OBTENER EL ULTIMO CODIGO REGISTRADO Y SUMARLE 1

                    comando = new SqlCommand("INSERT INTO TiposDeSalas (CodTipoDeSala_TDS, Descripcion_TDS) VALUES(" + NuevoCodigo + ", '" + txtDescripcionTDS.Text + "')", BD.conectarBD); //INSERTAR EL NUEVO REGISTRO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvTDS(); //ACTUALIZAR EL DATAGRID DE TIPO DE SALAS
                    ActualizarBoxTDS(); //ACTUALIZAR EL BOX DE TIPO DE SALAS

                    seleccionarFilaTDS(NuevoCodigo.ToString()); //SELECCIONAR EL NUEVO REGISTRO

                    txtDescripcionTDS.Clear(); //LIMPIAR EL TEXTBOX
                    txtDescripcionTDS.Focus(); //DARLE EL FOCO AL TEXTBOX
                }

                if (OperacionTDS == MODIFICAR)
                {
                    string CodigoSeleccionadoTDS = dgvTDS.CurrentRow.Cells[0].Value.ToString(); //VARIABLE QUE GUARDA EL CODIGO DE TIPO DE SALA SELECCIONADO
                    int SelectedIndexTDS = dgvTDS.CurrentRow.Index; //VARIABLE QUE GUARDA EL REGISTRO QUE ESTABA SELECCIONADO EN DATAGRID TIPO DE SALAS
                    int SelectedIndexSalas = dgvSalas.CurrentRow.Index; //VARIABLE QUE GUARDA EL REGISTRO QUE ESTABA SELECCIONADO EN DATAGRID SALAS

                    comando = new SqlCommand("UPDATE TiposDeSalas SET Descripcion_TDS = '" + txtDescripcionTDS.Text + "' WHERE CodTipoDeSala_TDS = " + CodigoSeleccionadoTDS, BD.conectarBD); //ACTUALIZAR REGISTRO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvTDS();
                    ActualizarBoxTDS();     //ACTUALIZAR LOS CONTENEDORES DE DATOS INVOLUCRADOS
                    ActualizarDgvSalas();

                    seleccionarFilaTDS(CodigoSeleccionadoTDS); //SELECCIONAR EL REGISTRO MODIFICADO

                    dgvSalas.CurrentCell = dgvSalas.Rows[SelectedIndexSalas].Cells[2]; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO EN SALAS
                    dgvSalas.Rows[SelectedIndexSalas].Selected = true; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO EN SALAS

                    txtDescripcionTDS.Text = dgvTDS.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
                    txtDescripcionTDS.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionTDS.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
            }
            else //SI EL TEXTBOX DESCRIPCION ESTA VACIO
            {
                MessageBox.Show("La descripcion de tipo de salas no puede quedar vacia.\nPor favor ingrese una descripcion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcionTDS.Focus();
            }
        }

        private void btnGuardarSalas_Click(object sender, EventArgs e)
        {
            if (txtDescripcionSalas.TextLength != 0) //SI EL TEXTBOX NO ESTA VACIO...
            {
                if (OperacionSalas == NUEVO) //SI SE DESEA AGREGAR UNA NUEVA SALA
                {
                    if(!(verificarEstadoCine() == false && checkSala.Checked == true)) //SI EL CINE ESTA HABILITADO
                    {
                        int NuevoCodigo; //VARIABLE QUE GUARDA EL CODIGO PARA LA NUEVA SALA

                        if (dgvSalas.RowCount != 0) //SI EL CINE CONTIENE SALAS...
                        {
                            NuevoCodigo = Int32.Parse(DTSalas.Compute("MAX(CodSala_SXC)", "").ToString()) + 1; //TOMAR EL ULTIMO CODIGO Y SUMARLE 1
                        }
                        else //SI EL CINE NO TIENE SALAS...
                        {
                            NuevoCodigo = 1; //QUE LA PRIMER SALA TENGA EL CODIGO 1
                        }

                        comando = new SqlCommand("INSERT INTO SalasXCine (CodCine_SXC, CodSala_SXC, CodTipoDeSala_SXC, Descripcion_SXC, Estado_SXC) VALUES (" + boxCines.SelectedValue + ", " + NuevoCodigo + ", " + boxTDS.SelectedValue + ", '" + txtDescripcionSalas.Text + "', '" + checkSala.Checked + "')", BD.conectarBD); //INSERTAR EL NUEVO REGISTRO
                        comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                        ActualizarDgvSalas(); //ACTUALIZAR EL DATAGRID DE SALAS

                        seleccionarFilaSalas(NuevoCodigo.ToString()); //SELECCIONAR NUEVO REGISTRO

                        txtDescripcionSalas.Clear(); //LIMPIAR EL TEXTBOX
                        txtDescripcionSalas.Focus(); //DARLE FOCO AL TEXTBOX
                    }
                    else //SI EL CINE ESTA DESHABILITADO Y SE QUIERE AGREGAR UNA SALA HABILITADA
                    {
                        MessageBox.Show("No se puede agregar una sala \"Activa\" cuando cuyo el cine esta deshabilitado.\nIntente con desactivar la casilla o habilitar dicho cine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (OperacionSalas == MODIFICAR) //SI SE VA A MODIFICAR...
                {
                    if (dgvSalas.CurrentRow.Cells[4].Value.ToString() == "True" && checkSala.Checked == false) //SI SE QUIERE DESHABILITAR LA SALA
                    {
                        DialogResult resultado = MessageBox.Show("Al deshabilitar la sala \"" + txtDescripcionSalas.Text + "\" del cine \"" + boxCines.Text + "\", tambien se deshabilitaran todas las funciones proyectadas en esta sala.\nPara habilitarlas debera hacerlo manualmente.\n¿Desea continuar?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if(resultado == DialogResult.Yes) //SI SE SELECCIONO "SI"
                        {
                            actualizarSala(); //ACTUALIZAR LA SALA EN LA BASE DE DATOS
                            deshabilitarFunciones(); //DESHABILITAR LAS FUNCIONES ASOCIADAS A ESTA
                        }
                    }
                    else if(dgvSalas.CurrentRow.Cells[4].Value.ToString() == "False" && checkSala.Checked == true) //SI SE QUIERE HABILITAR LA SALA
                    {
                        if(verificarEstadoCine()) //SI EL CINE ESTA HABILITADO...
                        {
                            actualizarSala(); //ACTUALIZAR SALA
                        }
                        else //SI EL CINE ESTA DESHABILITADO
                        {
                            MessageBox.Show("No se puede habilitar una sala cuyo cine esta deshabilitado.\nIntente primero con habilitar dicho cine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else //SI LA ACTUALIZACION NO TIENE QUE VER CON HABILITAR O DESHABILITAR LA SALA
                    {
                        actualizarSala(); //SIMPLEMENTE ACTUALIZAR
                    }
                }
            }
            else //SI EL TEXTBOX NOMBRE ESTA VACIO...
            {
                MessageBox.Show("El nombre de la sala no puede quedar vacio.\nPor favor ingrese un nombre.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcionSalas.Focus();
            }
        }

        private void seleccionarFilaTDS(String Codigo)
        {
            for(int i=0; i<dgvTDS.RowCount; i++) //RECORRER LOS TIPOS DE SALAS
            {
                if(dgvTDS.Rows[i].Cells[0].Value.ToString() == Codigo) //SI EL CODIGO COINCIDE CON EL DE LA FILA
                {
                    dgvTDS.CurrentCell = dgvTDS.Rows[i].Cells[1]; //SELECCIONAR EL REGISTRO
                    dgvTDS.Rows[i].Selected = true; //SELECCIONAR EL REGISTRO
                }
            }
        }

        private void seleccionarFilaSalas(String Codigo)
        {
            for(int i=0; i<dgvSalas.RowCount; i++) //RECORRER TODAS LAS SALAS
            {
                if(dgvSalas.Rows[i].Cells[0].Value.ToString() == Codigo) //SI EL CODIGO COINCIDE CON EL DE LA FILA
                {
                    dgvSalas.CurrentCell = dgvSalas.Rows[i].Cells[2]; //SELECCIONAR REGISTRO
                    dgvSalas.Rows[i].Selected = true; //SELECCIONAR REGISTRO
                }
            }

            txtDescripcionSalas.Text = dgvSalas.CurrentRow.Cells[2].Value.ToString(); //LLENAR EL TEXTBOX CON LA SALA SELECCIONADA
            txtDescripcionSalas.Focus(); //DARLE FOCO AL TEXTBOX
            txtDescripcionSalas.SelectAll(); //SELECCIONAR TODO EL TEXTO
            boxTDS.SelectedValue = dgvSalas.CurrentRow.Cells[1].Value; //SELECCIONAR EL ITEM CORRESPONDIENTE
            checkSala.Checked = bool.Parse(dgvSalas.CurrentRow.Cells[4].Value.ToString()); //MARCAR SI LA SALA ESTA HABILITADA O NO
        }

        private void actualizarSala()
        {
            int SelectedCode = Int32.Parse(dgvSalas.CurrentRow.Cells[0].Value.ToString()); //OBTENER EL CODIGO DE SALA SELECCIONADO
            int SelectedIndex = dgvSalas.CurrentRow.Index; //OBTENER EL REGISTRO QUE ESTABA SELECCIONADO EN EL DATAGRID DE SALAS

            comando = new SqlCommand("UPDATE SalasXCine SET CodTipoDeSala_SXC = " + boxTDS.SelectedValue + ", Descripcion_SXC = '" + txtDescripcionSalas.Text + "', Estado_SXC = '" + checkSala.Checked + "' WHERE CodCine_SXC = " + boxCines.SelectedValue + " AND CodSala_SXC = " + SelectedCode, BD.conectarBD); //ACTUALIZAR LA SALA
            comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

            ActualizarDgvSalas(); //ACTUALIZAR DATA GRID DE SALA

            seleccionarFilaSalas(SelectedCode.ToString()); //SELECCIONAR REGISTRO
        }

        private void deshabilitarFunciones()
        {
            comando = new SqlCommand("UPDATE Funciones SET Estado_Func = 'False' WHERE CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + dgvSalas.CurrentRow.Cells[0].Value.ToString(), BD.conectarBD);
            comando.ExecuteNonQuery();
        }

        private void habilitarFunciones()
        {
            comando = new SqlCommand("UPDATE Funciones SET Estado_Func = 'True' WHERE CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + dgvSalas.CurrentRow.Cells[0].Value.ToString(), BD.conectarBD);
            comando.ExecuteNonQuery();
        }

        private bool verificarEstadoCine()
        {
            comando = new SqlCommand("SELECT CodCine_Cine FROM Cines WHERE CodCine_Cine = " + boxCines.SelectedValue + " AND Estado_Cine = 'True'", BD.conectarBD); //BUSCAR SI EL CINE SELECIONADO ESTA HABILITADO
            reader = comando.ExecuteReader(); //EJECUTAR COMANDO

            if (reader.HasRows) //SI SE ENCONTRO EL CINE CON ESTADO TRUE
            {
                reader.Close(); //CERRAR EL DATAREADER
                return true; //DEVOLVER VERDADERO
            }
            else //SI EL CINE ESTA CON ESTADO FALSE
            {
                reader.Close(); //CERRAR EL DATAREADER
                return false; //DEVOLVER FALSO
            }
        }
    }
}
