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

            ActualizarDgvProvincias();

            ActualizarDgvCiudades();

            ConfigurarGrids();

            
        }

        private void ConfigurarGrids()
        {
            dgvProvincias.Size = new Size(450, dgvProvincias.Size.Height);
            dgvProvincias.Columns[0].Visible = false;
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
            dgvProvincias.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProvincias.Sort(dgvProvincias.Columns[1], ListSortDirection.Ascending);

            dgvCiudades.Size = new Size(455, dgvCiudades.Size.Height);
            dgvCiudades.Location = new Point(480, dgvCiudades.Location.Y);
            dgvCiudades.Columns[0].Visible = false;
            dgvCiudades.Columns[1].Visible = false;
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
            dgvCiudades.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCiudades.Sort(dgvCiudades.Columns[2], ListSortDirection.Ascending);
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

        private void ActualizarDgvProvincias()
        {
            dgvProvincias.DataSource = null;
            dgvProvincias.DataSource = provinciaNeg.obtenerDataTable();
        }

        private void ActualizarDgvCiudades()
        {
            dgvCiudades.DataSource = null;
            dgvCiudades.DataSource = ciudadNeg.obtenerDataTable(Int32.Parse(dgvProvincias.Rows[0].Cells[0].Value.ToString()));
        }

        private void ActualizarDgvCiudades(int idProvincia)
        {
            dgvCiudades.DataSource = null;
            dgvCiudades.DataSource = ciudadNeg.obtenerDataTable(idProvincia);
        }

        private void ActualizarGrids()
        {
           
        }

        private void dgvProvincias_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarDgvCiudades(Int32.Parse(dgvProvincias.CurrentRow.Cells[0].Value.ToString())); //ES PROBABLE QUE NECESITE UN TRY
        
            if(Entidad == PROVINCIAS && Operacion == MODIFICAR) //SI SE ESTA MODIFICANDO UNA PROVINCIA
            {
                try
                {
                    txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString(); //LLENAR TEXTBOX CON LA PROVINCIA SELECCIONADA
                    txtDescripcion.SelectAll(); //SELECCIONAR TODO EL TEXTO DEL TEXTBOX
                    txtDescripcion.Focus(); //DARLE EL FOCO AL TEXTBOX
                }
                catch (Exception x) { }
            }
            
            if(Entidad == CIUDADES && Operacion == MODIFICAR) //SI SE ESTA MODIFICANDO UNA CIUDAD
            {
                if(dgvCiudades.RowCount == 0) //Y NO HAY CIUDADES CARGADAS EN LA PROVNCIA
                {   
                    CerrarPanel(); //CERRAR EL PANEL
                }
            }
        }

        private void dgvCiudades_SelectionChanged(object sender, EventArgs e)
        {
            if(Entidad == CIUDADES && Operacion == MODIFICAR) //SI SE ESTA MODIFICANDO UNA CIUDAD
            {
                try
                {
                    txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString(); //LLENAR TEXTBOX CON LA CIUDAD SELECCIONADA
                    txtDescripcion.SelectAll(); //SELECCIONAR TODO EL TEXTO DEL TEXTBOX
                    txtDescripcion.Focus(); //DARLE EL FOCO AL TEXTBOX
                }
                catch (Exception x) { }
            
            }
        }

        private void btnNuevaProvincia_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
            {
                AbrirPanel(); //ABRIR EL PANEL
                label2.Text = "AGREGAR NUEVA PROVINCIA"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                label2.Location = new Point(45,label2.Location.Y); //REACOMODAR LABEL
                txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                Entidad = PROVINCIAS; //LA ENTIDAD QUE OPERA ES PROVINCIAS
                Operacion = NUEVO; //LA OPERACION EN CURSO ES AGREGAR UN NUEVO REGISTRO
            }
        }

        private void btnNuevaCiudad_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
            {
                AbrirPanel(); //ABRIR EL PANEL
                label2.Text = "AGREGAR NUEVA CIUDAD"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                label2.Location = new Point(60, label2.Location.Y); //REACOMODAR LABEL
                txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                Entidad = CIUDADES; //LA ENTIDAD QUE OPERA ES CIUDADES
                Operacion = NUEVO; //LA OPERACION EN CURSO ES AGREGAR UN NUEVO REGISTRO
            }
        }

        private void btnModificarProvincia_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
            {
                if(dgvProvincias.RowCount != 0) //SI HAY PROVINCIAS CARGADAS
                {
                    AbrirPanel(); //ABRIR EL PANEL
                    label2.Text = "MODIFICAR PROVINCIA"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                    label2.Location = new Point(60, label2.Location.Y); //UBICAR LABEL
                    txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString(); //CARGAR EN EL TEXTBOX LA PROVINCIA SELECCIONADA
                    txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    Entidad = PROVINCIAS; //LA ENTIDAD QUE OPERA ES PROVINCIAS
                    Operacion = MODIFICAR; //LA OPERACION EN CURSO ES MODIFICAR UN REGISTRO EXISTENTE
                }
            }
        }

        private void btnModificarCiudad_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
            {
                if(dgvCiudades.RowCount != 0) //SI HAY CIUDADES CARGADAS EN LA PROVINCIA SELECCIONADA
                {
                    AbrirPanel(); //ABRIR EL PANEL
                    label2.Text = "MODIFICAR CIUDAD"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                    label2.Location = new Point(75, label2.Location.Y); //REACOMODAR LABEL
                    txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString(); //CARGAR EN EL TEXTBOX LA CIUDAD SELECCIONADA
                    txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    Entidad = CIUDADES; //LA ENTIDAD QUE OPERA ES CIUDADES
                    Operacion = MODIFICAR; //LA OPERACION EN CURSO ES MODIFICAR UN REGISTRO EXISTENTE
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel(); //CERRAR EL PANEL
        }

        private void Guardar()
        {
            if (txtDescripcion.TextLength != 0) //SI EL TEXTBOX NO ESTA EN BLANCO
            {
                if (Operacion == NUEVO) //SI SE VA A AGREGAR UN NUEVO REGISTRO
                {
                   if (Entidad == PROVINCIAS) //SI LA ENTIDAD QUE OPERA ES PROVINCIAS
                    {
                       
                        txtDescripcion.Clear(); //LIMPIAR EL TEXTBOX
                        txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    }

                    if (Entidad == CIUDADES) //SI LA ENTIDAD QUE OPERA ES CIUDADES
                    {
                       
                        txtDescripcion.Clear(); //LIMPIAR EL TEXTBOX
                        txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    }
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
            else //SI EL TEXTBOX ESTA VACIO
            {
                MessageBox.Show("El nombre no puede quedar vacio.\nPor favor ingrese una descripcion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(); //GUARDAR LA OPERACION
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) //SI SE APRIETA ENTER CUANDO SE CREA O MODIFICA
            {
                Guardar(); //GUARDAR LA OPERACION
            }

            if (Convert.ToInt32(e.KeyChar) == 27) //SI SE APRIETA ESCAPE CUANDO SE CREA O MODIFICA
            {
                CerrarPanel(); //CERRAR EL PANEL
            }
        }

        private void dgvProvincias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N) //SI LA TECLA APRETADA ES N
            {
                if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
                {
                    AbrirPanel(); //ABRIR EL PANEL
                    label2.Text = "AGREGAR NUEVA PROVINCIA"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                    label2.Location = new Point(25, label2.Location.Y); //REACOMODAR LABEL
                    txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    Entidad = PROVINCIAS; //LA ENTIDAD QUE OPERA ES PROVINCIAS
                    Operacion = NUEVO; //LA OPERACION EN CURSO ES AGREGAR UN NUEVO REGISTRO
                }
            }

            if (e.KeyCode == Keys.M) //SI LA TECLA APRETADA ES M
            {
                if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
                {
                    if (dgvProvincias.RowCount != 0) //SI HAY PROVINCIAS CARGADAS
                    {
                        AbrirPanel(); //ABRIR EL PANEL
                        label2.Text = "MODIFICAR PROVINCIA"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                        label2.Location = new Point(50, label2.Location.Y); //UBICAR LABEL
                        txtDescripcion.Text = dgvProvincias.CurrentRow.Cells[1].Value.ToString(); //CARGAR EN EL TEXTBOX LA PROVINCIA SELECCIONADA
                        txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                        Entidad = PROVINCIAS; //LA ENTIDAD QUE OPERA ES PROVINCIAS
                        Operacion = MODIFICAR; //LA OPERACION EN CURSO ES MODIFICAR UN REGISTRO EXISTENTE
                    }
                }
            }

            if (e.KeyCode == Keys.Right) //SI LA TECLA ES LA FLECHA DERECHA
            {
                if (dgvCiudades.RowCount != 0) dgvCiudades.Focus(); //SI EL DATAGRID DE CIUDADES NO ESTA VACIO, DARLE EL FOCO
            }
        }

        private void dgvCiudades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N) //SI LA TECLA APRETADA ES N o n
            {
                if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
                {
                    AbrirPanel(); //ABRIR EL PANEL
                    label2.Text = "AGREGAR NUEVA CIUDAD"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                    label2.Location = new Point(35, label2.Location.Y); //REACOMODAR LABEL
                    txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                    Entidad = CIUDADES; //LA ENTIDAD QUE OPERA ES CIUDADES
                    Operacion = NUEVO; //LA OPERACION EN CURSO ES AGREGAR UN NUEVO REGISTRO
                }
            }

            if (e.KeyCode == Keys.M) //SI LA TECLA APRETADA ES M o m
            {
                if (panel1.Visible == false) //SI EL PANEL ESTA CERRADO
                {
                    if (dgvCiudades.RowCount != 0) //SI HAY CIUDADES CARGADAS EN LA PROVINCIA SELECCIONADA
                    {
                        AbrirPanel(); //ABRIR EL PANEL
                        label2.Text = "MODIFICAR CIUDAD"; //CAMBIAR EL TEXTO DEL TITULO DE ACUERDO A LA OPERACION SELECCIONADA
                        label2.Location = new Point(65, label2.Location.Y); //REACOMODAR LABEL
                        txtDescripcion.Text = dgvCiudades.CurrentRow.Cells[2].Value.ToString(); //CARGAR EN EL TEXTBOX LA CIUDAD SELECCIONADA
                        txtDescripcion.Focus(); //DARLE FOCO AL TEXTBOX
                        Entidad = CIUDADES; //LA ENTIDAD QUE OPERA ES CIUDADES
                        Operacion = MODIFICAR; //LA OPERACION EN CURSO ES MODIFICAR UN REGISTRO EXISTENTE
                    }
                }
            }

            if (e.KeyCode == Keys.Left) dgvProvincias.Focus(); //SI LA TECLA ES LA FLECHA IZQUIERDA, DARLE FOCO AL DATAGRID PROVINCIAS
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
