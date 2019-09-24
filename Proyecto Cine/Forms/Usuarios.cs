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
        const int NUEVO = 1;        //CONSTANTES
        const int MODIFICAR = 2;

        Conexion BD = new Conexion();
        DataTable DTUsuarios = new DataTable();
        DataTable DTProvincias = new DataTable();
        DataTable DTCiudades = new DataTable();
        DataTable DTTiposDeUsuarios = new DataTable();
        SqlDataAdapter adaptador;
        SqlCommand comando;

        int OperacionActual = 0; //INDICADOR DE OPERACION ACTUAL
        
        public Usuarios()
        {
            InitializeComponent();

            dgvUsuarios.DataSource = DTUsuarios; //LA FUENTE DE DATOS DEL DATAGRID ES EL DATATABLE USUARIOS
            BoxProvincia.DataSource = DTProvincias; //LA FUENTE DE DATOS DEL BOX PROVINCIAS ES EL DATATABLE PROVINCIAS
            BoxCiudad.DataSource = DTCiudades; //LA FUENTE DE DATOS DEL BOX CIUDAD ES EL DATATBLE CIUDADES
            boxTipoDeUsuario.DataSource = DTTiposDeUsuarios; //LA FUENTE DE DATOS DEL BOX TIPO DE USUARIOS ES EL DATATABLE TIPOS DE USUARIOS

            if (BD.Abrir()) //SI SE PUDO ABRIR LA CONEXION CON LA BASE DATOS...
            {
                ActualizarDgvUsuarios(); //ACTUALIZAR DATAGRID USUARIOS
                ActualizarBoxProvincias(); //ACTUALIZAR BOX PROVINCIAS
                ActualizarBoxCiudades(); //ACTUALIZAR BOX CIUDADES
                ActualizarBoxTDU(); //ACTUALIZAR BOX TIPOS DE USUARIOS
            }

            ConfigurarGrid(); //CONFIGURACION RELACIONADA CON LA APARIENCIA DEL DATAGRID
        }

        private void ActualizarBoxTDU()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM TiposDeUsuarios", BD.conectarBD); //TRAER TODOS LOS TIPOS DE USUARIO
            DTTiposDeUsuarios.Clear(); //LIMPIAR DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTTiposDeUsuarios); //LLENAR DATATABLE CON LOS NUEVOS REGISTROS

            DTTiposDeUsuarios.DefaultView.Sort = "Descripcion_TDU"; //ORDENAR ALAFABETICAMENTE

            boxTipoDeUsuario.DisplayMember = "Descripcion_TDU"; //MOSTRAR DESCRIPCION
            boxTipoDeUsuario.ValueMember = "CodTipoDeUsuario_TDU"; //ASIGNAR COMO VALOR EL CODIGO
        }

        private void ActualizarBoxProvincias()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Provincias", BD.conectarBD); //TRAER TODAS LAS PROVINCIAS
            DTProvincias.Clear(); //LIMPIAR DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTProvincias); //LLENAR DATATABLE CON LOS NUEVOS REGISTROS

            DTProvincias.DefaultView.Sort = "Descripcion_Prov"; //ORDENAR ALFABETICAMENTE

            BoxProvincia.DisplayMember = "Descripcion_Prov"; //MOSTRAR DESCRIPCION
            BoxProvincia.ValueMember = "CodProvincia_Prov"; //ASIGNAR COMO VALOR EL CODIGO
        }

        private void ActualizarBoxCiudades()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Ciudades WHERE CodProvincia_Ciud = " + BoxProvincia.SelectedValue, BD.conectarBD); //TRAER TODAS LAS CIUDADES
            DTCiudades.Clear(); //LIMPIAR DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTCiudades); //LLENAR DATATABLE CON LOS NUEVOS REGISTROS

            DTCiudades.DefaultView.Sort = "Descripcion_Ciud"; //ORDENAR ALFABETICAMENTE

            BoxCiudad.DisplayMember = "Descripcion_Ciud"; //MOSTRAR DESCRIPCION
            BoxCiudad.ValueMember = "CodCiudad_Ciud"; //ASIGNAR COMO VALOR EL CODIGO
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
            dtpCumpleaños.Value = DateTime.Parse("01/01/2000");
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

        private void ActualizarDgvUsuarios()
        {
            //TRAER TODOS LOS USUARIOS
            adaptador = new SqlDataAdapter("SELECT CodUsuario_Usua, CodTipoDeUsuario_Usua, Descripcion_TDU, Nombre_Usua, Apellido_Usua, DNI_Usua, Cumpleaños_Usua, Telefono_Usua, CodProvincia_Usua, Descripcion_Prov, CodCiudad_Usua, Descripcion_Ciud, Direccion_Usua, CodigoPostal_Usua, Email_Usua, Contraseña_Usua, Estado_Usua FROM Usuarios INNER JOIN TiposDeUsuarios ON CodTipoDeUsuario_Usua = CodTipoDeUsuario_TDU INNER JOIN Provincias ON CodProvincia_Usua = CodProvincia_Prov INNER JOIN Ciudades ON CodProvincia_Usua = CodProvincia_Ciud AND CodCiudad_Usua = CodCiudad_Ciud", BD.conectarBD);
            DTUsuarios.Clear(); //LIMPIAR DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTUsuarios); //LLENAR DATATABLE CON LOS NUEVOS REGISTROS
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
            dgvUsuarios.Sort(dgvUsuarios.Columns[3], ListSortDirection.Ascending);
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
            int enBlanco = 0; //VARIABLE QUE CUENTA LA CANTIDAD DE CONTENEDORES QUE QUEDARON VACIOS

            foreach (TextBox box in panelUsuario.Controls.OfType<TextBox>()) //RECORRER TODOS LOS TEXTBOXS DEL PANEL
            {
                if(box.TextLength == 0) //SI EL TEXTBOX ESTA VACIO...
                {
                    enBlanco++; //AUMENTAR EN 1 LA VARIABLE
                    box.BackColor = Color.Red; //CAMBIAR COLOR DE TEXTBOX
                }
            }

            if (enBlanco == 0) //SI NO HAY NINGUN TEXTBOX VACIO...
            {
                if(BoxCiudad.SelectedItem != null) //SI HAY UNA CIUDAD SELECCIONADA... (YA QUE ES POSIBLE QUE UNA PROVINCIA TODAVIA NO TENGA CIUDADES CARGADAS)
                {
                    if (OperacionActual == NUEVO) //SI SE ESTA AGREGANDO UN NUEVO USUARIO
                    {
                        int NuevoCodigo = Int32.Parse(DTUsuarios.Compute("MAX(CodUsuario_Usua)", "").ToString()) + 1; //GENERAR NUEVO CODIGO OBTENIENDO EL ULTIMO REGISTRADO + 1
                        string FechaPanel = dtpCumpleaños.Value.ToShortDateString(); //OBTENER FECHA SELECCIONADA EN EL PANEL INFERIOR
                        string[] partesFechaPanel = FechaPanel.Split('/'); //DIVIDIR LA FECHA EN DIA, MES, AÑO

                        //GENERAR CONSULTA
                        comando = new SqlCommand("INSERT INTO Usuarios VALUES (" + NuevoCodigo + ", " + boxTipoDeUsuario.SelectedValue + ", '" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtDNI.Text + "', '" + partesFechaPanel[1]+"/"+ partesFechaPanel[0]+"/"+ partesFechaPanel[2] + "', '" + txtTelefono.Text + "', " + BoxProvincia.SelectedValue + ", " + BoxCiudad.SelectedValue + ", '" + txtDireccion.Text + "', '" + txtCP.Text + "', '" + txtEmail.Text + "', '" + txtContraseña.Text + "', '" + cbEstado.Checked + "')", BD.conectarBD);
                        comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                        ActualizarDgvUsuarios(); //ACTUALIZAR DATAGRID
                        seleccionarUsuario(NuevoCodigo.ToString()); //SELECCIONAR EL NUEVO USUARIO 
                        LimpiarContenedores(); //LIMPIAR CONTENEDORES
                    }

                    if (OperacionActual == MODIFICAR) //SI SE ESTA MODIFICANDO...
                    {
                        String CurrentCode = dgvUsuarios.CurrentRow.Cells[0].Value.ToString(); //GUARDAR CODIGO DE USUARIO

                        string FechaPanel = dtpCumpleaños.Value.ToShortDateString(); //GUARDAR FECHA SELECCIONADA EN EL PANEL INFERIOR
                        string[] partesFechaPanel = FechaPanel.Split('/'); //DIVIDIR LA FECHA EN DIA, MES, AÑO

                        //GENERAR COMANDO
                        comando = new SqlCommand("UPDATE Usuarios SET CodTipoDeUsuario_Usua = " + boxTipoDeUsuario.SelectedValue + ", Nombre_Usua = '" + txtNombre.Text + "', Apellido_Usua = '" + txtApellido.Text + "', DNI_Usua = '" + txtDNI.Text + "', Cumpleaños_Usua = '" + partesFechaPanel[1] + "/" + partesFechaPanel[0] + "/" + partesFechaPanel[2] + "', Telefono_Usua = '" + txtTelefono.Text + "', CodProvincia_Usua = " + BoxProvincia.SelectedValue + ", CodCiudad_Usua = " + BoxCiudad.SelectedValue + ", Direccion_Usua = '" + txtDireccion.Text + "', CodigoPostal_Usua = '" + txtCP.Text + "', Email_Usua = '" + txtEmail.Text + "', Contraseña_Usua = '" + txtContraseña.Text + "', Estado_Usua = '" + cbEstado.Checked + "' WHERE CodUsuario_Usua = " + CurrentCode, BD.conectarBD);
                        comando.ExecuteNonQuery(); //EJECUTAR COMANDO

                        ActualizarDgvUsuarios(); //ACTUALIZAR DATAGRID
                        seleccionarUsuario(CurrentCode); //SELECIONAR EL USUARIO MODIFICADO
                        ActualizarContenedores(); //ACTUALIZAR CONTENEDORES CON EL USUARIO SELECCIONADO
                    }
                }
                else //SI NO HAY NINGUNA CIUDAD SELECCIONADA...
                {
                    MessageBox.Show("La provincia seleccionada aun no posee ciudades registradas.\nPara agregar una ciudad, dirigase al menu ciudades.", "Ciudad necesaria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else //SI QUEDO ALGUN CAMPO VACIO...
            {
                MessageBox.Show("Quedaron campos vacios.\nPor favor procure completar todos los campos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.BackColor != Color.White) txtNombre.BackColor = Color.White; //SI EL TEXTBOX ESTA DE OTRO COLOR, VOLVER A PONER BLANCO
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.BackColor != Color.White) txtApellido.BackColor = Color.White; //SI EL TEXTBOX ESTA DE OTRO COLOR, VOLVER A PONER BLANCO
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.BackColor != Color.White) txtDNI.BackColor = Color.White; //SI EL TEXTBOX ESTA DE OTRO COLOR, VOLVER A PONER BLANCO
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.BackColor != Color.White) txtEmail.BackColor = Color.White; //SI EL TEXTBOX ESTA DE OTRO COLOR, VOLVER A PONER BLANCO
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.BackColor != Color.White) txtContraseña.BackColor = Color.White; //SI EL TEXTBOX ESTA DE OTRO COLOR, VOLVER A PONER BLANCO
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.BackColor != Color.White) txtTelefono.BackColor = Color.White; //SI EL TEXTBOX ESTA DE OTRO COLOR, VOLVER A PONER BLANCO
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.BackColor != Color.White) txtDireccion.BackColor = Color.White; //SI EL TEXTBOX ESTA DE OTRO COLOR, VOLVER A PONER BLANCO
        }

        private void txtCP_Enter(object sender, EventArgs e)
        {
            if (txtCP.BackColor != Color.White) txtCP.BackColor = Color.White; //SI EL TEXTBOX ESTA DE OTRO COLOR, VOLVER A PONER BLANCO
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
