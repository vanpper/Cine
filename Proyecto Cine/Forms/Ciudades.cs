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
    public partial class Ciudades : Form
    {
        private IProvinciaNeg provinciaNeg = new ProvinciaNeg();
        private ICiudadNeg ciudadNeg = new CiudadNeg();

        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2; 
        private const int PROVINCIAS = 3;
        private const int CIUDADES = 4;

        private int Operacion = NULL;
        private int Entidad = NULL;

        public Ciudades()
        {
            InitializeComponent();

            if (ActualizarDgvProvincias())
            {
                if(!ActualizarDgvCiudades()) MessageBox.Show("Fallo al recuperar ciudades", "Ha ocurrido un error al intentar recuperar las ciudades desde la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Fallo al recuperar provincias", "Ha ocurrido un error al intentar recuperar las provincias desde la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConfigurarGrids();
        }

        private void ConfigurarGrids()
        {
            dgvProvincias.Size = new Size(450, dgvProvincias.Size.Height);
            dgvProvincias.ReadOnly = true;
            dgvProvincias.AllowUserToAddRows = false;
            dgvProvincias.RowHeadersVisible = false;
            dgvProvincias.AllowUserToResizeColumns = false;
            dgvProvincias.AllowUserToResizeRows = false;
            dgvProvincias.MultiSelect = false;
            dgvProvincias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProvincias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProvincias.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProvincias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            

            if(dgvProvincias.DataSource != null)
            {
                dgvProvincias.Columns[0].Visible = false;
                dgvProvincias.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvProvincias.Sort(dgvProvincias.Columns[1], ListSortDirection.Ascending);
            }

            dgvCiudades.Size = new Size(455, dgvCiudades.Size.Height);
            dgvCiudades.Location = new Point(480, dgvCiudades.Location.Y);
            dgvCiudades.ReadOnly = true;
            dgvCiudades.AllowUserToAddRows = false;
            dgvCiudades.RowHeadersVisible = false;
            dgvCiudades.AllowUserToResizeColumns = false;
            dgvCiudades.AllowUserToResizeRows = false;
            dgvCiudades.MultiSelect = false;
            dgvCiudades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCiudades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCiudades.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCiudades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            if(dgvCiudades.DataSource != null)
            {
                dgvCiudades.Columns[0].Visible = false;
                dgvCiudades.Columns[1].Visible = false;
                dgvCiudades.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvCiudades.Sort(dgvCiudades.Columns[2], ListSortDirection.Ascending);
            }
        }

        private void AbrirPanel()
        {
            dgvProvincias.Width = 300;
            dgvCiudades.Width = 300;
            dgvCiudades.Location = new Point(636, dgvCiudades.Location.Y);
            panel1.Visible = true;
        }

        private void CerrarPanel()
        {
            panel1.Visible = false;
            dgvProvincias.Width = 450;
            dgvCiudades.Width = 455;
            dgvCiudades.Location = new Point(480, dgvCiudades.Location.Y);
            txtDescripcion.Clear();
            label2.Text = "";
            Operacion = NULL;
            Entidad = NULL;
        }

        private bool ActualizarDgvProvincias()
        {
            DataTable dt = provinciaNeg.obtenerTodasDataTable();
            if (dt == null) return false;

            dgvProvincias.DataSource = dt;
            return true;
        }

        private bool ActualizarDgvCiudades()
        {
            int idProvincia = Int32.Parse(dgvProvincias.Rows[0].Cells[0].Value.ToString());

            DataTable dt = ciudadNeg.obtenerTodasDataTable(idProvincia);
            if (dt == null) return false;

            dgvCiudades.DataSource = dt;
            return true;
        }

        private bool ActualizarDgvCiudades(int idProvincia)
        {
            DataTable dt = ciudadNeg.obtenerTodasDataTable(idProvincia);
            if (dt == null) return false;

            dgvCiudades.DataSource = dt;
            return true;
        }

        private void ActualizarGrids()
        {
           
        }

        private void dgvProvincias_SelectionChanged(object sender, EventArgs e)
        {
            if(ActualizarDgvCiudades(Int32.Parse(dgvProvincias.CurrentRow.Cells[0].Value.ToString())))
            {
                if (Entidad == PROVINCIAS && Operacion == MODIFICAR)
                {
                    txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString();
                    txtDescripcion.SelectAll();
                    txtDescripcion.Focus();
                }

                if (Entidad == CIUDADES && Operacion == MODIFICAR)
                {
                    if (dgvCiudades.RowCount == 0)
                    {
                        CerrarPanel();
                    }
                }
            }
            else
            {
                MessageBox.Show("Fallo al recuperar ciudades", "Ha ocurrido un error al intentar recuperar las ciudades desde la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCiudades_SelectionChanged(object sender, EventArgs e)
        {
            if(Entidad == CIUDADES && Operacion == MODIFICAR)
            {
                txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.SelectAll();
                txtDescripcion.Focus();
            }
        }

        private void btnNuevaProvincia_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                AbrirPanel();
                label2.Text = "AGREGAR NUEVA PROVINCIA";
                label2.Location = new Point(45,label2.Location.Y);
                txtDescripcion.Focus();
                Entidad = PROVINCIAS;
                Operacion = NUEVO;
            }
        }

        private void btnNuevaCiudad_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                AbrirPanel();
                label2.Text = "AGREGAR NUEVA CIUDAD";
                label2.Location = new Point(60, label2.Location.Y);
                txtDescripcion.Focus();
                Entidad = CIUDADES;
                Operacion = NUEVO;
            }
        }

        private void btnModificarProvincia_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                if(dgvProvincias.RowCount != 0)
                {
                    AbrirPanel();
                    label2.Text = "MODIFICAR PROVINCIA";
                    label2.Location = new Point(60, label2.Location.Y);
                    txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString();
                    txtDescripcion.Focus();
                    Entidad = PROVINCIAS;
                    Operacion = MODIFICAR;
                }
            }
        }

        private void btnModificarCiudad_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                if(dgvCiudades.RowCount != 0)
                {
                    AbrirPanel();
                    label2.Text = "MODIFICAR CIUDAD";
                    label2.Location = new Point(75, label2.Location.Y);
                    txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString();
                    txtDescripcion.Focus();
                    Entidad = CIUDADES;
                    Operacion = MODIFICAR;
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.TextLength != 0)
            {
                if (Operacion == NUEVO)
                {
                    if (Entidad == PROVINCIAS)
                    {
                        Provincia provincia = new Provincia();
                        provincia.setDescripcion(txtDescripcion.Text);

                        if (provinciaNeg.agregar(provincia))
                        {
                            ActualizarDgvProvincias();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Ha ocurrido un error al intentar agregar la nueva provincia.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }

                    if (Entidad == CIUDADES)
                    {

                        
                        
                    }

                    txtDescripcion.Clear();
                    txtDescripcion.Focus();
                }

                if (Operacion == MODIFICAR) //SI SE VA A MODIFICAR
                {
                    if (Entidad == PROVINCIAS) //SI LA ENTIDAD QUE OPERA ES PROVINCIAS
                    {

                    }

                    if (Entidad == CIUDADES) //SI LA ENTIDAD QUE OPERA ES CIUDADES
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("El nombre no puede quedar vacio.\nPor favor ingrese una descripcion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void seleccionarFilaProvincias(int codigo)
        {
            for (int i = 0; i < dgvProvincias.RowCount; i++) //RECORRER TODO EL DATAGRID PROVINCIAS
            {
                if (dgvProvincias.Rows[i].Cells[0].Value.ToString() == codigo.ToString()) //SE BUSCA LA FILA A TRAVES DEL CODIGO PROVINCIA. SI SE ENCUENTRA...
                {
                    dgvProvincias.CurrentCell = dgvProvincias.Rows[i].Cells[1]; 
                    dgvProvincias.Rows[i].Selected = true; //SELECCIONAR EL REGISTRO                
                }
            }
        }

        private void seleccionarFilaCiudades(int codigo)
        {
            for (int i = 0; i < dgvCiudades.RowCount; i++) //RECORRER TODO EL DATAGRID CIUDADES
            {
                if (dgvCiudades.Rows[i].Cells[1].Value.ToString() == codigo.ToString()) //SI LA FILA COINCIDE CON EL CODIGO CIUDAD
                {
                    dgvCiudades.CurrentCell = dgvCiudades.Rows[i].Cells[2]; //SELECCIONAR EL REGISTRO
                    dgvCiudades.Rows[i].Selected = true; //SELECCIONAR EL REGISTRO  
                }
            }
        }
    }
}
