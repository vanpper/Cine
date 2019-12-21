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
    public partial class Usuarios : Form
    {
        private IUsuarioNeg usuarioNeg = new UsuarioNeg();
        private IProvinciaNeg provinciaNeg = new ProvinciaNeg();
        private ICiudadNeg ciudadNeg = new CiudadNeg();
        private ITipoDeUsuarioNeg tipoNeg = new TipoDeUsuarioNeg();
        private DataTable dtUsuarios;
        private DataTable dtProvincias;
        private DataTable dtCiudades;
        private DataTable dtTiposDeUsuarios;

        private const int NULL = 0;
        private const int NUEVO = 1;
        private const int MODIFICAR = 2;

        private int OperacionActual = NULL;
        
        public Usuarios()
        {
            InitializeComponent();
            IniciarDtUsuarios();
            IniciarDtTiposDeUsuarios();
            IniciarDtProvincias();
            IniciarDtCiudades();

            if (!ActualizarDgvUsuarios())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Usuarios", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxTiposUsuario())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Tipos de usuario", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxProvincias())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Provincias", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!ActualizarBoxCiudades())
            {
                MessageBox.Show("Ha ocurrido un error al actualizar la lista de Ciudades", "Error actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            ConfigurarGrid();
        }

        private void IniciarDtUsuarios()
        {
            dtUsuarios = new DataTable();
            dtUsuarios.Columns.Add("Codigo Usuario");
            dtUsuarios.Columns.Add("Codigo Tipo de usuario");
            dtUsuarios.Columns.Add("Tipo de usuario");
            dtUsuarios.Columns.Add("Nombre");
            dtUsuarios.Columns.Add("Apellido");
            dtUsuarios.Columns.Add("DNI");
            dtUsuarios.Columns.Add("Cumpleaños");
            dtUsuarios.Columns.Add("Telefono");
            dtUsuarios.Columns.Add("Codigo Provincia");
            dtUsuarios.Columns.Add("Provincia");
            dtUsuarios.Columns.Add("Codigo Ciudad");
            dtUsuarios.Columns.Add("Ciudad");
            dtUsuarios.Columns.Add("Direccion");
            dtUsuarios.Columns.Add("CP");
            dtUsuarios.Columns.Add("Email");
            dtUsuarios.Columns.Add("Contraseña");
            dtUsuarios.Columns.Add("Estado");
            dgvUsuarios.DataSource = dtUsuarios;
        }

        private void IniciarDtTiposDeUsuarios()
        {
            dtTiposDeUsuarios = new DataTable();
            dtTiposDeUsuarios.Columns.Add("Codigo");
            dtTiposDeUsuarios.Columns.Add("Descripcion");
            boxTipoDeUsuario.DataSource = dtTiposDeUsuarios;
        }

        private void IniciarDtProvincias()
        {
            dtProvincias = new DataTable();
            dtProvincias.Columns.Add("Codigo");
            dtProvincias.Columns.Add("Descripcion");
            BoxProvincia.DataSource = dtProvincias;
        }

        private void IniciarDtCiudades()
        {
            dtCiudades = new DataTable();
            dtCiudades.Columns.Add("Codigo");
            dtCiudades.Columns.Add("Descripcion");
            BoxCiudad.DataSource = dtCiudades;
        }

        private bool ActualizarDgvUsuarios()
        {
            List<Usuario> lista = usuarioNeg.obtenerTodos();
            if (lista == null) return false;

            dtUsuarios.Clear();

            foreach(Usuario usuario in lista)
            {
                DataRow row = dtUsuarios.NewRow();
                row[0] = usuario.getId();
                row[1] = usuario.getTipo().getId();
                row[2] = usuario.getTipo().getDescripcion();
                row[3] = usuario.getNombre();
                row[4] = usuario.getApellido();
                row[5] = usuario.getDni();
                row[6] = usuario.getCumpleaños();
                row[7] = usuario.getTelefono();
                row[8] = usuario.getCiudad().getProvincia().getId();
                row[9] = usuario.getCiudad().getProvincia().getDescripcion();
                row[10] = usuario.getCiudad().getId();
                row[11] = usuario.getCiudad().getDescripcion();
                row[12] = usuario.getDireccion();
                row[13] = usuario.getCp();
                row[14] = usuario.getEmail();
                row[15] = usuario.getContraseña();
                row[16] = usuario.getEstado();
                dtUsuarios.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarBoxTiposUsuario()
        {
            dtTiposDeUsuarios.Clear();

            boxTipoDeUsuario.DisplayMember = "Descripcion";
            boxTipoDeUsuario.ValueMember = "Codigo";

            DataRow firstRow = dtTiposDeUsuarios.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SELECCIONE ---";
            dtTiposDeUsuarios.Rows.Add(firstRow);

            List<TipoDeUsuario> lista = tipoNeg.obtenerTodos();
            if (lista == null) return false;

            foreach(TipoDeUsuario tipo in lista)
            {
                DataRow row = dtTiposDeUsuarios.NewRow();
                row[0] = tipo.getId();
                row[1] = tipo.getDescripcion();
                dtTiposDeUsuarios.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarBoxProvincias()
        {
            dtProvincias.Clear();

            BoxProvincia.DisplayMember = "Descripcion";
            BoxProvincia.ValueMember = "Codigo";

            DataRow firstRow = dtProvincias.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SELECCIONE ---";
            dtProvincias.Rows.Add(firstRow);

            List<Provincia> lista = provinciaNeg.obtenerTodas();
            if (lista == null) return false;

            foreach (Provincia provincia in lista)
            {
                DataRow row = dtProvincias.NewRow();
                row[0] = provincia.getId();
                row[1] = provincia.getDescripcion();
                dtProvincias.Rows.Add(row);
            }

            return true;
        }

        private bool ActualizarBoxCiudades()
        {
            dtCiudades.Clear();

            BoxCiudad.DisplayMember = "Descripcion";
            BoxCiudad.ValueMember = "Codigo";

            DataRow firstRow = dtCiudades.NewRow();
            firstRow[0] = 0;
            firstRow[1] = "--- SELECCIONE ---";
            dtCiudades.Rows.Add(firstRow);

            List<Ciudad> lista = ciudadNeg.obtenerTodas(Int32.Parse(BoxProvincia.SelectedValue.ToString()));
            if (lista == null) return false;

            foreach (Ciudad ciudad in lista)
            {
                DataRow row = dtCiudades.NewRow();
                row[0] = ciudad.getId();
                row[1] = ciudad.getDescripcion();
                dtCiudades.Rows.Add(row);
            }

            return true;
        }

        private void ConfigurarGrid()
        {
            dgvUsuarios.Height = 394;
            dgvUsuarios.Columns[0].Visible = false;
            dgvUsuarios.Columns[1].Visible = false;
            dgvUsuarios.Columns[8].Visible = false;
            dgvUsuarios.Columns[10].Visible = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.AllowUserToResizeColumns = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        

       

        private void LimpiarContenedores()
        {
            //LIMPIAR LOS CONTENEDORES

            boxTipoDeUsuario.SelectedIndex = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCP.Clear();
            txtEmail.Clear();
            txtContraseña.Clear();
            dtpCumpleaños.Value = DateTime.Today;
            BoxProvincia.SelectedIndex = 0;
            BoxCiudad.SelectedIndex = 0;
            cbEstado.Checked = true;
        }

        private void ActualizarContenedores()
        {
            //LLENAR LOS CONTENEDORES CON LOS DATOS DE LA FILA SELECCIONADA

            try
            {
                boxTipoDeUsuario.SelectedValue = dgvUsuarios.CurrentRow.Cells[1].Value;
                txtNombre.Text = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
                txtApellido.Text = dgvUsuarios.CurrentRow.Cells[4].Value.ToString();
                txtDNI.Text = dgvUsuarios.CurrentRow.Cells[5].Value.ToString();
                txtTelefono.Text = dgvUsuarios.CurrentRow.Cells[7].Value.ToString();
                txtDireccion.Text = dgvUsuarios.CurrentRow.Cells[12].Value.ToString();
                txtCP.Text = dgvUsuarios.CurrentRow.Cells[13].Value.ToString();
                txtEmail.Text = dgvUsuarios.CurrentRow.Cells[14].Value.ToString();
                txtContraseña.Text = dgvUsuarios.CurrentRow.Cells[15].Value.ToString();
                dtpCumpleaños.Value = DateTime.Parse(dgvUsuarios.CurrentRow.Cells[6].Value.ToString());
                BoxProvincia.SelectedValue = dgvUsuarios.CurrentRow.Cells[8].Value;
                BoxCiudad.SelectedValue = dgvUsuarios.CurrentRow.Cells[10].Value;
                cbEstado.Checked = bool.Parse(dgvUsuarios.CurrentRow.Cells[16].Value.ToString());
            }
            catch(Exception ex) { }
        }

        

        private void AbrirPanel()
        {
            dgvUsuarios.Height = 232; //ACHICAR DATAGRID
            panelUsuario.Visible = true; //MOSTRAR PANEL
            btnNuevo.Visible = false; //OCULTAR BOTON "NUEVO"
            btnModificar.Visible = false; //OCULTAR BOTON "MODIFICAR"
        }

        private void CerrarPanel()
        {
            OperacionActual = NULL; //ASIGNAR OPERACION ACTUAL COMO "NULO"
            panelUsuario.Visible = false; //OCULTAR PANEL
            dgvUsuarios.Height = 394; //AGRANDAR DATAGRID
            btnNuevo.Visible = true; //MOSTRAR BOTON "NUEVO"
            btnModificar.Visible = true; //MOSTRAR BOTON "MODIFICAR"
            LimpiarContenedores(); //LIMPIAR CONTENEDORES
        }

        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OperacionActual = NUEVO; //ASIGNAR OPERACION ACTUAL COMO "NUEVO"
            AbrirPanel(); //ABRIR PANEL
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OperacionActual = MODIFICAR; //ASIGNAR OPERACION ACTUAL COMO "MODIFICAR"
            AbrirPanel(); //ABRIR PANEL
            ActualizarContenedores(); //LLENAR LOS CONTENEDORES CON EL REGISTRO SELECCIONADO DEL DATAGRID
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel(); //CERRAR EL PANEL
        }

        private void BoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarBoxCiudades(); //LLENAR BOX CON LAS CIUDADES DE LA PROVINCIA SELECCIONADA
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionActual == MODIFICAR) //SI SE ESTA MODIFICANDO...
            {
                ActualizarContenedores(); //ACTUALIZAR LOS CONTENEDORES CON EL REGISTRO SELECCIONADO DEL DATAGRID
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void seleccionarUsuario(String codigo)
        {
            for(int i=0; i<dgvUsuarios.RowCount; i++) //RECORRER TODO EL DATAGRID
            {
                if(dgvUsuarios.Rows[i].Cells[0].Value.ToString() == codigo) //SI EL CODIGO DE LA FILA COINCIDE CON EL CODIGO BUSCADO
                {
                    dgvUsuarios.CurrentCell = dgvUsuarios.Rows[i].Cells[3]; //SELECCIONAR REGISTRO
                    dgvUsuarios.Rows[i].Selected = true; //SELECCIONAR EL REGISTRO
                }
            }
        }
        
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }

        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }
    }
}
