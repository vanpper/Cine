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
using System.IO;
using Proyecto_Cine.Clases.INegocio;
using Proyecto_Cine.Clases.Negocio;
using Proyecto_Cine.Clases.Entidades;

namespace Proyecto_Cine.Forms
{
    public partial class Peliculas : Form
    {
        private IPeliculaNeg peliculaNeg = new PeliculaNeg();
        private IClasificacionNeg clasificacionNeg = new ClasificacionNeg();
        private IGeneroNeg generoNeg = new GeneroNeg();
        private DataTable dtPeliculas;
        private DataTable dtClasificaciones;
        private DataTable dtGeneros;

        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2;
        
        private int OperacionActual = NULL;
        private bool Guardando = false;

        public Peliculas()
        {
            InitializeComponent();
            IniciarDtPeliculas();
            IniciarDtClasificaciones();
            IniciarDtGeneros();

            if (!ActualizarBoxClasificaciones())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Clasificaciones", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxGeneros())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Generos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarDgvPeliculas())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Peliculas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigurarGrids();
        }

        private void IniciarDtPeliculas()
        {
            dtPeliculas = new DataTable();
            dtPeliculas.Columns.Add("Codigo Pelicula");
            dtPeliculas.Columns.Add("Nombre");
            dtPeliculas.Columns.Add("Duracion");
            dtPeliculas.Columns.Add("Actores");
            dtPeliculas.Columns.Add("Director");
            dtPeliculas.Columns.Add("Codigo Genero");
            dtPeliculas.Columns.Add("Codigo Clasificacion");
            dtPeliculas.Columns.Add("Descripcion");
            dtPeliculas.Columns.Add("Portada", typeof(byte[]));
            dtPeliculas.Columns.Add("Estado");
            dgvPeliculas.DataSource = dtPeliculas;
        }

        private void IniciarDtClasificaciones()
        {
            dtClasificaciones = new DataTable();
            dtClasificaciones.Columns.Add("Codigo");
            dtClasificaciones.Columns.Add("Descripcion");
            boxClasificacion.DataSource = dtClasificaciones;
        }

        private void IniciarDtGeneros()
        {
            dtGeneros = new DataTable();
            dtGeneros.Columns.Add("Codigo");
            dtGeneros.Columns.Add("Descripcion");
            boxGenero.DataSource = dtGeneros;
        }

        private bool ActualizarDgvPeliculas()
        {
            List<Pelicula> lista = peliculaNeg.obtenerTodas();
            if (lista == null) return false;

            dtPeliculas.Clear();

            foreach(Pelicula pelicula in lista)
            {
                DataRow row = dtPeliculas.NewRow();
                row[0] = pelicula.getId();
                row[1] = pelicula.getNombre();
                row[2] = pelicula.getDuracion();
                row[3] = pelicula.getActores();
                row[4] = pelicula.getDirector();
                row[5] = pelicula.getGenero().getId();
                row[6] = pelicula.getClasificacion().getId();
                row[7] = pelicula.getDescripcion();
                row[8] = pelicula.getImagen();
                row[9] = pelicula.getEstado();
                dtPeliculas.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarBoxClasificaciones()
        {
            List<Clasificacion> lista = clasificacionNeg.obtenerTodas();
            if (lista == null) return false;

            dtClasificaciones.Clear();

            DataRow firstRow = dtClasificaciones.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- CLASIFICACIONES ---";
            dtClasificaciones.Rows.Add(firstRow);

            foreach (Clasificacion clasificacion in lista)
            {
                DataRow row = dtClasificaciones.NewRow();
                row[0] = clasificacion.getId();
                row[1] = clasificacion.getDescripcion();
                dtClasificaciones.Rows.Add(row);
            }

            boxClasificacion.DisplayMember = "Descripcion";
            boxClasificacion.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxGeneros()
        {
            List<Genero> lista = generoNeg.obtenerTodos();
            if (lista == null) return false;

            dtGeneros.Clear();

            DataRow firstRow = dtGeneros.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- GENEROS ---";
            dtGeneros.Rows.Add(firstRow);

            foreach (Genero genero in lista)
            {
                DataRow row = dtGeneros.NewRow();
                row[0] = genero.getId();
                row[1] = genero.getDescripcion();
                dtGeneros.Rows.Add(row);
            }

            boxGenero.DisplayMember = "Descripcion";
            boxGenero.ValueMember = "Codigo";

            return true;
        }

        private void ConfigurarGrids()
        {
            for (int i = 0; i < dgvPeliculas.ColumnCount; i++)
            {
                if (i != 1) dgvPeliculas.Columns[i].Visible = false;
            }

            dgvPeliculas.ReadOnly = true;
            dgvPeliculas.AllowUserToAddRows = false;
            dgvPeliculas.RowHeadersVisible = false;
            dgvPeliculas.AllowUserToResizeColumns = false;
            dgvPeliculas.AllowUserToResizeRows = false;
            dgvPeliculas.MultiSelect = false;
            dgvPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeliculas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPeliculas.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPeliculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeliculas.Sort(dgvPeliculas.Columns[1], ListSortDirection.Ascending);
            dgvPeliculas.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void ActualizarContenedores()
        {
            if(OperacionActual != NUEVO && dgvPeliculas.CurrentRow != null && Guardando != true)
            {
                txtNombre.Text = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
                txtDuracion.Text = dgvPeliculas.CurrentRow.Cells[2].Value.ToString();
                txtActores.Text = dgvPeliculas.CurrentRow.Cells[3].Value.ToString();
                txtDirectores.Text = dgvPeliculas.CurrentRow.Cells[4].Value.ToString();
                boxGenero.SelectedValue = dgvPeliculas.CurrentRow.Cells[5].Value;
                boxClasificacion.SelectedValue = dgvPeliculas.CurrentRow.Cells[6].Value;
                txtDescripcion.Text = dgvPeliculas.CurrentRow.Cells[7].Value.ToString();
                cbEstado.Checked = Boolean.Parse(dgvPeliculas.CurrentRow.Cells[9].Value.ToString());

                if (dgvPeliculas.CurrentRow.Cells[8].Value.ToString() != "")
                {
                    pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])dgvPeliculas.CurrentRow.Cells[8].Value));
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            try 
            {
                openFileDialog1.Title = "Seleccione una imagen";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(imagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
                Console.WriteLine(ex.Message);
                pictureBox1.Image = null;
            }
        }

        private void dgvPeliculas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarContenedores();

            if(OperacionActual == MODIFICAR) placeholderTextbox();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OperacionActual = NUEVO;

            txtNombre.ReadOnly = false;
            txtDuracion.ReadOnly = false;
            txtActores.ReadOnly = false;
            txtDirectores.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            cbEstado.Checked = true;

            txtNombre.Clear();
            txtDuracion.Clear();
            txtActores.Clear();
            txtDirectores.Clear();
            txtDescripcion.Clear();
            boxGenero.SelectedIndex = 0;
            boxClasificacion.SelectedIndex = 0;
            pictureBox1.Image = null;

            txtNombre.Text = "Nombre";
            txtDuracion.Text = "Duracion";
            txtActores.Text = "Actores";
            txtDirectores.Text = "Directores";
            txtDescripcion.Text = "Descripcion";

            txtNombre.ForeColor = Color.Gray;
            txtDuracion.ForeColor = Color.Gray;
            txtActores.ForeColor = Color.Gray;
            txtDirectores.ForeColor = Color.Gray;
            txtDescripcion.ForeColor = Color.Gray;
            this.ActiveControl = null;

            btnAgregarImagen.Visible = true;
            btnBorrarImagen.Visible = true;
            btnGuardar.Visible = true;
            btnVolver.Visible = true;
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            OperacionActual = NULL;
            ActualizarContenedores();

            txtNombre.ReadOnly = true;
            txtDuracion.ReadOnly = true;
            txtActores.ReadOnly = true;
            txtDirectores.ReadOnly = true;
            txtDescripcion.ReadOnly = true;

            btnAgregarImagen.Visible = false;
            btnBorrarImagen.Visible = false;
            btnNuevo.Visible = true;
            btnModificar.Visible = true;
            btnVolver.Visible = false;
            btnGuardar.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OperacionActual = MODIFICAR;

            txtNombre.Focus();
            txtNombre.ReadOnly = false;
            txtDuracion.ReadOnly = false;
            txtActores.ReadOnly = false;
            txtDirectores.ReadOnly = false;
            txtDescripcion.ReadOnly = false;

            placeholderTextbox();
            txtNombre.ForeColor = Color.Black;

            btnAgregarImagen.Visible = true;
            btnBorrarImagen.Visible = true;
            btnVolver.Visible = true;
            btnGuardar.Visible = true;
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.ForeColor != Color.Gray)
            {
                if(boxGenero.SelectedIndex != 0)
                {
                    if(boxClasificacion.SelectedIndex != 0)
                    {
                        Guardando = true;

                        Genero genero = new Genero();
                        genero.setId(Int32.Parse(boxGenero.SelectedValue.ToString()));

                        Clasificacion clasificacion = new Clasificacion();
                        clasificacion.setId(Int32.Parse(boxClasificacion.SelectedValue.ToString()));

                        Pelicula pelicula = new Pelicula();
                        pelicula.setId(Int32.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString()));
                        pelicula.setNombre(txtNombre.Text);
                        pelicula.setEstado(cbEstado.Checked);
                        pelicula.setGenero(genero);
                        pelicula.setClasificacion(clasificacion);

                        if(txtDuracion.ForeColor != Color.Gray) pelicula.setDuracion(Int32.Parse(txtDuracion.Text));
                        if(txtActores.ForeColor != Color.Gray) pelicula.setActores(txtActores.Text);
                        if(txtDirectores.ForeColor != Color.Gray) pelicula.setDirector(txtDirectores.Text);
                        if(txtDescripcion.ForeColor != Color.Gray) pelicula.setDescripcion(txtDescripcion.Text);


                        //pelicula.setImagen(pictureBox1.im);

                        if (OperacionActual == NUEVO)
                        {
                            if(peliculaNeg.agregar(pelicula))
                            {
                                if(ActualizarDgvPeliculas())
                                {
                                    MessageBox.Show("Se ha agregado la pelicula con exito.", "Pelicula agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    limpiarCajas();

                                    pelicula = peliculaNeg.obtenerUltima();

                                    if(pelicula != null)
                                    {
                                        seleccionarRegistro(pelicula.getId());
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ha ocurrido un error al actualizar la lista de Peliculas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        if(OperacionActual == MODIFICAR)
                        {

                        }

                        Guardando = false;
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una clasificacion para la pelicula.", "Sin clasificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un genero para la pelicula.", "Sin genero", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("El nombre no puede quedar vacio.", "Nombre vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBorrarImagen_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if(txtNombre.Text == "Nombre")
            {
                txtNombre.Clear();
                txtNombre.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.Gray;
            }
        }

        private void txtDuracion_Enter(object sender, EventArgs e)
        {
            if (txtDuracion.Text == "Duracion")
            {
                txtDuracion.Clear();
                txtDuracion.ForeColor = Color.Black;
            }
        }

        private void txtDuracion_Leave(object sender, EventArgs e)
        {
            if (txtDuracion.Text == "")
            {
                txtDuracion.Text = "Duracion";
                txtDuracion.ForeColor = Color.Gray;
            }
        }

        private void txtActores_Enter(object sender, EventArgs e)
        {
            if (txtActores.Text == "Actores")
            {
                txtActores.Clear();
                txtActores.ForeColor = Color.Black;
            }
        }

        private void txtActores_Leave(object sender, EventArgs e)
        {
            if (txtActores.Text == "")
            {
                txtActores.Text = "Actores";
                txtActores.ForeColor = Color.Gray;
            }
        }

        private void txtDirectores_Enter(object sender, EventArgs e)
        {
            if (txtDirectores.Text == "Directores")
            {
                txtDirectores.Clear();
                txtDirectores.ForeColor = Color.Black;
            }
        }

        private void txtDirectores_Leave(object sender, EventArgs e)
        {
            if (txtDirectores.Text == "")
            {
                txtDirectores.Text = "Directores";
                txtDirectores.ForeColor = Color.Gray;
            }
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripcion")
            {
                txtDescripcion.Clear();
                txtDescripcion.ForeColor = Color.Black;
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripcion";
                txtDescripcion.ForeColor = Color.Gray;
            }
        }

        private void limpiarCajas()
        {
            txtNombre.Clear();
            txtDuracion.Clear();
            txtActores.Clear();
            txtDirectores.Clear();
            txtDescripcion.Clear();
            boxGenero.SelectedIndex = 0;
            boxClasificacion.SelectedIndex = 0;
            pictureBox1.Image = null;
            cbEstado.Checked = true;

            placeholderTextbox();
        }

        private void placeholderTextbox()
        {
            if (txtNombre.TextLength == 0)
            {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.Gray;
            }
            else txtNombre.ForeColor = Color.Black;

            if (txtDuracion.TextLength == 0)
            {
                txtDuracion.Text = "Duracion";
                txtDuracion.ForeColor = Color.Gray;
            }
            else txtDuracion.ForeColor = Color.Black;

            if (txtActores.TextLength == 0)
            {
                txtActores.Text = "Actores";
                txtActores.ForeColor = Color.Gray;
            }
            else txtActores.ForeColor = Color.Black;

            if (txtDirectores.TextLength == 0)
            {
                txtDirectores.Text = "Directores";
                txtDirectores.ForeColor = Color.Gray;
            }
            else txtDirectores.ForeColor = Color.Black;

            if (txtDescripcion.TextLength == 0)
            {
                txtDescripcion.Text = "Descripcion";
                txtDescripcion.ForeColor = Color.Gray;
            }
            else txtDescripcion.ForeColor = Color.Black;
        }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void seleccionarRegistro(int codigo)
        {
            for(int i=0; i<dgvPeliculas.RowCount; i++) 
            {
                if(dgvPeliculas.Rows[i].Cells[0].Value.ToString() == codigo.ToString()) 
                {
                    dgvPeliculas.CurrentCell = dgvPeliculas.Rows[i].Cells[1];
                    dgvPeliculas.Rows[i].Selected = true;
                }
            }
        }
    }
}
    

