using Proyecto_Cine.Clases.INegocio;
using Proyecto_Cine.Clases.Negocio;
using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cine.Forms
{
    public partial class Funciones : Form
    {
        private ICineNeg cineNeg = new CineNeg();
        private ISalaNeg salaNeg = new SalaNeg();
        private IPeliculaNeg peliculaNeg = new PeliculaNeg();
        private IPeliculaPorFormatoNeg pxfNeg = new PeliculaPorFormatoNeg();
        private IFuncionNeg funcionNeg = new FuncionNeg();
        private DataTable dtCines_A;
        private DataTable dtSalas_A;
        private DataTable dtPeliculas_A;
        private DataTable dtFormatos_A;
        private DataTable dtCines_B;
        private DataTable dtSalas_B;
        private DataTable dtPeliculas_B;
        private DataTable dtFormatos_B;
        private DataTable dtFunciones;

        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2;
        private bool Guardando = false;

        private int OperacionActual = NULL;

        public Funciones()
        {
            InitializeComponent();
            IniciarDtCines();
            IniciarDtSalas();
            IniciarDtPeliculas();
            IniciarDtFormatos();
            IniciarDtFunciones();

            if(!ActualizarBoxCines_A())
            {
                MessageBox.Show("Error al cargar la lista de cines de la barra superior de busqueda.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(!ActualizarBoxSalas_A())
                {
                    MessageBox.Show("Error al cargar la lista de salas de la barra superior de busqueda.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!ActualizarBoxPeliculas_A())
            {
                MessageBox.Show("Error al cargar la lista de peliculas de la barra superior de busqueda.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(!ActualizarBoxFormatos_A())
                {
                    MessageBox.Show("Error al cargar la lista de formatos de la barra superior de busqueda.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!ActualizarBoxCines_B())
            {
                MessageBox.Show("Error al cargar la lista de cines de la barra inferior.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!ActualizarBoxSalas_B())
                {
                    MessageBox.Show("Error al cargar la lista de salas de la barra inferior.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!ActualizarBoxPeliculas_B())
            {
                MessageBox.Show("Error al cargar la lista de peliculas de la barra inferior.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!ActualizarBoxFormatos_B())
                {
                    MessageBox.Show("Error al cargar la lista de formatos de la barra inferior.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if(!ActualizarDgvFunciones())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar el listado de Funciones", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigurarGrid();
        }

        private void IniciarDtCines()
        {
            dtCines_A = new DataTable();
            dtCines_A.Columns.Add("Codigo");
            dtCines_A.Columns.Add("Nombre");
            boxCines.DataSource = dtCines_A;

            dtCines_B = new DataTable();
            dtCines_B.Columns.Add("Codigo");
            dtCines_B.Columns.Add("Nombre");
            PboxCines.DataSource = dtCines_B;
        }

        private void IniciarDtSalas()
        {
            dtSalas_A = new DataTable();
            dtSalas_A.Columns.Add("Codigo");
            dtSalas_A.Columns.Add("Nombre");
            boxSalas.DataSource = dtSalas_A;

            dtSalas_B = new DataTable();
            dtSalas_B.Columns.Add("Codigo");
            dtSalas_B.Columns.Add("Nombre");
            PboxSalas.DataSource = dtSalas_B;
        }

        private void IniciarDtPeliculas()
        {
            dtPeliculas_A = new DataTable();
            dtPeliculas_A.Columns.Add("Codigo");
            dtPeliculas_A.Columns.Add("Nombre");
            boxPeliculas.DataSource = dtPeliculas_A;

            dtPeliculas_B = new DataTable();
            dtPeliculas_B.Columns.Add("Codigo");
            dtPeliculas_B.Columns.Add("Nombre");
            PboxPeliculas.DataSource = dtPeliculas_B;
        }

        private void IniciarDtFormatos()
        {
            dtFormatos_A = new DataTable();
            dtFormatos_A.Columns.Add("Codigo");
            dtFormatos_A.Columns.Add("Nombre");
            boxFormatos.DataSource = dtFormatos_A;

            dtFormatos_B = new DataTable();
            dtFormatos_B.Columns.Add("Codigo");
            dtFormatos_B.Columns.Add("Nombre");
            PboxFormatos.DataSource = dtFormatos_B;
        }

        private void IniciarDtFunciones()
        {
            dtFunciones = new DataTable();
            dtFunciones.Columns.Add("Codigo Cine");
            dtFunciones.Columns.Add("Cine");
            dtFunciones.Columns.Add("Codigo Sala");
            dtFunciones.Columns.Add("Sala");
            dtFunciones.Columns.Add("Dia");
            dtFunciones.Columns.Add("Horario");
            dtFunciones.Columns.Add("Codigo Pelicula");
            dtFunciones.Columns.Add("Pelicula");
            dtFunciones.Columns.Add("Codigo Formato");
            dtFunciones.Columns.Add("Formato");
            dtFunciones.Columns.Add("Stock");
            dtFunciones.Columns.Add("Estado");
            dgvFunciones.DataSource = dtFunciones;
        }

        private bool ActualizarBoxCines_A()
        {
            List<Cine> lista = cineNeg.obtenerTodos();
            if (lista == null) return false;

            dtCines_A.Clear();

            DataRow firstRow = dtCines_A.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- CINES ---";
            dtCines_A.Rows.Add(firstRow);

            foreach (Cine cine in lista)
            {
                DataRow row = dtCines_A.NewRow();
                row[0] = cine.getId();
                row[1] = cine.getNombre();
                dtCines_A.Rows.Add(row);
            }

            boxCines.DisplayMember = "Nombre";
            boxCines.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxSalas_A()
        {
            List<Sala> lista = salaNeg.obtenerTodas(Int32.Parse(boxCines.SelectedValue.ToString()));
            if (lista == null) return false;

            dtSalas_A.Clear();

            DataRow firstRow = dtSalas_A.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SALAS ---";
            dtSalas_A.Rows.Add(firstRow);

            foreach (Sala sala in lista)
            {
                DataRow row = dtSalas_A.NewRow();
                row[0] = sala.getId();
                row[1] = sala.getDescripcion();
                dtSalas_A.Rows.Add(row);
            }

            boxSalas.DisplayMember = "Nombre";
            boxSalas.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxPeliculas_A()
        {
            List<Pelicula> lista = peliculaNeg.obtenerTodas();
            if (lista == null) return false;

            dtPeliculas_A.Clear();

            DataRow firstRow = dtPeliculas_A.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- PELICULAS ---";
            dtPeliculas_A.Rows.Add(firstRow);

            foreach (Pelicula pelicula in lista)
            {
                DataRow row = dtPeliculas_A.NewRow();
                row[0] = pelicula.getId();
                row[1] = pelicula.getNombre();
                dtPeliculas_A.Rows.Add(row);
            }

            boxPeliculas.DisplayMember = "Nombre";
            boxPeliculas.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxFormatos_A()
        {
            List<PeliculaPorFormato> lista = pxfNeg.obtenerTodos(Int32.Parse(boxPeliculas.SelectedValue.ToString()));
            if (lista == null) return false;

            dtFormatos_A.Clear();

            DataRow firstRow = dtFormatos_A.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- FORMATOS ---";
            dtFormatos_A.Rows.Add(firstRow);

            foreach (PeliculaPorFormato pxf in lista)
            {
                DataRow row = dtFormatos_A.NewRow();
                row[0] = pxf.getFormato().getId();
                row[1] = pxf.getFormato().getDescripcion();
                dtFormatos_A.Rows.Add(row);
            }

            boxFormatos.DisplayMember = "Nombre";
            boxFormatos.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxCines_B()
        {
            List<Cine> lista = cineNeg.obtenerTodos();
            if (lista == null) return false;

            dtCines_B.Clear();

            DataRow firstRow = dtCines_B.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- CINES ---";
            dtCines_B.Rows.Add(firstRow);

            foreach (Cine cine in lista)
            {
                DataRow row = dtCines_B.NewRow();
                row[0] = cine.getId();
                row[1] = cine.getNombre();
                dtCines_B.Rows.Add(row);
            }

            PboxCines.DisplayMember = "Nombre";
            PboxCines.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxSalas_B()
        {
            List<Sala> lista = salaNeg.obtenerTodas(Int32.Parse(PboxCines.SelectedValue.ToString()));
            if (lista == null) return false;

            dtSalas_B.Clear();

            DataRow firstRow = dtSalas_B.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SALAS ---";
            dtSalas_B.Rows.Add(firstRow);

            foreach (Sala sala in lista)
            {
                DataRow row = dtSalas_B.NewRow();
                row[0] = sala.getId();
                row[1] = sala.getDescripcion();
                dtSalas_B.Rows.Add(row);
            }

            PboxSalas.DisplayMember = "Nombre";
            PboxSalas.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxPeliculas_B()
        {
            List<Pelicula> lista = peliculaNeg.obtenerTodas();
            if (lista == null) return false;

            dtPeliculas_B.Clear();

            DataRow firstRow = dtPeliculas_B.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- PELICULAS ---";
            dtPeliculas_B.Rows.Add(firstRow);

            foreach (Pelicula pelicula in lista)
            {
                DataRow row = dtPeliculas_B.NewRow();
                row[0] = pelicula.getId();
                row[1] = pelicula.getNombre();
                dtPeliculas_B.Rows.Add(row);
            }

            PboxPeliculas.DisplayMember = "Nombre";
            PboxPeliculas.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxFormatos_B()
        {
            List<PeliculaPorFormato> lista = pxfNeg.obtenerTodos(Int32.Parse(PboxPeliculas.SelectedValue.ToString()));
            if (lista == null) return false;

            dtFormatos_B.Clear();

            DataRow firstRow = dtFormatos_B.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- FORMATOS ---";
            dtFormatos_B.Rows.Add(firstRow);

            foreach (PeliculaPorFormato pxf in lista)
            {
                DataRow row = dtFormatos_B.NewRow();
                row[0] = pxf.getFormato().getId();
                row[1] = pxf.getFormato().getDescripcion();
                dtFormatos_B.Rows.Add(row);
            }

            PboxFormatos.DisplayMember = "Nombre";
            PboxFormatos.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarDgvFunciones()
        {
            List<Funcion> lista = funcionNeg.obtenerTodas();
            if (lista == null) return false;

            dtFunciones.Clear();

            foreach(Funcion funcion in lista)
            {
                DataRow row = dtFunciones.NewRow();
                row[0] = funcion.getCine().getId();
                row[1] = funcion.getCine().getNombre();
                row[2] = funcion.getSala().getId();
                row[3] = funcion.getSala().getDescripcion();
                row[4] = funcion.getFecha().ToString();
                row[5] = funcion.getHorario().ToString();
                row[6] = funcion.getPelicula().getId();
                row[7] = funcion.getPelicula().getNombre();
                row[8] = funcion.getFormato().getId();
                row[9] = funcion.getFormato().getDescripcion();
                row[10] = funcion.getStock();
                row[11] = funcion.getEstado();
                dtFunciones.Rows.Add(row);
            }

            return true;
        }

        private void ConfigurarGrid()
        {
            dgvFunciones.Height = 348;
            dgvFunciones.Columns[0].Visible = false;
            dgvFunciones.Columns[2].Visible = false;
            dgvFunciones.Columns[6].Visible = false;
            dgvFunciones.Columns[8].Visible = false;
            dgvFunciones.ReadOnly = true;
            dgvFunciones.AllowUserToAddRows = false;
            dgvFunciones.RowHeadersVisible = false;
            dgvFunciones.AllowUserToResizeColumns = false;
            dgvFunciones.AllowUserToResizeRows = false;
            dgvFunciones.MultiSelect = false;
            dgvFunciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFunciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFunciones.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFunciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvFunciones.Sort(dgvFunciones.Columns[1], ListSortDirection.Ascending);
        }

        private void AbrirPanel()
        {
            dgvFunciones.Height = 253;
            panel2.Visible = true;
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
        }

        private void CerrarPanel()
        {
            OperacionActual = NULL;
            panel2.Visible = false;
            dgvFunciones.Height = 348;
            btnNuevo.Visible = true;
            btnModificar.Visible = true;
        }

        //REVISAR
        private void FiltarDatos()
        {
            //TODAS LAS COMBINACIONES POSIBLES DE LOS CHECKBOXS DEL PANEL SUPERIOR DE BUSQUEDA

            if (cbCine.Checked && cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "Codigo Cine = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "'"; }
            if (cbCine.Checked && cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "'"; }
            if (cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "\"Codigo Cine\" = " + boxCines.SelectedValue; }

            if (!cbCine.Checked && cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "'"; }
            if (!cbCine.Checked && cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "Dia_Func = '" + dtpFecha.Text + "' AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "Dia_Func = '" + dtpFecha.Text + "'"; }
            if (!cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = "CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { dtFunciones.DefaultView.RowFilter = null; }
        }

        //INCOMPLETO
        private void boxCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ActualizarBoxSalas_A())
            {
                MessageBox.Show("Error al cargar la lista de salas del cine seleccionado.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cbCine_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbSala_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbPelicula_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbFormato_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void boxSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            
        }

        //INCOMPLETO
        private void boxPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!ActualizarBoxFormatos_A())
            {
                MessageBox.Show("Error al cargar la lista de formatos de la pelicula seleccionada.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void boxFormatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void limpiarCajas()
        {
            PboxCines.SelectedIndex = 0;
            PboxSalas.SelectedIndex = 0;
            PboxPeliculas.SelectedIndex = 0;
            PboxFormatos.SelectedIndex = 0;
            PdtpFecha.Value = DateTime.Today;
            PtxtHora.Clear();
            PtxtMinutos.Clear();
            PtxtStock.Clear();
            PcbEstado.Checked = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OperacionActual = NUEVO;
            limpiarCajas();
            AbrirPanel();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvFunciones.RowCount > 0)
            {
                OperacionActual = MODIFICAR;
                AbrirPanel();
                ActualizarContenedores();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel();
        }

        private void PboxCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ActualizarBoxSalas_B())
            {
                MessageBox.Show("Error al cargar la lista de salas del cine seleccionado.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PboxPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ActualizarBoxFormatos_B())
            {
                MessageBox.Show("Error al cargar la lista de formatos de la pelicula seleccionada.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarContenedores()
        {   
            if(OperacionActual == MODIFICAR && Guardando != true)
            {
                PboxCines.SelectedValue = dgvFunciones.CurrentRow.Cells[0].Value;
                PboxSalas.SelectedValue = dgvFunciones.CurrentRow.Cells[2].Value;
                PboxPeliculas.SelectedValue = dgvFunciones.CurrentRow.Cells[6].Value;
                PboxFormatos.SelectedValue = dgvFunciones.CurrentRow.Cells[8].Value;
                PdtpFecha.Value = DateTime.Parse(dgvFunciones.CurrentRow.Cells[4].Value.ToString());

                string Horario = dgvFunciones.CurrentRow.Cells[5].Value.ToString();
                string[] partes = Horario.Split(':');
                PtxtHora.Text = partes[0];
                PtxtMinutos.Text = partes[1];

                PtxtStock.Text = dgvFunciones.CurrentRow.Cells[10].Value.ToString();
                PcbEstado.Checked = bool.Parse(dgvFunciones.CurrentRow.Cells[11].Value.ToString());
            }
        }

        private void dgvFunciones_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarContenedores();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(PboxCines.SelectedIndex != 0)
            {
                if(PboxSalas.SelectedIndex != 0)
                {
                    if(PboxPeliculas.SelectedIndex != 0)
                    {
                        if (PboxFormatos.SelectedIndex != 0)
                        {
                            if (PtxtHora.TextLength != 0 && PtxtMinutos.TextLength != 0)
                            {
                                if (PtxtStock.TextLength != 0)
                                {
                                    Guardando = true;

                                    Cine cine = new Cine();
                                    cine.setId(Int32.Parse(PboxCines.SelectedValue.ToString()));

                                    Sala sala = new Sala();
                                    sala.setId(Int32.Parse(PboxSalas.SelectedValue.ToString()));

                                    Pelicula pelicula = new Pelicula();
                                    pelicula.setId(Int32.Parse(PboxPeliculas.SelectedValue.ToString()));

                                    Formato formato = new Formato();
                                    formato.setId(Int32.Parse(PboxFormatos.SelectedValue.ToString()));

                                    Fecha fecha = new Fecha(PdtpFecha.Text);
                                    Horario horario = new Horario(PtxtHora.Text + ":" + PtxtMinutos.Text);

                                    Funcion funcion = new Funcion();
                                    funcion.setCine(cine);
                                    funcion.setSala(sala);
                                    funcion.setPelicula(pelicula);
                                    funcion.setFormato(formato);
                                    funcion.setFecha(fecha);
                                    funcion.setHorario(horario);
                                    funcion.setStock(Int32.Parse(PtxtStock.Text));
                                    funcion.setEstado(PcbEstado.Checked);

                                    if (OperacionActual == NUEVO)
                                    {
                                        if (!funcionNeg.comprobarExistencia(funcion))
                                        {
                                            if (funcionNeg.agregar(funcion))
                                            {
                                                MessageBox.Show("Se ha agregado la funcion con exito.", "Funcion agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                if (ActualizarDgvFunciones())
                                                {
                                                    seleccionarFila(funcion);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No se ha podido actualizar la lista de Funciones.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ya existe una funcion con los datos seleccionados.", "Superposicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }

                                    if (OperacionActual == MODIFICAR)
                                    {
                                        Cine cineold = new Cine();
                                        cineold.setId(Int32.Parse(dgvFunciones.CurrentRow.Cells[0].Value.ToString()));

                                        Sala salaold = new Sala();
                                        salaold.setId(Int32.Parse(dgvFunciones.CurrentRow.Cells[2].Value.ToString()));

                                        Fecha fechaold = new Fecha(dgvFunciones.CurrentRow.Cells[4].Value.ToString(), 0);
                                        Horario horarioold = new Horario(dgvFunciones.CurrentRow.Cells[5].Value.ToString());

                                        Funcion old = new Funcion();
                                        old.setCine(cineold);
                                        old.setSala(salaold);
                                        old.setFecha(fechaold);
                                        old.setHorario(horarioold);

                                        if(funcion.Equals(old))
                                        {
                                            if (funcionNeg.modificar(funcion, old))
                                            {
                                                MessageBox.Show("Se ha modificado la funcion con exito.", "Funcion modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                if (ActualizarDgvFunciones())
                                                {
                                                    seleccionarFila(funcion);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No se ha podido actualizar la lista de Funciones.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            if (!funcionNeg.comprobarExistencia(funcion))
                                            {
                                                if (funcionNeg.modificar(funcion, old))
                                                {
                                                    MessageBox.Show("Se ha modificado la funcion con exito.", "Funcion modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    if (ActualizarDgvFunciones())
                                                    {
                                                        seleccionarFila(funcion);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("No se ha podido actualizar la lista de Funciones.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Ya existe una funcion con los datos seleccionados.", "Superposicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                    }

                                    Guardando = false;
                                }
                                else
                                {
                                    MessageBox.Show("Por favor indique la cantidad de entradas en stock.", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor complete el horario de la funcion indicando horas y minutos.", "Horario incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor seleccione un formato para la pelicula.", "Sin formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione una pelicula para la funcion.", "Sin pelicula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una sala para la funcion.", "Sin sala", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cine para la funcion.", "Sin cine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void seleccionarFila(Funcion funcion)
        {
            for(int i=0; i<dgvFunciones.RowCount; i++)
            {
                if(dgvFunciones.Rows[i].Cells[0].Value.ToString() == funcion.getCine().getId().ToString())
                {
                    if(dgvFunciones.Rows[i].Cells[2].Value.ToString() == funcion.getSala().getId().ToString())
                    {
                        if(dgvFunciones.Rows[i].Cells[4].Value.ToString() == funcion.getFecha().ToString())
                        {
                            if(dgvFunciones.Rows[i].Cells[5].Value.ToString() == funcion.getHorario().ToString())
                            {
                                dgvFunciones.CurrentCell = dgvFunciones.Rows[i].Cells[1];
                                dgvFunciones.Rows[i].Selected = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
