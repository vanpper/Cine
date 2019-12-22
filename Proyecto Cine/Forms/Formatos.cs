using Proyecto_Cine.Clases.Entidades;
using Proyecto_Cine.Clases.INegocio;
using Proyecto_Cine.Clases.Negocio;
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
        private IPeliculaNeg peliculaNeg = new PeliculaNeg();
        private IFormatoNeg formatoNeg = new FormatoNeg();
        private IPeliculaPorFormatoNeg pxfNeg = new PeliculaPorFormatoNeg();
        private DataTable dtFormatos;
        private DataTable dtFormatosBox;
        private DataTable dtPeliculas;
        private DataTable dtPXF;
        
        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2;

        private int OperacionFormatos = 0;
        private bool GuardandoFormato = false;

        public Formatos()
        {
            InitializeComponent();
            IniciarDtFormatos();
            IniciarDtFormatosBox();
            IniciarDtPeliculas();
            IniciarDtPXF();

            if (!ActualizarDgvFormatos())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Formatos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxFormatos())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar el descolgable de Formatos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxPeliculas())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Peliculas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarDgvPXF())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de peliculas y sus formatos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigurarGrids();
        }

        private void IniciarDtFormatos()
        {
            dtFormatos = new DataTable();
            dtFormatos.Columns.Add("Codigo");
            dtFormatos.Columns.Add("Formato");
            dgvFormatos.DataSource = dtFormatos;
        }

        private void IniciarDtFormatosBox()
        {
            dtFormatosBox = new DataTable();
            dtFormatosBox.Columns.Add("Codigo");
            dtFormatosBox.Columns.Add("Formato");
            boxFormatos.DataSource = dtFormatosBox;
        }

        private void IniciarDtPeliculas()
        {
            dtPeliculas = new DataTable();
            dtPeliculas.Columns.Add("Codigo");
            dtPeliculas.Columns.Add("Nombre");
            boxPeliculas.DataSource = dtPeliculas;
        }

        private void IniciarDtPXF()
        {
            dtPXF = new DataTable();
            dtPXF.Columns.Add("Codigo Formato");
            dtPXF.Columns.Add("Formato");
            dtPXF.Columns.Add("Estado");
            dgvPXF.DataSource = dtPXF;
        }

        private void ConfigurarGrids()
        {
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
        }

        private bool ActualizarDgvFormatos()
        {
            List<Formato> lista = formatoNeg.obtenerTodos();
            if (lista == null) return false;

            dtFormatos.Clear();

            foreach (Formato formato in lista)
            {
                DataRow row = dtFormatos.NewRow();
                row[0] = formato.getId();
                row[1] = formato.getDescripcion();
                dtFormatos.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarBoxFormatos()
        {
            List<Formato> lista = formatoNeg.obtenerTodos();
            if (lista == null) return false;

            dtFormatosBox.Clear();

            DataRow firstRowBox = dtFormatosBox.NewRow();
            firstRowBox[0] = 0;
            firstRowBox[1] = "SELECCIONE UN FORMATO";
            dtFormatosBox.Rows.Add(firstRowBox);

            foreach (Formato formato in lista)
            {
                DataRow rowBox = dtFormatosBox.NewRow();
                rowBox[0] = formato.getId();
                rowBox[1] = formato.getDescripcion();
                dtFormatosBox.Rows.Add(rowBox);
            }

            boxFormatos.DisplayMember = "Formato";
            boxFormatos.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxPeliculas()
        {
            List<Pelicula> lista = peliculaNeg.obtenerTodas();
            if (lista == null) return false;

            dtPeliculas.Clear();

            DataRow firstRow = dtPeliculas.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "SELECCIONE UNA PELICULA";
            dtPeliculas.Rows.Add(firstRow);

            foreach(Pelicula pelicula in lista)
            {
                DataRow row = dtPeliculas.NewRow();
                row[0] = pelicula.getId();
                row[1] = pelicula.getNombre();
                dtPeliculas.Rows.Add(row);
            }

            boxPeliculas.DisplayMember = "Nombre";
            boxPeliculas.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarDgvPXF()
        {
            List<PeliculaPorFormato> lista = pxfNeg.obtenerTodos(Int32.Parse(boxPeliculas.SelectedValue.ToString()));
            if (lista == null) return false;

            dtPXF.Clear();

            foreach(PeliculaPorFormato pxf in lista)
            {
                DataRow row = dtPXF.NewRow();
                row[0] = pxf.getFormato().getId();
                row[1] = pxf.getFormato().getDescripcion();
                row[2] = pxf.getEstado();
                dtPXF.Rows.Add(row);
            }

            return true;
        }

        private void AbrirPanelPXF()
        {
            dgvPXF.Height = 235;
            panelPXF.Visible = true;
            btnNuevoPXF.Visible = false;
            btnHabilitacionPXF.Visible = false;
        }

        private void CerrarPanelPXF()
        {
            panelPXF.Visible = false;
            dgvPXF.Height = 332;
            btnNuevoPXF.Visible = true;
            btnHabilitacionPXF.Visible = true;
        }

        private void AbrirPanelFormatos()
        {
            dgvFormatos.Height = 277;
            panelFormato.Visible = true;
            btnNuevoFormato.Visible = false;
            btnModificarFormato.Visible = false;
        }

        private void CerrarPanelFormatos()
        {
            OperacionFormatos = NULL;
            panelFormato.Visible = false;
            dgvFormatos.Height = 374;
            btnNuevoFormato.Visible = true;
            btnModificarFormato.Visible = true;
            txtDescripcionFormato.Clear();
        }

        private void btnVolverFormato_Click(object sender, EventArgs e)
        {
            CerrarPanelFormatos();
        }

        private void btnNuevoFormato_Click(object sender, EventArgs e)
        {
            OperacionFormatos = NUEVO;
            AbrirPanelFormatos();
            txtDescripcionFormato.Focus();
        }

        private void btnModificarFormato_Click(object sender, EventArgs e)
        {
            OperacionFormatos = MODIFICAR;
            AbrirPanelFormatos();
            txtDescripcionFormato.Text = dgvFormatos.CurrentRow.Cells[1].Value.ToString();
            txtDescripcionFormato.Focus();
            txtDescripcionFormato.SelectAll();
        }

        private void dgvFormatos_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionFormatos == MODIFICAR && GuardandoFormato != true)
            {
                txtDescripcionFormato.Text = dgvFormatos.CurrentRow.Cells[1].Value.ToString();
                txtDescripcionFormato.Focus();
                txtDescripcionFormato.SelectAll();
            }
        }

        private void btnGuardarFormato_Click(object sender, EventArgs e)
        {
            if(txtDescripcionFormato.TextLength != 0)
            {
                GuardandoFormato = true;

                Formato formato = new Formato();
                formato.setId(Int32.Parse(dgvFormatos.CurrentRow.Cells[0].Value.ToString()));
                formato.setDescripcion(txtDescripcionFormato.Text);

                if (OperacionFormatos == NUEVO)
                {
                    if(formatoNeg.agregar(formato))
                    {
                        MessageBox.Show("Se ha agregado el formato con exito.", "Formato agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescripcionFormato.Clear();
                        txtDescripcionFormato.Focus();
                    }
                }

                if (OperacionFormatos == MODIFICAR)
                {
                    if (formatoNeg.modificar(formato))
                    {
                        MessageBox.Show("Se ha modificado el formato con exito.", "Formato modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescripcionFormato.Text = dgvFormatos.Rows[0].Cells[1].Value.ToString();
                    }
                }

                if (!ActualizarDgvFormatos())
                {
                    MessageBox.Show("No se ha podido actualizar la lista de Formatos.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ActualizarBoxFormatos())
                {
                    RemoverElementosBoxFormatos();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al actualizar el descolgable de Formatos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                GuardandoFormato = false;
            }
            else
            {
                MessageBox.Show("La descripcion del formato no puede quedar vacia.", "Descripcion vacia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoPXF_Click(object sender, EventArgs e)
        {
            if(boxPeliculas.SelectedIndex != 0)
            {
                AbrirPanelPXF();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una pelicula.", "Sin pelicula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolverPXF_Click(object sender, EventArgs e)
        {
            CerrarPanelPXF();
        }

        private void boxPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDgvPXF();
            ActualizarBoxFormatos();
            RemoverElementosBoxFormatos();
        }

        private void btnHabilitacionPXF_Click(object sender, EventArgs e)
        {
            if(dgvPXF.CurrentRow != null)
            {
                Pelicula pelicula = new Pelicula();
                pelicula.setId(Int32.Parse(boxPeliculas.SelectedValue.ToString()));

                Formato formato = new Formato();
                formato.setId(Int32.Parse(dgvPXF.CurrentRow.Cells[0].Value.ToString()));

                PeliculaPorFormato pxf = new PeliculaPorFormato();
                pxf.setPelicula(pelicula);
                pxf.setFormato(formato);
                pxf.setEstado(Boolean.Parse(dgvPXF.CurrentRow.Cells[2].Value.ToString()));

                if(pxf.getEstado())
                {
                    if(pxfNeg.deshabilitar(pxf))
                    {
                        MessageBox.Show("Se ha deshabilitado la pelicula en el formato seleccionado.", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!ActualizarDgvPXF())
                        {
                            MessageBox.Show("Ha ocurrido un error al actualizar la lista de peliculas y sus formatos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if(pxfNeg.habilitar(pxf))
                    {
                        MessageBox.Show("Se ha habilitado la pelicula en el formato seleccionado.", "Habilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!ActualizarDgvPXF())
                        {
                            MessageBox.Show("Ha ocurrido un error al actualizar la lista de peliculas y sus formatos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay una fila seleccionada.", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarPXF_Click(object sender, EventArgs e)
        {
            if(boxFormatos.SelectedIndex != 0)
            {
                Pelicula pelicula = new Pelicula();
                pelicula.setId(Int32.Parse(boxPeliculas.SelectedValue.ToString()));

                Formato formato = new Formato();
                formato.setId(Int32.Parse(boxFormatos.SelectedValue.ToString()));

                PeliculaPorFormato pxf = new PeliculaPorFormato();
                pxf.setPelicula(pelicula);
                pxf.setFormato(formato);
                pxf.setEstado(true);

                if(pxfNeg.agregar(pxf))
                {
                    MessageBox.Show("Se ha agregado la pelicula en el formato seleccionado.", "Pelicula agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!ActualizarDgvPXF())
                    {
                        MessageBox.Show("Ha ocurrido un error al actualizar la lista de peliculas y sus formatos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    RemoverElementosBoxFormatos();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un formato.\nSi no hay mas formatos disponibles es posible que la pelicula ya se encuentre en todos los formatos.", "Sin formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoverElementosBoxFormatos()
        {
            for (int i = 0; i < dgvPXF.RowCount; i++)
            {
                for (int j = 0; j < dtFormatosBox.Rows.Count; j++)
                {
                    if (dtFormatosBox.Rows[j][0].ToString() == dgvPXF.Rows[i].Cells[0].Value.ToString())
                    {
                        dtFormatosBox.Rows.RemoveAt(j);
                    }
                }
            }
        }
    }
}
