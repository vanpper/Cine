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
    public partial class Precios : Form
    {
        private ITipoDeEntradaNeg entradasNeg = new TipoDeEntradaNeg();
        private ITipoDeSalaNeg salasNeg = new TipoDeSalaNeg();
        private IPrecioNeg precioNeg = new PrecioNeg();
        private ICineNeg cineNeg = new CineNeg();
        private DataTable dtTiposDeEntrada;
        private DataTable dtTiposDeEntrada2;
        private DataTable dtTiposDeSalas;
        private DataTable dtPrecios;
        private DataTable dtCines;

        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2;
        
        private int OperacionTiposDeEntradas = NULL;
        private int OperacionPrecios = NULL;
        private bool Guardando = false;

        public Precios()
        {
            InitializeComponent();
            IniciarDtTiposDeEntrada();
            IniciarDtTiposDeEntrada2();
            IniciarDtCines();
            IniciarDtTiposDeSalas();
            IniciarDtPrecios();
            
            if(!ActualizarDgvTDE())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de entradas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxCines())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Cines", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxTDS())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de salas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarDgvPrecios())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Precios", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigurarGrids();
        }

        private void IniciarDtTiposDeEntrada()
        {
            dtTiposDeEntrada = new DataTable();
            dtTiposDeEntrada.Columns.Add("Codigo");
            dtTiposDeEntrada.Columns.Add("Descripcion");
            dgvTDE.DataSource = dtTiposDeEntrada;
        }

        private void IniciarDtTiposDeEntrada2()
        {
            dtTiposDeEntrada2 = new DataTable();
            dtTiposDeEntrada2.Columns.Add("Codigo");
            dtTiposDeEntrada2.Columns.Add("Descripcion");
            boxTDE.DataSource = dtTiposDeEntrada2;
        }

        private void IniciarDtCines()
        {
            dtCines = new DataTable();
            dtCines.Columns.Add("Codigo");
            dtCines.Columns.Add("Nombre");
            BoxCines.DataSource = dtCines;
        }

        private void IniciarDtTiposDeSalas()
        {
            dtTiposDeSalas = new DataTable();
            dtTiposDeSalas.Columns.Add("Codigo");
            dtTiposDeSalas.Columns.Add("Descripcion");
            BoxTDS.DataSource = dtTiposDeSalas;
        }

        private void IniciarDtPrecios()
        {
            dtPrecios = new DataTable();
            dtPrecios.Columns.Add("Codigo Entrada");
            dtPrecios.Columns.Add("Entrada");
            dtPrecios.Columns.Add("Precio");
            dgvPrecios.DataSource = dtPrecios;
        }

        private bool ActualizarDgvTDE()
        {
            List<TipoDeEntrada> lista = entradasNeg.obtenerTodos();
            if (lista == null) return false;

            dtTiposDeEntrada.Clear();

            foreach(TipoDeEntrada tipo in lista)
            {
                DataRow row = dtTiposDeEntrada.NewRow();
                row[0] = tipo.getId();
                row[1] = tipo.getDescripcion();
                dtTiposDeEntrada.Rows.Add(row);
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

            BoxCines.DisplayMember = "Nombre";
            BoxCines.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarBoxTDS()
        {
            dtTiposDeSalas.Clear();

            DataRow firstRow = dtTiposDeSalas.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SELECCIONE ---";
            dtTiposDeSalas.Rows.Add(firstRow);

            List<TipoDeSala> lista = salasNeg.obtenerTodos();
            if (lista == null) return false;

            foreach (TipoDeSala tipo in lista)
            {
                DataRow row = dtTiposDeSalas.NewRow();
                row[0] = tipo.getId();
                row[1] = tipo.getDescripcion();
                dtTiposDeSalas.Rows.Add(row);
            }

            BoxTDS.DisplayMember = "Descripcion";
            BoxTDS.ValueMember = "Codigo";

            return true;
        }

        private bool ActualizarDgvPrecios()
        {
            int idCine = Int32.Parse(BoxCines.SelectedValue.ToString());
            int idSala = Int32.Parse(BoxTDS.SelectedValue.ToString());
            List<Precio> lista = precioNeg.obtenerTodos(idCine, idSala);
            if (lista == null) return false;

            dtPrecios.Clear();

            foreach(Precio precio in lista)
            {
                DataRow row = dtPrecios.NewRow();
                row[0] = precio.getTipoEntrada().getId();
                row[1] = precio.getTipoEntrada().getDescripcion();
                row[2] = precio.getPrecio();
                dtPrecios.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarBoxTDE()
        {
            dtTiposDeEntrada2.Clear();

            DataRow firstRow = dtTiposDeEntrada2.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SELECCIONE ---";
            dtTiposDeEntrada2.Rows.Add(firstRow);

            List<TipoDeEntrada> lista = entradasNeg.obtenerTodos();
            if (lista == null) return false;

            foreach(TipoDeEntrada tipo in lista)
            {
                DataRow row = dtTiposDeEntrada2.NewRow();
                row[0] = tipo.getId();
                row[1] = tipo.getDescripcion();
                dtTiposDeEntrada2.Rows.Add(row);
            }

            boxTDE.DisplayMember = "Descripcion";
            boxTDE.ValueMember = "Codigo";

            return true;
        }

        private void ConfigurarGrids()
        {
            dgvTDE.Height = 377;
            dgvTDE.Columns[0].Visible = false;
            dgvTDE.ReadOnly = true;
            dgvTDE.AllowUserToAddRows = false;
            dgvTDE.RowHeadersVisible = false;
            dgvTDE.AllowUserToResizeColumns = false;
            dgvTDE.AllowUserToResizeRows = false;
            dgvTDE.MultiSelect = false;
            dgvTDE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTDE.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTDE.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTDE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTDE.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvPrecios.Height = 350;
            dgvPrecios.Columns[0].Visible = false;
            dgvPrecios.ReadOnly = true;
            dgvPrecios.AllowUserToAddRows = false;
            dgvPrecios.RowHeadersVisible = false;
            dgvPrecios.AllowUserToResizeColumns = false;
            dgvPrecios.AllowUserToResizeRows = false;
            dgvPrecios.MultiSelect = false;
            dgvPrecios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrecios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrecios.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrecios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrecios.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPrecios.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void AbrirPanelPrecio()
        {
            dgvPrecios.Height = 259;
            panelPrecio.Visible = true;
            btnNuevoPrecio.Visible = false;
            btnModificarPrecio.Visible = false;

            if (OperacionPrecios == NUEVO)
            {
                boxTDE.Visible = true;
                label2.Visible = true;
                txtPrecio.Location = new Point(457, 11);
                label3.Location = new Point(404, 14);
            }

            if(OperacionPrecios == MODIFICAR)
            {
                boxTDE.Visible = false;
                label2.Visible = false;
                txtPrecio.Location = new Point(267, 13);
                label3.Location = new Point(215, 15);
            }  
        }

        private void CerrarPanelPrecio()
        {
            OperacionPrecios = NULL;
            panelPrecio.Visible = false;
            dgvPrecios.Height = 350;
            btnNuevoPrecio.Visible = true;
            btnModificarPrecio.Visible = true;
            txtPrecio.Clear();
        }

        private void OcultarPanelTDE()
        {
            OperacionTiposDeEntradas = NULL;
            panelTDE.Visible = false;
            dgvTDE.Height = 377;
            btnNuevoTDE.Visible = true;
            btnModificarTDE.Visible = true;
            txtDescripcionTDE.Clear();
        }

        private void MostrarPanelTDE()
        {
            btnNuevoTDE.Visible = false;
            btnModificarTDE.Visible = false;
            dgvTDE.Height = 286;
            panelTDE.Visible = true;
        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvTDE.CurrentRow != null)
            {
                OperacionTiposDeEntradas = MODIFICAR;
                MostrarPanelTDE();
                txtDescripcionTDE.Text = dgvTDE.CurrentRow.Cells[1].Value.ToString();
                txtDescripcionTDE.Focus();
                txtDescripcionTDE.SelectAll();
            }
        }

        private void btnNuevoTDE_Click(object sender, EventArgs e)
        {
            OperacionTiposDeEntradas = NUEVO;
            MostrarPanelTDE();
            txtDescripcionTDE.Focus();
        }

        private void btnVolverTDE_Click(object sender, EventArgs e)
        {
            OcultarPanelTDE();
        }

        private void dgvTDE_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionTiposDeEntradas == MODIFICAR && Guardando != true)
            {
                txtDescripcionTDE.Text = dgvTDE.CurrentRow.Cells[1].Value.ToString();
                txtDescripcionTDE.Focus();
                txtDescripcionTDE.SelectAll();
            }
        }

        private void btnGuardarTDE_Click(object sender, EventArgs e)
        {
            if(txtDescripcionTDE.TextLength != 0)
            {
                Guardando = true;

                TipoDeEntrada tipoEntrada = new TipoDeEntrada();
                tipoEntrada.setId(Int32.Parse(dgvTDE.CurrentRow.Cells[0].Value.ToString()));
                tipoEntrada.setDescripcion(txtDescripcionTDE.Text);

                if (OperacionTiposDeEntradas == NUEVO)
                {
                    if(entradasNeg.agregar(tipoEntrada))
                    {
                        MessageBox.Show("Se ha agregado el tipo de entrada con exito.", "Tipo de entrada agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescripcionTDE.Clear();
                        txtDescripcionTDE.Focus();

                        if(ActualizarDgvTDE())
                        {
                            tipoEntrada = entradasNeg.obtenerUltimo();

                            if(tipoEntrada != null)
                            {
                                seleccionarTDE(tipoEntrada.getId());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de entradas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if(ActualizarBoxTDE())
                        {
                            RemoverElementosBoxTDE();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de entradas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (OperacionTiposDeEntradas == MODIFICAR)
                {
                    if (entradasNeg.modificar(tipoEntrada))
                    {
                        MessageBox.Show("Se ha modificado el tipo de entrada con exito.", "Tipo de entrada modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        if (ActualizarDgvTDE())
                        {
                            seleccionarTDE(tipoEntrada.getId());
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de entradas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (ActualizarBoxTDE())
                        {
                            RemoverElementosBoxTDE();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de entradas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if(dgvPrecios.RowCount != 0)
                        {
                            int selectedRow = Int32.Parse(dgvPrecios.CurrentRow.Cells[0].Value.ToString());

                            if (ActualizarDgvPrecios())
                            {
                                seleccionarPrecio(selectedRow);
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Precios", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                MessageBox.Show("La descripcion no puede quedar vacia.", "Descripcion vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BoxCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(BoxCines.SelectedIndex == 0 || dgvPrecios.RowCount == 0) CerrarPanelPrecio();

            if(ActualizarDgvPrecios())
            {
                if (OperacionPrecios == NUEVO)
                {
                    if(ActualizarBoxTDE())
                    {
                        RemoverElementosBoxTDE();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de entradas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Precios", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BoxTDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BoxCines.SelectedIndex == 0 || dgvPrecios.RowCount == 0) CerrarPanelPrecio();

            if (ActualizarDgvPrecios())
            {
                if (OperacionPrecios == NUEVO)
                {
                    if (ActualizarBoxTDE())
                    {
                        RemoverElementosBoxTDE();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de entradas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Precios", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoPrecio_Click(object sender, EventArgs e)
        {
            if(BoxCines.SelectedIndex != 0)
            {
                if(BoxTDS.SelectedIndex != 0)
                {
                    ActualizarBoxTDE();
                    RemoverElementosBoxTDE();

                    OperacionPrecios = NUEVO;
                    AbrirPanelPrecio();
                    txtPrecio.Focus();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tipo de sala.", "Sin tipo de sala", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cine.", "Sin cine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificarPrecio_Click(object sender, EventArgs e)
        {
            if (BoxCines.SelectedIndex != 0)
            {
                if (BoxTDS.SelectedIndex != 0)
                {
                    if (dgvPrecios.RowCount != 0)
                    {
                        OperacionPrecios = MODIFICAR;
                        AbrirPanelPrecio();
                        txtPrecio.Text = dgvPrecios.CurrentRow.Cells[2].Value.ToString();
                        txtPrecio.Focus();
                        txtPrecio.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tipo de sala.", "Sin tipo de sala", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cine.", "Sin cine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolverPrecio_Click(object sender, EventArgs e)
        {
            CerrarPanelPrecio();
        }

        private void dgvPrecios_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionPrecios == MODIFICAR && dgvPrecios.CurrentRow != null)
            {
                txtPrecio.Text = dgvPrecios.CurrentRow.Cells[2].Value.ToString();
                txtPrecio.Focus();
                txtPrecio.SelectAll();
            }
        }

        private void btnGuardarPrecio_Click(object sender, EventArgs e)
        {
            if(boxTDE.SelectedIndex != 0)
            {
                if(txtPrecio.TextLength != 0)
                {
                    TipoDeEntrada tipoEntrada = new TipoDeEntrada();

                    Cine cine = new Cine();
                    cine.setId(Int32.Parse(BoxCines.SelectedValue.ToString()));

                    TipoDeSala tipoSala = new TipoDeSala();
                    tipoSala.setId(Int32.Parse(BoxTDS.SelectedValue.ToString()));

                    Precio precio = new Precio();
                    precio.setCine(cine);
                    precio.setTipoSala(tipoSala);
                    precio.setPrecio(Int32.Parse(txtPrecio.Text));

                    if(OperacionPrecios == NUEVO)
                    {
                        tipoEntrada.setId(Int32.Parse(boxTDE.SelectedValue.ToString()));
                        precio.setTipoEntrada(tipoEntrada);

                        if (precioNeg.agregar(precio))
                        {
                            MessageBox.Show("Se ha agregado el precio con exito.", "Precio agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPrecio.Clear();

                            if(ActualizarDgvPrecios())
                            {
                                if (ActualizarBoxTDE())
                                {
                                    RemoverElementosBoxTDE();
                                }
                                else
                                {
                                    MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de entradas", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Precios", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error en medio de la operacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if(OperacionPrecios == MODIFICAR)
                    {
                        tipoEntrada.setId(Int32.Parse(dgvPrecios.CurrentRow.Cells[0].Value.ToString()));
                        precio.setTipoEntrada(tipoEntrada);

                        if (precioNeg.modificar(precio))
                        {
                            MessageBox.Show("Se ha modificado el precio con exito.", "Precio modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            if (ActualizarDgvPrecios())
                            {
                                seleccionarPrecio(precio.getTipoEntrada().getId());
                                txtPrecio.Text = precio.getPrecio().ToString();
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Precios", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("El precio no puede quedar vacio.", "Sin precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de entrada.", "Sin tipo de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }

        private void seleccionarPrecio(int codigo)
        {
            for(int i=0; i<dgvPrecios.RowCount; i++)
            {
                if(dgvPrecios.Rows[i].Cells[0].Value.ToString() == codigo.ToString())
                {
                    dgvPrecios.CurrentCell = dgvPrecios.Rows[i].Cells[2];
                    dgvPrecios.Rows[i].Selected = true;
                }
            }
        }

        private void seleccionarTDE(int codigo)
        {
            for (int i=0; i<dgvTDE.RowCount; i++)
            {
                if (dgvTDE.Rows[i].Cells[0].Value.ToString() == codigo.ToString())
                {
                    dgvTDE.CurrentCell = dgvTDE.Rows[i].Cells[1];
                    dgvTDE.Rows[i].Selected = true;
                }
            }
        }

        private void RemoverElementosBoxTDE()
        {
            for (int i = 0; i < dgvPrecios.RowCount; i++)
            {
                for (int j = 0; j < dtTiposDeEntrada2.Rows.Count; j++)
                {
                    if (dtTiposDeEntrada2.Rows[j][0].ToString() == dgvPrecios.Rows[i].Cells[0].Value.ToString())
                    {
                        dtTiposDeEntrada2.Rows.RemoveAt(j);
                    }
                }
            }
        }
    }
}
