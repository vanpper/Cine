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
        }

        private void ActualizarDgvClasificaciones()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Clasificaciones", BD.conectarBD); //TRAER TODAS LAS CLASFICACIONES
            DTClasificaciones.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTClasificaciones); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void ActualizarDgvGeneros()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Generos", BD.conectarBD); //TRAER TODOS LOS GENEROS
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
            CerrarPanelClasificaciones();
        }

        private void btnNuevoClasificacion_Click(object sender, EventArgs e)
        {
            OperacionClasificaciones = NUEVO;
            AbrirPanelClasificaciones();
            txtDescripcionClasificacion.Focus();
        }

        private void btnModificarClasificacion_Click(object sender, EventArgs e)
        {
            OperacionClasificaciones = MODIFICAR;
            AbrirPanelClasificaciones();
            txtDescripcionClasificacion.Text = dgvClasificaciones.CurrentRow.Cells[1].Value.ToString();
            txtDescripcionClasificacion.Focus();
            txtDescripcionClasificacion.SelectAll();
        }

        private void dgvClasificaciones_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionClasificaciones == MODIFICAR)
            {
                try
                {
                    txtDescripcionClasificacion.Text = dgvClasificaciones.CurrentRow.Cells[1].Value.ToString();
                    txtDescripcionClasificacion.Focus();
                    txtDescripcionClasificacion.SelectAll();
                }
                catch(Exception ex) { }
            }
        }

        private void btnGuardarClasificacion_Click(object sender, EventArgs e)
        {
            if(txtDescripcionClasificacion.TextLength != 0)
            {
                if (OperacionClasificaciones == NUEVO)
                {
                    int NuevoCodigo = Int32.Parse(DTClasificaciones.Compute("MAX(CodClasificacion_Clas)", "").ToString()) + 1;

                    comando = new SqlCommand("INSERT INTO Clasificaciones (CodClasificacion_Clas, Descripcion_Clas) VALUES ("+NuevoCodigo+", '"+txtDescripcionClasificacion.Text+"')", BD.conectarBD);
                    comando.ExecuteNonQuery();

                    ActualizarDgvClasificaciones();

                    dgvClasificaciones.CurrentCell = dgvClasificaciones.Rows[dgvClasificaciones.RowCount - 1].Cells[1];
                    dgvClasificaciones.Rows[dgvClasificaciones.RowCount - 1].Selected = true;

                    txtDescripcionClasificacion.Clear();
                    txtDescripcionClasificacion.Focus();
                }

                if (OperacionClasificaciones == MODIFICAR)
                {
                    int CurrentIndex = dgvClasificaciones.CurrentRow.Index;

                    comando = new SqlCommand("UPDATE Clasificaciones SET Descripcion_Clas = '"+txtDescripcionClasificacion.Text+"' WHERE CodClasificacion_Clas = "+dgvClasificaciones.CurrentRow.Cells[0].Value, BD.conectarBD);
                    comando.ExecuteNonQuery();

                    ActualizarDgvClasificaciones();

                    dgvClasificaciones.CurrentCell = dgvClasificaciones.Rows[CurrentIndex].Cells[1];
                    dgvClasificaciones.Rows[CurrentIndex].Selected = true;

                    txtDescripcionClasificacion.Text = dgvClasificaciones.CurrentRow.Cells[1].Value.ToString();
                    txtDescripcionClasificacion.Focus();
                    txtDescripcionClasificacion.SelectAll();
                }
            }
        }

        private void btnVolverGenero_Click(object sender, EventArgs e)
        {
            CerrarPanelGeneros();
        }

        private void btnNuevoGenero_Click(object sender, EventArgs e)
        {
            OperacionGeneros = NUEVO;
            AbrirPanelGeneros();
            txtDescripcionGenero.Focus();
        }

        private void btnModificarGenero_Click(object sender, EventArgs e)
        {
            OperacionGeneros = MODIFICAR;
            AbrirPanelGeneros();
            txtDescripcionGenero.Text = dgvGeneros.CurrentRow.Cells[1].Value.ToString();
            txtDescripcionGenero.Focus();
            txtDescripcionGenero.SelectAll();
        }

        private void dgvGeneros_SelectionChanged(object sender, EventArgs e)
        {
            if (OperacionGeneros == MODIFICAR)
            {
                try
                {
                    txtDescripcionGenero.Text = dgvGeneros.CurrentRow.Cells[1].Value.ToString();
                    txtDescripcionGenero.Focus();
                    txtDescripcionGenero.SelectAll();
                }
                catch (Exception ex) { }
            }
        }

        private void btnGuardarGenero_Click(object sender, EventArgs e)
        {
            if(txtDescripcionGenero.TextLength != 0)
            {
                if(OperacionGeneros == NUEVO)
                {
                    int NuevoCodigo = Int32.Parse(DTGeneros.Compute("MAX(CodGenero_Gene)", "").ToString()) + 1;

                    comando = new SqlCommand("INSERT INTO Generos (CodGenero_Gene, Descripcion_Gene) VALUES (" + NuevoCodigo + ", '" + txtDescripcionGenero.Text + "')", BD.conectarBD);
                    comando.ExecuteNonQuery();

                    ActualizarDgvGeneros();

                    dgvGeneros.CurrentCell = dgvGeneros.Rows[dgvGeneros.RowCount - 1].Cells[1];
                    dgvGeneros.Rows[dgvGeneros.RowCount - 1].Selected = true;

                    txtDescripcionGenero.Clear();
                    txtDescripcionGenero.Focus();
                }

                if(OperacionGeneros == MODIFICAR)
                {
                    int CurrentIndex = dgvGeneros.CurrentRow.Index;

                    comando = new SqlCommand("UPDATE Generos SET Descripcion_Gene = '" + txtDescripcionGenero.Text + "' WHERE CodGenero_Gene = " + dgvGeneros.CurrentRow.Cells[0].Value, BD.conectarBD);
                    comando.ExecuteNonQuery();

                    ActualizarDgvGeneros();

                    dgvGeneros.CurrentCell = dgvGeneros.Rows[CurrentIndex].Cells[1];
                    dgvGeneros.Rows[CurrentIndex].Selected = true;

                    txtDescripcionGenero.Text = dgvGeneros.CurrentRow.Cells[1].Value.ToString();
                    txtDescripcionGenero.Focus();
                    txtDescripcionGenero.SelectAll();
                }
            }
        }
    }
}
