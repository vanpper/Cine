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
    public partial class Usuarios : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;
        const int MODIFICAR = 2;

        Conexion BD = new Conexion();
        DataTable DTUsuarios = new DataTable();
        DataTable DTProvincias = new DataTable();
        DataTable DTCiudades = new DataTable();
        DataTable DTTiposDeUsuarios = new DataTable();
        SqlDataAdapter adaptador;
        SqlCommand comando;

        int OperacionActual = 0;
        
        public Usuarios()
        {
            InitializeComponent();

            dgvUsuarios.DataSource = DTUsuarios;
            BoxProvincia.DataSource = DTProvincias;
            BoxCiudad.DataSource = DTCiudades;
            boxTipoDeUsuario.DataSource = DTTiposDeUsuarios;

            if (BD.Abrir())
            {
                ActualizarDgvUsuarios();
                ActualizarBoxProvincias();
                ActualizarBoxCiudades();
                ActualizarBoxTDU();
            }

            ConfigurarGrid();
        }

        private void ActualizarBoxTDU()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM TiposDeUsuarios", BD.conectarBD);
            DTTiposDeUsuarios.Clear();
            adaptador.Fill(DTTiposDeUsuarios);

            boxTipoDeUsuario.DisplayMember = "Descripcion_TDU";
            boxTipoDeUsuario.ValueMember = "CodTipoDeUsuario_TDU";
        }

        private void ActualizarBoxProvincias()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Provincias", BD.conectarBD);
            DTProvincias.Clear();
            adaptador.Fill(DTProvincias);

            BoxProvincia.DisplayMember = "Descripcion_Prov";
            BoxProvincia.ValueMember = "CodProvincia_Prov";
        }

        private void ActualizarBoxCiudades()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Ciudades WHERE CodProvincia_Ciud = " + BoxProvincia.SelectedValue, BD.conectarBD);
            DTCiudades.Clear();
            adaptador.Fill(DTCiudades);

            BoxCiudad.DisplayMember = "Descripcion_Ciud";
            BoxCiudad.ValueMember = "CodCiudad_Ciud";
        }

        private void LimpiarContenedores()
        {
            boxTipoDeUsuario.SelectedIndex = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCP.Clear();
            txtEmail.Clear();
            txtContraseña.Clear();
            dtpCumpleaños.Value = DateTime.Parse("01/01/2000");
            BoxProvincia.SelectedIndex = 0;
            BoxCiudad.SelectedIndex = 0;
            cbEstado.Checked = true;
        }

        private void ActualizarContenedores()
        {
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

        private void ActualizarDgvUsuarios()
        {
            adaptador = new SqlDataAdapter("SELECT CodUsuario_Usua, CodTipoDeUsuario_Usua, Descripcion_TDU, Nombre_Usua, Apellido_Usua, DNI_Usua, Cumpleaños_Usua, Telefono_Usua, CodProvincia_Usua, Descripcion_Prov, CodCiudad_Usua, Descripcion_Ciud, Direccion_Usua, CodigoPostal_Usua, Email_Usua, Contraseña_Usua, Estado_Usua FROM Usuarios INNER JOIN TiposDeUsuarios ON CodTipoDeUsuario_Usua = CodTipoDeUsuario_TDU INNER JOIN Provincias ON CodProvincia_Usua = CodProvincia_Prov INNER JOIN Ciudades ON CodProvincia_Usua = CodProvincia_Ciud AND CodCiudad_Usua = CodCiudad_Ciud", BD.conectarBD);
            DTUsuarios.Clear();
            adaptador.Fill(DTUsuarios);
        }

        private void AbrirPanel()
        {
            dgvUsuarios.Height = 232;
            panelUsuario.Visible = true;
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
        }

        private void CerrarPanel()
        {
            OperacionActual = NULL;
            panelUsuario.Visible = false;
            dgvUsuarios.Height = 394;
            btnNuevo.Visible = true;
            btnModificar.Visible = true;
            LimpiarContenedores();
        }

        private void ConfigurarGrid()
        {
            dgvUsuarios.Height = 394;

            dgvUsuarios.Columns[0].HeaderText = "Codigo Usuario";
            dgvUsuarios.Columns[1].HeaderText = "Codigo Tipo Usuario";
            dgvUsuarios.Columns[2].HeaderText = "Tipo Usuario";
            dgvUsuarios.Columns[3].HeaderText = "Nombre";
            dgvUsuarios.Columns[4].HeaderText = "Apellido";
            dgvUsuarios.Columns[5].HeaderText = "DNI";
            dgvUsuarios.Columns[6].HeaderText = "Cumpleaños";
            dgvUsuarios.Columns[7].HeaderText = "Telefono";
            dgvUsuarios.Columns[8].HeaderText = "Codigo Provincia";
            dgvUsuarios.Columns[9].HeaderText = "Provincia";
            dgvUsuarios.Columns[10].HeaderText = "Codigo Ciudad";
            dgvUsuarios.Columns[11].HeaderText = "Ciudad";
            dgvUsuarios.Columns[12].HeaderText = "Direccion";
            dgvUsuarios.Columns[13].HeaderText = "CP";
            dgvUsuarios.Columns[14].HeaderText = "Email";
            dgvUsuarios.Columns[15].HeaderText = "Contraseña";
            dgvUsuarios.Columns[16].HeaderText = "Estado";

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
            //dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //dgvUsuarios.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OperacionActual = NUEVO;
            AbrirPanel();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OperacionActual = MODIFICAR;
            AbrirPanel();
            ActualizarContenedores();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel();
        }

        private void BoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarBoxCiudades();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionActual == MODIFICAR)
            {
                ActualizarContenedores();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int enBlanco = 0;

            foreach (TextBox box in panelUsuario.Controls.OfType<TextBox>())
            {
                if(box.TextLength == 0)
                {
                    enBlanco++;
                }
            }

            if (enBlanco == 0)
            {
                if(BoxCiudad.SelectedItem != null)
                {
                    if (OperacionActual == NUEVO)
                    {
                        int NuevoCodigo = Int32.Parse(DTUsuarios.Compute("MAX(CodUsuario_Usua)", "").ToString()) + 1;
                        string FechaPanel = dtpCumpleaños.Value.ToShortDateString(); //FECHA SELECCIONADA EN EL PANEL INFERIOR
                        string[] partesFechaPanel = FechaPanel.Split('/'); //DIVIDIR LA FECHA EN DIA, MES, AÑO

                        comando = new SqlCommand("INSERT INTO Usuarios VALUES (" + NuevoCodigo + ", " + boxTipoDeUsuario.SelectedValue + ", '" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtDNI.Text + "', '" + partesFechaPanel[1]+"/"+ partesFechaPanel[0]+"/"+ partesFechaPanel[2] + "', '" + txtTelefono.Text + "', " + BoxProvincia.SelectedValue + ", " + BoxCiudad.SelectedValue + ", '" + txtDireccion.Text + "', '" + txtCP.Text + "', '" + txtEmail.Text + "', '" + txtContraseña.Text + "', '" + cbEstado.Checked + "')", BD.conectarBD);
                        comando.ExecuteNonQuery();
                        ActualizarDgvUsuarios();
                        LimpiarContenedores();
                    }

                    if (OperacionActual == MODIFICAR)
                    {
                        int SelectedIndex = dgvUsuarios.CurrentRow.Index;


                        string FechaPanel = dtpCumpleaños.Value.ToShortDateString(); //FECHA SELECCIONADA EN EL PANEL INFERIOR
                        string[] partesFechaPanel = FechaPanel.Split('/'); //DIVIDIR LA FECHA EN DIA, MES, AÑO

                        comando = new SqlCommand("UPDATE Usuarios SET CodTipoDeUsuario_Usua = " + boxTipoDeUsuario.SelectedValue + ", Nombre_Usua = '" + txtNombre.Text + "', Apellido_Usua = '" + txtApellido.Text + "', DNI_Usua = '" + txtDNI.Text + "', Cumpleaños_Usua = '" + partesFechaPanel[1]+"/"+ partesFechaPanel[0]+"/"+ partesFechaPanel[2] + "', Telefono_Usua = '" + txtTelefono.Text + "', CodProvincia_Usua = " + BoxProvincia.SelectedValue + ", CodCiudad_Usua = " + BoxCiudad.SelectedValue + ", Direccion_Usua = '" + txtDireccion.Text + "', CodigoPostal_Usua = '" + txtCP.Text + "', Email_Usua = '" + txtEmail.Text + "', Contraseña_Usua = '" + txtContraseña.Text + "', Estado_Usua = '" + cbEstado.Checked + "' WHERE CodUsuario_Usua = "+dgvUsuarios.CurrentRow.Cells[0].Value, BD.conectarBD);
                        comando.ExecuteNonQuery();

                        ActualizarDgvUsuarios();
                        dgvUsuarios.CurrentCell = dgvUsuarios.Rows[SelectedIndex].Cells[3];
                        dgvUsuarios.Rows[SelectedIndex].Selected = true;
                        ActualizarContenedores();
                    }
                }
            }
        }
    }
}
