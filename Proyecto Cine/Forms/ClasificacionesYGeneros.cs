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
    public partial class ClasificacionesYGeneros : Form
    {
        private IClasificacionNeg clasificacionNeg = new ClasificacionNeg();
        private IGeneroNeg generoNeg = new GeneroNeg();
        private DataTable dtClasificaciones;
        private DataTable dtGeneros;

        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2;
        
        private int OperacionClasificaciones = NULL;
        private int OperacionGeneros = NULL;
        private bool GuardandoClasificacion = false;
        private bool GuardandoGenero = false;
        

        public ClasificacionesYGeneros()
        {
            InitializeComponent();
            IniciarDtClasificaciones();
            IniciarDtGeneros();
            
            if(!ActualizarDgvClasificaciones())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Clasificaciones", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(!ActualizarDgvGeneros())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Generos", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigurarGrids();
        }

        private void IniciarDtClasificaciones()
        {
            dtClasificaciones = new DataTable();
            dtClasificaciones.Columns.Add("Codigo");
            dtClasificaciones.Columns.Add("Clasificacion");
            dgvClasificaciones.DataSource = dtClasificaciones;
        }

        private void IniciarDtGeneros()
        {
            dtGeneros = new DataTable();
            dtGeneros.Columns.Add("Codigo");
            dtGeneros.Columns.Add("Genero");
            dgvGeneros.DataSource = dtGeneros;
        }

        private bool ActualizarDgvClasificaciones()
        {
            List<Clasificacion> listaClasificaciones = clasificacionNeg.obtenerTodas();
            if (listaClasificaciones == null) return false;

            dtClasificaciones.Clear();

            foreach(Clasificacion clasificacion in listaClasificaciones)
            {
                DataRow row = dtClasificaciones.NewRow();
                row[0] = clasificacion.getId();
                row[1] = clasificacion.getDescripcion();
                dtClasificaciones.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarDgvGeneros()
        {
            List<Genero> listaGeneros = generoNeg.obtenerTodos();
            if (listaGeneros == null) return false;

            dtGeneros.Clear();

            foreach(Genero genero in listaGeneros)
            {
                DataRow row = dtGeneros.NewRow();
                row[0] = genero.getId();
                row[1] = genero.getDescripcion();
                dtGeneros.Rows.Add(row);
            }

            return true;
        }

        private void ConfigurarGrids()
        {
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

        private void AbrirPanelClasificaciones()
        {
            dgvClasificaciones.Height = 277;
            panelClasificacion.Visible = true;
            btnNuevoClasificacion.Visible = false;
            btnModificarClasificacion.Visible = false;
        }

        private void AbrirPanelGeneros()
        {
            dgvGeneros.Height = 277;
            panelGenero.Visible = true;
            btnNuevoGenero.Visible = false;
            btnModificarGenero.Visible = false;
        }

        private void CerrarPanelClasificaciones()
        {
            OperacionClasificaciones = NULL;
            panelClasificacion.Visible = false;
            dgvClasificaciones.Height = 374;
            btnNuevoClasificacion.Visible = true;
            btnModificarClasificacion.Visible = true;
            txtDescripcionClasificacion.Clear();
        }

        private void CerrarPanelGeneros()
        {
            OperacionGeneros = NULL;
            panelGenero.Visible = false;
            dgvGeneros.Height = 374;
            btnNuevoGenero.Visible = true;
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
            if(OperacionClasificaciones == MODIFICAR && GuardandoClasificacion != true)
            {
               txtDescripcionClasificacion.Text = dgvClasificaciones.CurrentRow.Cells[1].Value.ToString();
               txtDescripcionClasificacion.Focus();
               txtDescripcionClasificacion.SelectAll();
            }
        }

        private void btnGuardarClasificacion_Click(object sender, EventArgs e)
        {
            if(txtDescripcionClasificacion.TextLength != 0)
            {
                GuardandoClasificacion = true;

                Clasificacion clasificacion = new Clasificacion();
                clasificacion.setId(Int32.Parse(dgvClasificaciones.CurrentRow.Cells[0].Value.ToString()));
                clasificacion.setDescripcion(txtDescripcionClasificacion.Text);

                if (OperacionClasificaciones == NUEVO)
                {
                    if(clasificacionNeg.agregar(clasificacion))
                    {
                        MessageBox.Show("Se ha agregado la clasificacion con exito.", "Clasificacion agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescripcionClasificacion.Clear();
                        txtDescripcionClasificacion.Focus();

                        if (ActualizarDgvClasificaciones())
                        {
                            clasificacion = clasificacionNeg.obtenerUltima();

                            if (clasificacion != null)
                            {
                                seleccionarFilaClasificacion(clasificacion.getId());
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido actualizar la lista de Clasificaciones.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (OperacionClasificaciones == MODIFICAR)
                {
                    if (clasificacionNeg.modificar(clasificacion))
                    {
                        MessageBox.Show("Se ha modificado la clasificacion con exito.", "Clasificacion modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        if (ActualizarDgvClasificaciones())
                        {
                            seleccionarFilaClasificacion(clasificacion.getId());
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido actualizar la lista de Clasificaciones.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                GuardandoClasificacion = false;
            }
            else
            {
                MessageBox.Show("El nombre no puede quedar vacio.", "Nombre vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (OperacionGeneros == MODIFICAR && GuardandoGenero != true)
            {
                txtDescripcionGenero.Text = dgvGeneros.CurrentRow.Cells[1].Value.ToString();
                txtDescripcionGenero.Focus();
                txtDescripcionGenero.SelectAll();
            }
        }

        private void btnGuardarGenero_Click(object sender, EventArgs e)
        {
            if (txtDescripcionGenero.TextLength != 0)
            {
                GuardandoGenero = true;

                Genero genero = new Genero();
                genero.setId(Int32.Parse(dgvGeneros.CurrentRow.Cells[0].Value.ToString()));
                genero.setDescripcion(txtDescripcionGenero.Text);

                if (OperacionGeneros == NUEVO)
                {
                    if (generoNeg.agregar(genero))
                    {
                        MessageBox.Show("Se ha agregado el genero con exito.", "Genero agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescripcionGenero.Clear();
                        txtDescripcionGenero.Focus();

                        if (ActualizarDgvGeneros())
                        {
                            genero = generoNeg.obtenerUltimo();

                            if (genero != null)
                            {
                                seleccionarFilaGenero(genero.getId());
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido actualizar la lista de Generos.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (OperacionGeneros == MODIFICAR)
                {
                    if (generoNeg.modificar(genero))
                    {
                        MessageBox.Show("Se ha modificado el genero con exito.", "Genero modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (ActualizarDgvGeneros())
                        {
                            seleccionarFilaGenero(genero.getId());
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido actualizar la lista de Generos.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                GuardandoGenero = false;
            }
            else
            {
                MessageBox.Show("El nombre no puede quedar vacio.", "Nombre vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void seleccionarFilaClasificacion(int codigo)
        {
            for(int i=0; i<dgvClasificaciones.RowCount; i++)
            {
                if(dgvClasificaciones.Rows[i].Cells[0].Value.ToString() == codigo.ToString())
                {
                    dgvClasificaciones.CurrentCell = dgvClasificaciones.Rows[i].Cells[1];
                    dgvClasificaciones.Rows[i].Selected = true;
                }
            }
        }

        private void seleccionarFilaGenero(int codigo)
        {
            for (int i = 0; i < dgvGeneros.RowCount; i++)
            {
                if (dgvGeneros.Rows[i].Cells[0].Value.ToString() == codigo.ToString())
                {
                    dgvGeneros.CurrentCell = dgvGeneros.Rows[i].Cells[1];
                    dgvGeneros.Rows[i].Selected = true;
                }
            }
        }
    }
}
