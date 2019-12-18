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
using Proyecto_Cine.Clases.Entidades;
using Proyecto_Cine.Clases.INegocio;
using Proyecto_Cine.Clases.Negocio;

namespace Proyecto_Cine.Forms
{
    public partial class Salas : Form
    {
        private ITipoDeSalaNeg tiposalaNeg = new TipoDeSalaNeg();
        private ISalaNeg salaNeg = new SalaNeg();
        private ICineNeg cineNeg = new CineNeg();
        private DataTable dtTDS;
        private DataTable dtTDS2;
        private DataTable dtSalas;
        private DataTable dtCines;

        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2;

        private int OperacionTDS = NULL;
        private int OperacionSalas = NULL;

        public Salas()
        {
            InitializeComponent();
            IniciarDtTDS();
            IniciarDtTDS2();
            IniciarDtSalas();
            IniciarDtCines();
            
            if(!ActualizarDgvTDS())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipo de salas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxCines())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Cines", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(!ActualizarDgvSalas())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Salas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxTDS())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipo de salas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigurarGrids();
        }

        private void IniciarDtTDS()
        {
            dtTDS = new DataTable();
            dtTDS.Columns.Add("Codigo");
            dtTDS.Columns.Add("Descripcion");
            dgvTDS.DataSource = dtTDS;
        }

        private void IniciarDtTDS2()
        {
            dtTDS2 = new DataTable();
            dtTDS2.Columns.Add("Codigo");
            dtTDS2.Columns.Add("Descripcion");
            boxTDS.DataSource = dtTDS2;
        }

        private void IniciarDtSalas()
        {
            dtSalas = new DataTable();
            dtSalas.Columns.Add("Codigo Cine");
            dtSalas.Columns.Add("Codigo Sala");
            dtSalas.Columns.Add("Descripcion");
            dtSalas.Columns.Add("Codigo Tipo de sala");
            dtSalas.Columns.Add("Tipo de sala");
            dtSalas.Columns.Add("Estado");
            dgvSalas.DataSource = dtSalas;
        }

        private void IniciarDtCines()
        {
            dtCines = new DataTable();
            dtCines.Columns.Add("Codigo");
            dtCines.Columns.Add("Nombre");
            boxCines.DataSource = dtCines;
        }

        private bool ActualizarDgvTDS()
        {
            List<TipoDeSala> lista = tiposalaNeg.obtenerTodos();
            if (lista == null) return false;

            dtTDS.Clear();

            foreach(TipoDeSala tipo in lista)
            {
                DataRow row = dtTDS.NewRow();
                row[0] = tipo.getId();
                row[1] = tipo.getDescripcion();
                dtTDS.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarBoxCines()
        {
            dtCines.Clear();

            DataRow firstRow = dtCines.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SELECCIONE ---";
            dtCines.Rows.Add(firstRow);

            List<Cine> lista = cineNeg.obtenerTodos();
            if (lista == null) return false;

            foreach(Cine cine in lista)
            {
                DataRow row = dtCines.NewRow();
                row[0] = cine.getId();
                row[1] = cine.getNombre();
                dtCines.Rows.Add(row);
            }

            boxCines.DisplayMember = "Nombre";
            boxCines.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarDgvSalas()
        {
            List<Sala> lista = salaNeg.obtenerTodas(Int32.Parse(boxCines.SelectedValue.ToString()));
            if (lista == null) return false;

            dtSalas.Clear();

            foreach(Sala sala in lista)
            {
                DataRow row = dtSalas.NewRow();
                row[0] = sala.getCine().getId();
                row[1] = sala.getId();
                row[2] = sala.getDescripcion();
                row[3] = sala.getTipo().getId();
                row[4] = sala.getTipo().getDescripcion();
                row[5] = sala.getEstado();
                dtSalas.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarBoxTDS()
        {
            dtTDS2.Clear();

            DataRow firstRow = dtTDS2.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SELECCIONE ---";
            dtTDS2.Rows.Add(firstRow);

            List<TipoDeSala> lista = tiposalaNeg.obtenerTodos();
            if (lista == null) return false;

            foreach (TipoDeSala tipo in lista)
            {
                DataRow row = dtTDS2.NewRow();
                row[0] = tipo.getId();
                row[1] = tipo.getDescripcion();
                dtTDS2.Rows.Add(row);
            }

            boxTDS.DisplayMember = "Descripcion";
            boxTDS.ValueMember = "Codigo";

            return true;
        }

        private void ConfigurarGrids()
        {
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

            dgvSalas.Height = 350;
            dgvSalas.Columns[0].Visible = false;
            dgvSalas.Columns[1].Visible = false;
            dgvSalas.Columns[3].Visible = false;
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
        }

        private void AbrirPanelTDS()
        {
            btnNuevoTDS.Visible = false;
            btnModificarTDS.Visible = false;
            dgvTDS.Height = 283;
            PanelTDS.Visible = true;
        }

        private void CerrarPanelTDS()
        {
            PanelTDS.Visible = false;
            txtDescripcionTDS.Clear();
            dgvTDS.Height = 377;
            btnNuevoTDS.Visible = true;
            btnModificarTDS.Visible = true;
            OperacionTDS = NULL;
        }

        private void AbrirPanelSalas()
        {
            btnNuevoSalas.Visible = false;
            btnModificarSalas.Visible = false;
            dgvSalas.Height = 256;
            PanelSalas.Visible = true;
        }

        private void CerrarPanelSalas()
        {
            PanelSalas.Visible = false;
            txtDescripcionSalas.Clear();
            boxTDS.SelectedIndex = 0;
            checkSala.Checked = true;
            dgvSalas.Height = 350;
            btnNuevoSalas.Visible = true;
            btnModificarSalas.Visible = true;
            OperacionSalas = NULL;
        }

        private void btnNuevoTDS_Click(object sender, EventArgs e)
        {
            OperacionTDS = NUEVO;
            AbrirPanelTDS();
            txtDescripcionTDS.Focus();
        }

        private void btnModificarTDS_Click(object sender, EventArgs e)
        {
            if(dgvTDS.RowCount != 0)
            {
                OperacionTDS = MODIFICAR;
                AbrirPanelTDS();

                txtDescripcionTDS.Text = dgvTDS.CurrentRow.Cells[1].Value.ToString();
                txtDescripcionTDS.Focus();
                txtDescripcionTDS.SelectAll();
            }
        }

        private void btnVolverTDS_Click(object sender, EventArgs e)
        {
            CerrarPanelTDS();
        }

        private void btnNuevoSalas_Click(object sender, EventArgs e)
        {
            OperacionSalas = NUEVO;
            AbrirPanelSalas();
            txtDescripcionSalas.Focus();
        }

        private void btnModificarSalas_Click(object sender, EventArgs e)
        {
            if(dgvSalas.RowCount != 0)
            {
                OperacionSalas = MODIFICAR;
                AbrirPanelSalas();

                boxTDS.SelectedValue = dgvSalas.CurrentRow.Cells[3].Value;
                txtDescripcionSalas.Text = dgvSalas.CurrentRow.Cells[2].Value.ToString();
                txtDescripcionSalas.Focus();
                txtDescripcionSalas.SelectAll();
                checkSala.Checked = bool.Parse(dgvSalas.CurrentRow.Cells[5].Value.ToString());
            }
        }

        private void btnVolverSalas_Click(object sender, EventArgs e)
        {
            CerrarPanelSalas();
        }

        private void boxCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDgvSalas();

            if (OperacionSalas == MODIFICAR && dgvSalas.RowCount == 0)
            {
                CerrarPanelSalas();
            }
        }

        private void dgvTDS_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionTDS == MODIFICAR && dgvTDS.CurrentRow != null)
            {   
                txtDescripcionTDS.Clear();
                txtDescripcionTDS.Text = dgvTDS.CurrentRow.Cells[1].Value.ToString();
                txtDescripcionTDS.Focus();
                txtDescripcionTDS.SelectAll();
            }
        }

        private void dgvSalas_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionSalas == MODIFICAR && dgvSalas.CurrentRow != null)
            {
                txtDescripcionSalas.Text = dgvSalas.CurrentRow.Cells[2].Value.ToString();
                txtDescripcionSalas.Focus();
                txtDescripcionSalas.SelectAll();
                boxTDS.SelectedValue = dgvSalas.CurrentRow.Cells[3].Value;
                checkSala.Checked = bool.Parse(dgvSalas.CurrentRow.Cells[5].Value.ToString());
            }
        }

        private void btnGuardarTDS_Click(object sender, EventArgs e)
        {
           
        }

        private void btnGuardarSalas_Click(object sender, EventArgs e)
        {
            
        }

        private void seleccionarFilaTDS(int codigo)
        {
            for(int i=0; i<dgvTDS.RowCount; i++)
            {
                if(dgvTDS.Rows[i].Cells[0].Value.ToString() == codigo.ToString())
                {
                    dgvTDS.CurrentCell = dgvTDS.Rows[i].Cells[1];
                    dgvTDS.Rows[i].Selected = true;
                }
            }
        }

        private void seleccionarFilaSalas(int codigo)
        {
            for(int i=0; i<dgvSalas.RowCount; i++)
            {
                if(dgvSalas.Rows[i].Cells[0].Value.ToString() == codigo.ToString())
                {
                    dgvSalas.CurrentCell = dgvSalas.Rows[i].Cells[2];
                    dgvSalas.Rows[i].Selected = true;
                }
            }
        }
    }
}
