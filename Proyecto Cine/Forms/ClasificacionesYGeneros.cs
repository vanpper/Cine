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
    public partial class ClasificacionesYGeneros : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;        //CONSTANTES
        const int MODIFICAR = 2;

        Conexion BD = new Conexion();
        SqlCommand comando;
        SqlDataAdapter adaptador;
        DataTable DTClasificaciones = new DataTable();
        DataTable DTGeneros = new DataTable();

        int OperacionClasificaciones = 0;   //INDICADOR DE OPERACION ACTUAL EN CLASIFICACIONES
        int OperacionGeneros = 0;   //INDICADOR DE OPERACION ACTUAL EN GENEROS

        public ClasificacionesYGeneros()
        {
            InitializeComponent();

            dgvClasificaciones.DataSource = DTClasificaciones; //INDICARLE AL DATAGRID DE CLASIFICACIONES QUE SU FUENTE DE DATOS SERA EL DATATABLE CLASIFICACIONES
            dgvGeneros.DataSource = DTGeneros; // INDICARLE AL DATAGRID DE GENEROS QUE SU FUENTE DE DATOS SERA EL DATATABLE DE GENEROS

            if (BD.Abrir()) //SI LA CONEXION CON LA BASE DE DATOS SE PUEDE ABRIR...
            {
                ActualizarDgvClasificaciones(); //ACTUALIZAR DATAGRID CLASIFICACIONES
                ActualizarDgvGeneros(); //ACTUALIZAR DATAGRID GENEROS
            }

            ConfigurarGrids(); //CONFIGURACION RELACIONADA CON LA APARIENCIA DE LOS DATAGRID
        }

        private void ConfigurarGrids()
        {
            dgvClasificaciones.Columns[0].HeaderText = "Codigo";
            dgvClasificaciones.Columns[1].HeaderText = "Clasificaciones";

            dgvClasificaciones.Height = 374;
            dgvClasificaciones.Columns[0].Visible = false;
            dgvClasificaciones.ReadOnly = true;
            dgvClasificaciones.AllowUserToAddRows = false;
            dgvClasificaciones.RowHeadersVisible = false;
            dgvClasificaciones.AllowUserToResizeColumns = false;
            dgvClasificaciones.AllowUserToResizeRows = false;
            dgvClasificaciones.MultiSelect = false;
            dgvClasificaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClasificaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClasificaciones.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClasificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasificaciones.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvClasificaciones.Sort(dgvClasificaciones.Columns[1], ListSortDirection.Ascending);

            dgvGeneros.Columns[0].HeaderText = "Codigo";
            dgvGeneros.Columns[1].HeaderText = "Generos";

            dgvGeneros.Height = 374;
            dgvGeneros.Columns[0].Visible = false;
            dgvGeneros.ReadOnly = true;
            dgvGeneros.AllowUserToAddRows = false;
            dgvGeneros.RowHeadersVisible = false;
            dgvGeneros.AllowUserToResizeColumns = false;
            dgvGeneros.AllowUserToResizeRows = false;
            dgvGeneros.MultiSelect = false;
            dgvGeneros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGeneros.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGeneros.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGeneros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGeneros.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvGeneros.Sort(dgvGeneros.Columns[1], ListSortDirection.Ascending);
        }

        private void ActualizarDgvClasificaciones()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Clasificaciones", BD.getSqlCn()); //TRAER TODAS LAS CLASFICACIONES
            DTClasificaciones.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTClasificaciones); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void ActualizarDgvGeneros()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Generos", BD.getSqlCn()); //TRAER TODOS LOS GENEROS
            DTGeneros.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTGeneros); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void AbrirPanelClasificaciones()
        {
            dgvClasificaciones.Height = 277; //ACHICAR DATAGRID
            panelClasificacion.Visible = true; //HACER VISIBLE EL PANEL
            btnNuevoClasificacion.Visible = false; //OCULTAR BOTON DE NUEVO
            btnModificarClasificacion.Visible = false; //OCULTAR BOTON DE MODIFICAR
        }

        private void AbrirPanelGeneros()
        {
            dgvGeneros.Height = 277; //ACHICAR PANEL
            panelGenero.Visible = true; //HACER VISIBLE EL PANEL
            btnNuevoGenero.Visible = false; //OCULTAR BOTON DE NUEVO
            btnModificarGenero.Visible = false; //OCULTAR BOTON DE MODIFICAR
        }

        private void CerrarPanelClasificaciones()
        {
            OperacionClasificaciones = NULL; //ASIGNAR "NULO" A OPERACION ACTUAL
            panelClasificacion.Visible = false; //HACER INVISIBLE PANEL
            dgvClasificaciones.Height = 374; //AGRANDAR DATAGRID
            btnNuevoClasificacion.Visible = true; //HACER VISIBLE BOTON NUEVO
            btnModificarClasificacion.Visible = true; //HACER VISIBLE BOTON MODIFICAR
            txtDescripcionClasificacion.Clear(); //LIMPIAR TEXTBOX
        }

        private void CerrarPanelGeneros()
        {
            OperacionGeneros = NULL; //ASIGNAR "NULO" A OPERACION ACTUAL
            panelGenero.Visible = false; //HACER INVISIBLE PANEL
            dgvGeneros.Height = 374; //AGRANDAR DATAGRID
            btnNuevoGenero.Visible = true; //HACER VISIBLE BOTON
            btnModificarGenero.Visible = true;
            txtDescripcionGenero.Clear();
        }

        private void btnVolverClasificacion_Click(object sender, EventArgs e)
        {
            CerrarPanelClasificaciones(); //CERRAR EL PANEL DE CLASIFICACIONES
        }

        private void btnNuevoClasificacion_Click(object sender, EventArgs e)
        {
            OperacionClasificaciones = NUEVO; //INDICAR OPERACION ACTUAL DE CLASIFICACIONES COMO "NUEVO"
            AbrirPanelClasificaciones(); //ABRIR EL PANEL
            txtDescripcionClasificacion.Focus(); //PONER FOCO AL TEXTBOX
        }

        private void btnModificarClasificacion_Click(object sender, EventArgs e)
        {
            OperacionClasificaciones = MODIFICAR; //INDICAR OPERACION ACTUAL DE CLASIFICAICONES COMO "MODIFICAR"
            AbrirPanelClasificaciones(); //ABRIR PANEL
            txtDescripcionClasificacion.Text = dgvClasificaciones.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO QUE ESTE SELECCIONADO
            txtDescripcionClasificacion.Focus(); //DARLE FOCO AL TEXTBOX
            txtDescripcionClasificacion.SelectAll(); //SELECCIONAR TODO EL TEXTO
        }

        private void dgvClasificaciones_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionClasificaciones == MODIFICAR) //SI LA OPERACION ACTUAL DE CLASFICACIONES ES "MODIFICAR"...
            {
                try
                {
                    txtDescripcionClasificacion.Text = dgvClasificaciones.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL NUEVO REGISTRO SELECCIONADO
                    txtDescripcionClasificacion.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionClasificacion.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
                catch(Exception ex) { }
            }
        }

        private void btnGuardarClasificacion_Click(object sender, EventArgs e)
        {
            if(txtDescripcionClasificacion.TextLength != 0) //SI EL TEXTBOX NO ESTA VACIO...
            {
                if (OperacionClasificaciones == NUEVO) //SI LA OPERACION ES "NUEVO"
                {
                    int NuevoCodigo = Int32.Parse(DTClasificaciones.Compute("MAX(CodClasificacion_Clas)", "").ToString()) + 1; //GENERAR NUEVO CODIGO OBTENIENDO EL ULTIMO REGISTRADO + 1

                    comando = new SqlCommand("INSERT INTO Clasificaciones (CodClasificacion_Clas, Descripcion_Clas) VALUES ("+NuevoCodigo+", '"+txtDescripcionClasificacion.Text+"')", BD.getSqlCn()); //GENERAR CONSULTA
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvClasificaciones(); //ACTUALIZAR DATAGRID CLASIFICACIONES

                    seleccionarClasificacion(NuevoCodigo.ToString()); //SELECCIONAR EL NUEVO REGISTRO

                    txtDescripcionClasificacion.Clear(); //LIMPIAR EL TEXTBOX
                    txtDescripcionClasificacion.Focus(); //DARLE FOCO AL TEXTBOX
                }

                if (OperacionClasificaciones == MODIFICAR) //SI LA OPERACION ES "MODIFICAF"
                {
                    String CurrentCode = dgvClasificaciones.CurrentRow.Cells[0].Value.ToString(); //OBTENER EL CODIGO DE LA FILA SELECCIONADA

                    comando = new SqlCommand("UPDATE Clasificaciones SET Descripcion_Clas = '" + txtDescripcionClasificacion.Text + "' WHERE CodClasificacion_Clas = " + CurrentCode, BD.getSqlCn()); //GENERAR CONSULTA
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvClasificaciones(); //ACTUALIZAR DATAGRID CLASIFICACIONES

                    seleccionarClasificacion(CurrentCode); //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO

                    txtDescripcionClasificacion.Text = dgvClasificaciones.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO
                    txtDescripcionClasificacion.Focus(); //DARLE FOCO AL TEXTO
                    txtDescripcionClasificacion.SelectAll(); //SELECCIONAR TOOD EL TEXTO
                }
            }
            else //SI EL TEXTBOX ESTA VACIO...
            {
                MessageBox.Show("El nombre no puede quedar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolverGenero_Click(object sender, EventArgs e)
        {
            CerrarPanelGeneros(); //CERRAR PANEL DE GENEROS
        }

        private void btnNuevoGenero_Click(object sender, EventArgs e)
        {
            OperacionGeneros = NUEVO; //INDICAR OPERACION ACTUAL DE GENEROS COMO "NUEVO"
            AbrirPanelGeneros(); //ABRIR PANEL DE GENEROS
            txtDescripcionGenero.Focus(); //DARLE FOCO AL TEXTBOX
        }

        private void btnModificarGenero_Click(object sender, EventArgs e)
        {
            OperacionGeneros = MODIFICAR; //INDICAR OPERACION ACTUAL DE GENEROS COMO "MODIFICAR"
            AbrirPanelGeneros(); //ABRIR PANEL DE GENEROS
            txtDescripcionGenero.Text = dgvGeneros.CurrentRow.Cells[1].Value.ToString(); //LLENAR TEXTBOX CON EL GENERO SELECCIONADO
            txtDescripcionGenero.Focus(); //DARLE FOCO AL TEXTBOX
            txtDescripcionGenero.SelectAll(); //SELECCIONAR TODO EL TEXTO
        }

        private void dgvGeneros_SelectionChanged(object sender, EventArgs e)
        {
            if (OperacionGeneros == MODIFICAR) //SI LA OPERACION ACTUAL DE GENEROS ES "MODIFICAR"
            {
                try
                {
                    txtDescripcionGenero.Text = dgvGeneros.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTO CON EL GENERO SELECCIONADO
                    txtDescripcionGenero.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionGenero.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
                catch (Exception ex) { }
            }
        }

        private void btnGuardarGenero_Click(object sender, EventArgs e)
        {
            if(txtDescripcionGenero.TextLength != 0) //SI EL TEXTBOX NO ESTA VACIO...
            {
                if(OperacionGeneros == NUEVO) //SI LA OPERACION ACTUAL DE GENEROS ES "NUEVO"
                {
                    int NuevoCodigo = Int32.Parse(DTGeneros.Compute("MAX(CodGenero_Gene)", "").ToString()) + 1; //GENERAR NUEVO CODIGO OBTENIENDO EL ULTIMO REGISTRADO + 1

                    comando = new SqlCommand("INSERT INTO Generos (CodGenero_Gene, Descripcion_Gene) VALUES (" + NuevoCodigo + ", '" + txtDescripcionGenero.Text + "')", BD.getSqlCn()); //GENERAR CONSULTA
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvGeneros(); //ACTUALIZAR DATAGRID GENEROS

                    seleccionarGenero(NuevoCodigo.ToString()); //SELECCIONAR EL NUEVO REGISTRO

                    txtDescripcionGenero.Clear(); //LIMPIAR TEXTBOX
                    txtDescripcionGenero.Focus(); //DARLE FOCO AL TEXTBOX
                }

                if(OperacionGeneros == MODIFICAR) //SI LA OPERACION ACTUAL DE GENEROS ES "MODIFICAR"
                {
                    String CurrentCode = dgvGeneros.CurrentRow.Cells[0].Value.ToString(); //GUARDAR EL CODIGO DE LA FILA ACTUAL

                    comando = new SqlCommand("UPDATE Generos SET Descripcion_Gene = '" + txtDescripcionGenero.Text + "' WHERE CodGenero_Gene = " + CurrentCode, BD.getSqlCn()); //GENERAR CONSULTA
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvGeneros(); //ACTUALIZAR DATAGIRD GENEROS

                    seleccionarGenero(CurrentCode); //SELECCIONAR EL REGISTRO MODIFICADO

                    txtDescripcionGenero.Text = dgvGeneros.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
                    txtDescripcionGenero.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionGenero.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
            }
            else //SI EL TEXTBOX ESTA VACIO...
            {
                MessageBox.Show("El nombre no puede quedar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void seleccionarClasificacion(String codigo)
        {
            for(int i=0; i<dgvClasificaciones.RowCount; i++) //RECORRER TODAS LAS CLASIFICACIONES
            {
                if(dgvClasificaciones.Rows[i].Cells[0].Value.ToString() == codigo) //SI EL CODIGO DE LA FILA COINCIDE CON EL CODIGO BUSCADO
                {
                    dgvClasificaciones.CurrentCell = dgvClasificaciones.Rows[i].Cells[1]; //SELECCIONAR FILA
                    dgvClasificaciones.Rows[i].Selected = true; //SELECCIONAR FILA
                }
            }
        }

        private void seleccionarGenero(String codigo)
        {
            for (int i = 0; i < dgvGeneros.RowCount; i++) //RECORRER TODOS LOS GENEROS
            {
                if (dgvGeneros.Rows[i].Cells[0].Value.ToString() == codigo) //SI EL CODIGO DE LA FILA COINCIDE CON EL CODIGO BUSCADO
                {
                    dgvGeneros.CurrentCell = dgvGeneros.Rows[i].Cells[1]; //SELECCIONAR FILA
                    dgvGeneros.Rows[i].Selected = true; //SELECCIONAR FILA
                }
            }
        }
    }
}
