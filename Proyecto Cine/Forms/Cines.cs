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
    public partial class Cines : Form
    {
        private ICineNeg cineNeg = new CineNeg();
        private IProvinciaNeg provinciaNeg = new ProvinciaNeg();
        private ICiudadNeg ciudadNeg = new CiudadNeg();
        private DataTable dtProvincias;
        private DataTable dtCiudades;
        private DataTable dtCines;

        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2;

        private int Operacion = NULL;
        private bool Guardando = false;

        public Cines()
        {
            InitializeComponent();

            IniciarDtProvincias();
            IniciarDtCiudades();
            IniciarDtCines();

            if(!ActualizarDgvCines())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Cines", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(ActualizarBoxProvincias())
            {
                if(!ActualizarBoxCiudades())
                {
                    MessageBox.Show("Ha ocurrido un error al actualizar el listado de ciudades", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al actualizar el listado de provincias", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetearConfigDataGrid();
        }

        private void IniciarDtProvincias()
        {
            dtProvincias = new DataTable();
            dtProvincias.Columns.Add("Codigo");
            dtProvincias.Columns.Add("Provincia");
            boxProvincia.DataSource = dtProvincias;
        }

        private void IniciarDtCiudades()
        {
            dtCiudades = new DataTable();
            dtCiudades.Columns.Add("Codigo Provincia");
            dtCiudades.Columns.Add("Codigo Ciudad");
            dtCiudades.Columns.Add("Ciudad");
            boxCiudad.DataSource = dtCiudades;
        }

        private void IniciarDtCines()
        {
            dtCines = new DataTable();
            dtCines.Columns.Add("Codigo Cine");
            dtCines.Columns.Add("Nombre");
            dtCines.Columns.Add("Codigo Provincia");
            dtCines.Columns.Add("Provincia");
            dtCines.Columns.Add("Codigo Ciudad");
            dtCines.Columns.Add("Ciudad");
            dtCines.Columns.Add("Direccion");
            dtCines.Columns.Add("Descripcion");
            dtCines.Columns.Add("Estado");
            dgvCines.DataSource = dtCines;
        }

        private bool ActualizarBoxProvincias()
        {
            List<Provincia> listaProvincias = provinciaNeg.obtenerTodas();
            if (listaProvincias == null) return false;

            dtProvincias.Clear();

            DataRow firstRow = dtProvincias.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "SELECCIONE UNA PROVINCIA";
            dtProvincias.Rows.InsertAt(firstRow, 0);

            foreach (Provincia provincia in listaProvincias)
            {
                DataRow row = dtProvincias.NewRow();
                row[0] = provincia.getId();
                row[1] = provincia.getDescripcion();
                dtProvincias.Rows.Add(row);
            }

            boxProvincia.DisplayMember = "Provincia";
            boxProvincia.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxCiudades()
        {
            int idProvincia = Int32.Parse(boxProvincia.SelectedValue.ToString());
            List<Ciudad> listaCiudades = ciudadNeg.obtenerTodas(idProvincia);
            if (listaCiudades == null) return false;

            dtCiudades.Clear();

            DataRow firstRow = dtCiudades.NewRow();
            firstRow[1] = 0;
            firstRow[2] = "SELECCIONE UNA CIUDAD";
            dtCiudades.Rows.InsertAt(firstRow, 0);

            foreach (Ciudad ciudad in listaCiudades)
            {
                DataRow row = dtCiudades.NewRow();
                row[0] = ciudad.getProvincia().getId();
                row[1] = ciudad.getId();
                row[2] = ciudad.getDescripcion();
                dtCiudades.Rows.Add(row);
            }

            boxCiudad.DisplayMember = "Ciudad";
            boxCiudad.ValueMember = "Codigo Ciudad";

            return true;
        }

        private bool ActualizarDgvCines()
        {
            List<Cine> listaCines = cineNeg.obtenerTodos();
            if (listaCines == null) return false;

            dtCines.Clear();

            foreach(Cine cine in listaCines)
            {
                DataRow row = dtCines.NewRow();
                row[0] = cine.getId();
                row[1] = cine.getNombre();
                row[2] = cine.getCiudad().getProvincia().getId();
                row[3] = cine.getCiudad().getProvincia().getDescripcion();
                row[4] = cine.getCiudad().getId();
                row[5] = cine.getCiudad().getDescripcion();
                row[6] = cine.getDireccion();
                row[7] = cine.getDescripcion();
                row[8] = cine.getEstado();
                dtCines.Rows.Add(row);
            }

            return true;
        }

        private void SetearConfigDataGrid()
        {
            dgvCines.Columns[0].Visible = false;
            dgvCines.Columns[2].Visible = false;
            dgvCines.Columns[4].Visible = false;
            dgvCines.ReadOnly = true;
            dgvCines.AllowUserToAddRows = false;
            dgvCines.RowHeadersVisible = false;
            dgvCines.AllowUserToResizeColumns = false;
            dgvCines.AllowUserToResizeRows = false;
            dgvCines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCines.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCines.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCines.Height = 388;
        }

        private void AbrirPanel()
        {
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
            dgvCines.Height = 241;
            panel1.Visible = true;
        }

        private void CerrarPanel()
        {
            Operacion = NULL;
            panel1.Visible = false;
            dgvCines.Height = 388;
            btnNuevo.Visible = true;
            btnModificar.Visible = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void limpiarCajas()
        {
            Operacion = NUEVO;
            txtCodigo.Clear();
            txtNombre.Clear();
            boxProvincia.SelectedIndex = 0;
            boxCiudad.SelectedIndex = 0;
            txtDireccion.Clear();
            txtDescripcion.Clear();
            checkActivo.Checked = true;
            AbrirPanel();
            txtNombre.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Operacion = MODIFICAR;

            txtCodigo.Text = dgvCines.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvCines.CurrentRow.Cells[1].Value.ToString();
            boxProvincia.SelectedValue = dgvCines.CurrentRow.Cells[2].Value;
            boxCiudad.SelectedValue = dgvCines.CurrentRow.Cells[4].Value;
            txtDireccion.Text = dgvCines.CurrentRow.Cells[6].Value.ToString();
            txtDescripcion.Text = dgvCines.CurrentRow.Cells[7].Value.ToString();
            checkActivo.Checked = bool.Parse(dgvCines.CurrentRow.Cells[8].Value.ToString());

            AbrirPanel();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Length != 0)
            {
                if(boxProvincia.SelectedIndex != 0)
                {
                    if(boxCiudad.SelectedIndex != 0)
                    {
                        if(txtDireccion.Text.Length != 0)
                        {
                            Guardando = true;

                            Provincia provincia = new Provincia();
                            provincia.setId(Int32.Parse(boxProvincia.SelectedValue.ToString()));

                            Ciudad ciudad = new Ciudad();
                            ciudad.setId(Int32.Parse(boxCiudad.SelectedValue.ToString()));
                            ciudad.setProvincia(provincia);

                            Cine cine = new Cine();
                            cine.setId(Int32.Parse(dgvCines.CurrentRow.Cells[0].Value.ToString()));
                            cine.setNombre(txtNombre.Text);
                            cine.setCiudad(ciudad);
                            cine.setDireccion(txtDireccion.Text);
                            cine.setDescripcion(txtDescripcion.Text);
                            cine.setEstado(checkActivo.Checked);

                            if (Operacion == NUEVO)
                            {
                                if(cineNeg.agregar(cine))
                                {
                                    MessageBox.Show("Se ha agregado el cine con exito.", "Cine agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    limpiarCajas();
                                    
                                    if(ActualizarDgvCines())
                                    {
                                        cine = cineNeg.obtenerUltimo();

                                        if (cine != null)
                                        {
                                            seleccionarFila(cine.getId());
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se ha podido actualizar la lista de cines.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            if (Operacion == MODIFICAR)
                            {
                                if (cineNeg.modificar(cine))
                                {
                                    MessageBox.Show("Se ha modificado el cine con exito.", "Cine modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (ActualizarDgvCines())
                                    {
                                        seleccionarFila(cine.getId());
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se ha podido actualizar la lista de cines.", "Fallo actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            Guardando = false;
                        }
                        else
                        {
                            MessageBox.Show("La direccion no puede quedar vacia.", "Direccion vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una ciudad.", "Sin ciudad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una provincia.", "Sin provincia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("El nombre no puede quedar vacio.", "Nombre vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Operacion == MODIFICAR && Guardando != true)
            {
                txtCodigo.Text = dgvCines.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgvCines.CurrentRow.Cells[1].Value.ToString();
                boxProvincia.SelectedValue = dgvCines.CurrentRow.Cells[2].Value;
                boxCiudad.SelectedValue = dgvCines.CurrentRow.Cells[4].Value;
                txtDireccion.Text = dgvCines.CurrentRow.Cells[6].Value.ToString();
                txtDescripcion.Text = dgvCines.CurrentRow.Cells[7].Value.ToString();
                checkActivo.Checked = bool.Parse(dgvCines.CurrentRow.Cells[8].Value.ToString());
            }
        }

        private void boxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!ActualizarBoxCiudades())
            {
                MessageBox.Show("Ha ocurrido un error al listar las ciudades.", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel();
        }

        private void seleccionarFila(int codigo)
        {
            for(int i=0; i<dgvCines.RowCount; i++)
            {
                if(dgvCines.Rows[i].Cells[0].Value.ToString() == codigo.ToString())
                {
                    dgvCines.CurrentCell = dgvCines.Rows[i].Cells[1];
                    dgvCines.Rows[i].Selected = true;
                }
            }
        }

    }
}
