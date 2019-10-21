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
    public partial class Formatos : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;
        const int MODIFICAR = 2;        //CONSTANTES
        const int HABILITADO = 3;
        const int DESHABILITADO = 4;

        Conexion BD = new Conexion();
        DataTable DTFormatos = new DataTable();
        DataTable DTPeliculas = new DataTable();
        DataTable DTPXF = new DataTable();
        DataTable DTFormatos2 = new DataTable();
        SqlDataAdapter adaptador;
        SqlCommand comando;
        SqlDataReader reader;

        int OperacionFormatos = 0;  //INDICADOR DE OPERACION ACTUAL DE FORMATOS
        int OperacionPXF = 0; //INDICADOR DE OPERACION ACTUAL DE PELICULAS X FORMATOS
        int EstadoPXF = 0; //INDICADOR DE ESTADO DEL REGISTRO SELECCIONADO EN PELICULAS X FORMATOS

        public Formatos()
        {
            InitializeComponent();

            if (BD.abrir()) //SI LA CONEXION CON LA BASE DE DATOS SE PUEDE ABRIR...
            {
                dgvFormatos.DataSource = DTFormatos; //INDICARLE AL DATAGRID DE FORMATOS QUE SU FUENTE DE DATOS SERA EL DATATABLE FORMATOS
                boxPeliculas.DataSource = DTPeliculas; //INDICARLE AL BOX DE PELICULAS QUE SU FUENTE DE DATOS SERA EL DATATABLE PELICULAS
                dgvPXF.DataSource = DTPXF; //INDICARLE AL DATAGRID PELICULAS X FORMATO QUE SU FUENTE DE DATOS SERA EL DATATABLE PELICULAS X FORMATOS
                boxFormatos.DataSource = DTFormatos2; //INDICARLE AL BOX DE FORMATOS QUE SU FUENTE DE DATOS SERA EL DATATABLE FORMATOS 2

                ActualizarDgvFormatos(); //ACTUALIZAR DATAGRIDVIEW FORMATOS
                ActualizarBoxPeliculas(); //ACTUALIZAR BOX PELICULAS
                ActualizarDgvPXF(); //ACTUALIZAR DATAGRIDVIEW PELICULAS X FORMATOS
                ActualizarBoxFormatos(); //ACTUALIZAR BOX FORMATOS
            }

            ConfigurarGrids(); //CONFIGURACION RELACIONADA CON LA APARIENCIA DE LOS DATAGRIDS
        }

        private void RemoverElementosBoxFormatos()
        {
            for (int i = 0; i < dgvPXF.RowCount; i++) //RECORRER EL DATAGRID DE PELICULAS X FORMATOS
            {
                for (int j = 0; j < DTFormatos2.Rows.Count; j++) //RECORRER EL DATATABLE DE FORMATOS 2
                {
                    if (DTFormatos2.Rows[j][0].ToString() == dgvPXF.Rows[i].Cells[0].Value.ToString()) //SI EL FORMATO DEL BOX, APARECE ACTUALMENTE EN EL DATAGRID...
                    {
                        DTFormatos2.Rows.RemoveAt(j); //ELIMINAR ESE ELEMENTO DEL BOX
                    }
                }
            }
        }

        private void ActualizarBoxFormatos()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Formatos", BD.getSqlConnection()); //TRAER TODOS LOS FORMATOS
            DTFormatos2.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTFormatos2); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            boxFormatos.DisplayMember = "Descripcion_Form"; //EL BOX MOSTRARA LA DESCRIPCION DE LOS FORMATOS
            boxFormatos.ValueMember = "CodFormato_Form"; //EL VALOR DE CADA MIEMBRO SERA EL CODIGO DEL FORMATO
        }

        private void ActualizarDgvPXF()
        {
            adaptador = new SqlDataAdapter("SELECT CodFormato_PXF, Descripcion_Form, Estado_PXF FROM PeliculasXFormato INNER JOIN Formatos ON CodFormato_Form = CodFormato_PXF WHERE CodPelicula_PXF = "+boxPeliculas.SelectedValue, BD.getSqlConnection()); //TRAER TODOS LAS PELICULAS X FORMATO
            DTPXF.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTPXF); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void ActualizarBoxPeliculas()
        {
            adaptador = new SqlDataAdapter("SELECT CodPelicula_Peli, Nombre_Peli FROM Peliculas", BD.getSqlConnection()); //TRAER TODAS LAS PELICULAS
            DTPeliculas.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTPeliculas); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            DTPeliculas.DefaultView.Sort = "Nombre_Peli"; //ORDENAR PELICULAS ALFABETICAMENTE

            boxPeliculas.DisplayMember = "Nombre_Peli"; //EL BOX MOSTRARA LOS NOMBRES DE LAS PELICULAS
            boxPeliculas.ValueMember = "CodPelicula_Peli"; //EL VALOR DE CADA MIEMBRO SERA EL CODIGO DE LA PELICULA
        }

        private void AbrirPanelPXF()
        {
            dgvPXF.Height = 235; //ACHICAR DATAGRID
            panelPXF.Visible = true; //HACER VISIBLE EL PANEL
            btnNuevoPXF.Visible = false; //OCULTAR BOTON "NUEVO"
            btnHabilitacionPXF.Visible = false; //OCULTAR BOTON DE HABILITACION
        }

        private void CerrarPanelPXF()
        {
            OperacionPXF = NULL; //ASIGNAR "NULO" A LA OPERACION ACTUAL DE PELICULAS X FORMATO
            panelPXF.Visible = false; //HACER INVISIBLE EL PANEL
            dgvPXF.Height = 332; //AGRANDAR DATAGRID
            btnNuevoPXF.Visible = true; //MOSTRAR BOTON "NUEVO"
            btnHabilitacionPXF.Visible = true; //MOSTRAR BOTON DE HABILITACION
        }

        private void ActualizarDgvFormatos()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Formatos", BD.getSqlConnection()); //TRAER TODOS LOS FORMATOS
            DTFormatos.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTFormatos); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void AbrirPanelFormatos()
        {
            dgvFormatos.Height = 277; //ACHICAR DATAGRID
            panelFormato.Visible = true; //HACER VISIBLE EL PANEL
            btnNuevoFormato.Visible = false; //OCULTAR FOTON DE "NUEVO"
            btnModificarFormato.Visible = false; //OCULTAR BOTON DE "MODIFICAR"
        }

        private void CerrarPanelFormatos()
        {
            OperacionFormatos = NULL; //ASIGNAR "NULO" A LA OPERACION DE FORMATOS
            panelFormato.Visible = false; //OCULTAR PANEL
            dgvFormatos.Height = 374; //AGRANDAR DATAGRID
            btnNuevoFormato.Visible = true; //MOSTRAR BOTON DE "NUEVO"
            btnModificarFormato.Visible = true; //MOSTRAR BOTON DE "MODIFICAR"
            txtDescripcionFormato.Clear(); //LIMPIAR EL TEXTBOX
        }

        private void ConfigurarGrids()
        {
            dgvFormatos.Columns[0].HeaderText = "Codigo";
            dgvFormatos.Columns[1].HeaderText = "Formatos";

            dgvFormatos.Height = 374;
            dgvFormatos.Columns[0].Visible = false;
            dgvFormatos.ReadOnly = true;
            dgvFormatos.AllowUserToAddRows = false;
            dgvFormatos.RowHeadersVisible = false;
            dgvFormatos.AllowUserToResizeColumns = false;
            dgvFormatos.AllowUserToResizeRows = false;
            dgvFormatos.MultiSelect = false;
            dgvFormatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFormatos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFormatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFormatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFormatos.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvFormatos.Sort(dgvFormatos.Columns[1], ListSortDirection.Ascending);


            dgvPXF.Columns[0].HeaderText = "Codigo";
            dgvPXF.Columns[1].HeaderText = "Formato";
            dgvPXF.Columns[2].HeaderText = "Estado";

            dgvPXF.Height = 332;
            dgvPXF.Columns[0].Visible = false;
            dgvPXF.ReadOnly = true;
            dgvPXF.AllowUserToAddRows = false;
            dgvPXF.RowHeadersVisible = false;
            dgvPXF.AllowUserToResizeColumns = false;
            dgvPXF.AllowUserToResizeRows = false;
            dgvPXF.MultiSelect = false;
            dgvPXF.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPXF.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPXF.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPXF.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPXF.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPXF.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPXF.Sort(dgvPXF.Columns[1], ListSortDirection.Ascending);
        }

        private void btnVolverFormato_Click(object sender, EventArgs e)
        {
            CerrarPanelFormatos(); //CERRAR PANEL DE FORMATOS
        }

        private void btnNuevoFormato_Click(object sender, EventArgs e)
        {
            OperacionFormatos = NUEVO; //LA OPERACION ACTUAL DE FORMATOS ES "NUEVO"
            AbrirPanelFormatos(); //ABRIR PANEL
            txtDescripcionFormato.Focus(); //DARLE FOCO AL TEXTBOX
        }

        private void btnModificarFormato_Click(object sender, EventArgs e)
        {
            OperacionFormatos = MODIFICAR; //LA OPERACION ACTUAL DE FORMATOS ES "MODIFICAR"
            AbrirPanelFormatos(); //ABRIR PANEL DE FORMATOS
            txtDescripcionFormato.Text = dgvFormatos.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
            txtDescripcionFormato.Focus(); //DARLE FOCO AL TEXTBOX
            txtDescripcionFormato.SelectAll(); //SELECCIONAR TODO EL TEXTO
        }

        private void dgvFormatos_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionFormatos == MODIFICAR) //SI LA OPERACION ACTUAL DE FORMATOS ES "MODIFICAR"...
            {
                try
                {
                    txtDescripcionFormato.Text = dgvFormatos.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
                    txtDescripcionFormato.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionFormato.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
                catch (Exception ex) { }
            }
        }

        private void btnGuardarFormato_Click(object sender, EventArgs e)
        {
            if(txtDescripcionFormato.TextLength != 0) //SI EL TEXTBOX NO ESTA VACIO...
            {
                if (OperacionFormatos == NUEVO) //SI SE DESEA AGREGAR UN NUEVO REGISTRO...
                {
                    int NuevoCodigo = Int32.Parse(DTFormatos.Compute("MAX(CodFormato_Form)", "").ToString()) + 1; //TOMAR EL ULTIMO CODIGO DE FORMATO Y SUMARLE 1

                    comando = new SqlCommand("INSERT INTO Formatos (CodFormato_Form, Descripcion_Form) VALUES (" + NuevoCodigo + ", '" + txtDescripcionFormato.Text + "')", BD.getSqlConnection()); //INSERTAR NUEVO REGISTRO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvFormatos(); //ACTUALIZAR DATAGRID FORMATOS

                    dgvFormatos.CurrentCell = dgvFormatos.Rows[dgvFormatos.Rows.Count - 1].Cells[1]; //SELECCIONAR EL NUEVO REGISTRO
                    dgvFormatos.Rows[dgvFormatos.Rows.Count - 1].Selected = true; //SELECCIONAR EL NUEVO REGISTRO

                    txtDescripcionFormato.Clear(); //LIMPIAR EL TEXTBOX
                    txtDescripcionFormato.Focus(); //DARLE FOCO AL TEXTBOX

                    if (OperacionPXF == NUEVO) //SI EN EL PANEL DE PELICULAS X FORMATOS, EL PANEL ESTA ABIERTO...
                    {
                        ActualizarBoxFormatos(); //ACTUALIZAR TAMBIEN EL BOX DE FORMATOS
                        RemoverElementosBoxFormatos(); //Y REMOVER LOS ELEMENTOS QUE YA ESTAN AGREGADOS
                    }
                }

                if (OperacionFormatos == MODIFICAR) //SI SE ESTA MODIFICANDO...
                {
                    int CurrentIndexFormatos = dgvFormatos.CurrentRow.Index; //GUARDAR EL INDEX DEL REGISTRO ACUTAL DEL DATAGRID FORMATOS
                    int CurrentIndexPXF = dgvPXF.CurrentRow.Index; //GUARDAR EL INDEX DEL REGISTRO ACTUAL DEL DATAGRID PELICULAS X FORMATOS

                    comando = new SqlCommand("UPDATE Formatos SET Descripcion_Form = '"+txtDescripcionFormato.Text+"' WHERE CodFormato_Form = "+dgvFormatos.CurrentRow.Cells[0].Value, BD.getSqlConnection()); //ACTUALIZAR FORMATO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvFormatos(); //ACTUALIZAR DATAGRID FORMATOS

                    dgvFormatos.CurrentCell = dgvFormatos.Rows[CurrentIndexFormatos].Cells[1]; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO EN DATAGRID FORMATOS
                    dgvFormatos.Rows[CurrentIndexFormatos].Selected = true; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO EN DATAGRID FORMATOS

                    txtDescripcionFormato.Text = dgvFormatos.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
                    txtDescripcionFormato.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionFormato.SelectAll(); //SELECCIONAR TODO EL TEXTO

                    ActualizarDgvPXF(); //ACTUALIZAR DATAGRID PELICULAS X FORMATO

                    dgvPXF.CurrentCell = dgvPXF.Rows[CurrentIndexPXF].Cells[1]; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO EN DATAGRID PELICULAS X FORMATO
                    dgvPXF.Rows[CurrentIndexPXF].Selected = true; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO EN DATAGRID PELICULAS X FORMATO

                    if(OperacionPXF == NUEVO) //SI EN EL PANEL DE PELICULAS X FORMATO, EL PANEL ESTA ABIERTO...
                    {
                        ActualizarBoxFormatos(); //ACUTALIZAR TAMBIEN EL BOX DE FORMATOS
                        RemoverElementosBoxFormatos(); //Y REMOVER LOS ELEMENTOS QUE ESTA ESTAN AGREGADOS
                    }
                }
            }
        }

        private void btnNuevoPXF_Click(object sender, EventArgs e)
        {
            ActualizarBoxFormatos(); //LLENAR EL BOX CON TODOS LOS REGISTROS EXISTENTES
            RemoverElementosBoxFormatos(); //REMOVER DEL BOX LOS ELEMENTOS QUE ESTAN ACTUALMENTE EN EL DATAGRID

            if (DTFormatos2.Rows.Count > 0) //SI AL BOX LE QUEDARON REGISTROS...
            {
                OperacionPXF = NUEVO; //ASIGNAR "NUEVO" A OPERACION ACTUAL DE PELICULAS X FORMATO
                AbrirPanelPXF(); //ABRIR EL PANEL
            }
            else //SI NO LE QUEDAN REGISTROS. LA PELICULA YA ESTA EN TODOS LOS FORMATOS DISPONIBLES
            {
                MessageBox.Show("La pelicula se encuentra en todos los formatos disponibles.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolverPXF_Click(object sender, EventArgs e)
        {
            CerrarPanelPXF(); //CERRAR EL PANEL
        }

        private void boxPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDgvPXF(); //ACTUALIZAR DATAGRID PELICULAS X FORMATO

            ActualizarBoxFormatos(); //ACTUALIZAR BOX FORMATOS
            RemoverElementosBoxFormatos(); //REMOVER LOS ELEMENTOS QUE SE ENCUENTRAN ACTUALMENTE EL EN DATAGRID PELICULAS X FORMATO

            if(OperacionPXF == NUEVO) //SI EL PANEL DE PELICULAS X FORMATO ESTA ABIERTO...
            {
                if (DTFormatos2.Rows.Count == 0) //SI NO QUEDARON ELEMENTOS EN EL BOX...
                {
                    CerrarPanelPXF(); //CERRAR EL PANEL
                }
            }
        }

        private void dgvPXF_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPXF.CurrentRow.Cells[2].Value.ToString() == "True") //SI EL REGISTRO ACTUAL ESTA HABILITADO
                {
                    btnHabilitacionPXF.Text = "Deshabilitar"; //CAMBIAR EL TEXTO DEL BOTON A "DESHABILITAR"
                    EstadoPXF = HABILITADO; //PONER "HABILITADO" EL INDICARDOR DE ESTADO
                }

                if (dgvPXF.CurrentRow.Cells[2].Value.ToString() == "False") //SI EL REGISTRO ACTUAL ESTA DESHABILITADO
                {
                    btnHabilitacionPXF.Text = "Habilitar"; //CAMBIAR EL TEXTO DEL BOTON A "HABILITAR"
                    EstadoPXF = DESHABILITADO; //PONER "DESHABILITADO" EL INDICADOR DE ESTADO
                }
            }
            catch (Exception ex) { }
        }

        private void btnHabilitacionPXF_Click(object sender, EventArgs e)
        {
            int CurrentIndex = dgvPXF.CurrentRow.Index; //GUARDAR EL INDICE DEL REGISTRO ACTUAL DEL DATAGRID PELICULAS X FORMATOS

            if (EstadoPXF == HABILITADO) //SI EL REGISRO ACTUAL ESTA HABILITADO
            {
                DialogResult resultado= MessageBox.Show("Al deshabilitar " + boxPeliculas.Text + " " + dgvPXF.CurrentRow.Cells[1].Value.ToString() + ", tambien se deshabilitaran todas las funciones que proyecten la pelicula en dicho formato.\nPara volver a habilitar las funciones debera hacerlo manualmente.\n¿Desea continuar?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(resultado == DialogResult.Yes) //SI SE SELECCIONO "SI"
                {
                    comando = new SqlCommand("UPDATE PeliculasXFormato SET Estado_PXF = 'False' WHERE CodPelicula_PXF = " + boxPeliculas.SelectedValue + " AND CodFormato_PXF = " + dgvPXF.CurrentRow.Cells[0].Value, BD.getSqlConnection()); //ACTUALIZARLO A DESHABILITADO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    deshabilitarFunciones(); //DESHABILTIAR LAS FUNCIONES QUE CONTENGAN LA PELICULA Y EL FORMATO 
                }
            }

            if (EstadoPXF == DESHABILITADO) //SI EL REGISTRO ACTUAL ESTA DESHABILITADO
            {
                if(getEstadoPelicula()) //SI LA PELICULA ESTA HABILITADA
                {
                    comando = new SqlCommand("UPDATE PeliculasXFormato SET Estado_PXF = 'True' WHERE CodPelicula_PXF = " + boxPeliculas.SelectedValue + " AND CodFormato_PXF = " + dgvPXF.CurrentRow.Cells[0].Value, BD.getSqlConnection()); //ACTUALIZARLO A HABILITADO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA
                }
                else //SI LA PELICULA ESTA DESHABILITADA
                {
                    MessageBox.Show(boxPeliculas.Text + " esta deshabilitada, no se la puede habilitar en ningun formato.", "Pelicula deshabilitada", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }

            ActualizarDgvPXF(); //ACTUALIZAR DATAGRID PELICULAS X FORMATO

            dgvPXF.CurrentCell = dgvPXF.Rows[CurrentIndex].Cells[2]; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO
            dgvPXF.Rows[CurrentIndex].Selected = true; //SELECIONAR EL REGISTRO QUE ESTABA SELECCIONADO

            try
            {
                if (dgvPXF.CurrentRow.Cells[2].Value.ToString() == "True") //SI EL REGISTRO ACTUAL ESTA HABILITADO
                {
                    btnHabilitacionPXF.Text = "Deshabilitar"; //CAMBIAR EL TEXTO DEL BOTON A "DESHABILITAR"
                    EstadoPXF = HABILITADO; //PONER "HABILITADO" EL INDICARDOR DE ESTADO
                }

                if (dgvPXF.CurrentRow.Cells[2].Value.ToString() == "False") //SI EL REGISTRO ACTUAL ESTA DESHABILITADO
                {
                    btnHabilitacionPXF.Text = "Habilitar"; //CAMBIAR EL TEXTO DEL BOTON A "HABILITAR"
                    EstadoPXF = DESHABILITADO; //PONER "DESHABILITADO" EL INDICADOR DE ESTADO
                }
            }
            catch (Exception ex) { }
        }

        private void btnGuardarPXF_Click(object sender, EventArgs e)
        {
            comando = new SqlCommand("INSERT INTO PeliculasXFormato (CodPelicula_PXF, CodFormato_PXF, Estado_PXF) VALUES ("+boxPeliculas.SelectedValue+", "+boxFormatos.SelectedValue+", 'True')", BD.getSqlConnection()); //INSERTAR NUEVO REGISTRO
            comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

            ActualizarDgvPXF(); //ACTUALIZAR DATAGRID
            RemoverElementosBoxFormatos(); //REMOVER DEL BOX EL NUEVO ELEMENTO AGREGADO

            if (DTFormatos2.Rows.Count == 0) //SI EL BOX SE QUEDA VACIO...
            {
                CerrarPanelPXF(); //CERRAR EL PANEL
            }
        }

        private void deshabilitarFunciones()
        {
            comando = new SqlCommand("UPDATE Funciones SET Estado_Func = 'False' WHERE CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + dgvPXF.CurrentRow.Cells[0].Value.ToString(), BD.getSqlConnection());
            comando.ExecuteNonQuery();
        }

        private bool getEstadoPelicula()
        {
            comando = new SqlCommand("SELECT CodPelicula_Peli FROM Peliculas WHERE CodPelicula_Peli = " + boxPeliculas.SelectedValue + " AND Estado_Peli = 'True'", BD.getSqlConnection()); //GENERAR CONSULTA
            reader = comando.ExecuteReader(); //EJECUTAR CONSULTA

            if(reader.HasRows) //SI SE ENCONTRO LA PELICULA CON ESTADO "TRUE"
            {
                reader.Close(); //CERRAR READER
                return true; //DEVOLVER VERDADERO
            }
            else //SI ESTA CON ESTADO "FALSE"
            {
                reader.Close(); //CERRAR READER
                return false; //DEVOLVER FALSO
            }
        }
    }
}
