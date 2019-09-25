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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            panelSuperior.Visible = false;
            panelLogin.Visible = true;
        }

        private void AcoplarForm(object parametro)
        {
            if (panelPrincipal.Controls.Count > 0)
            {
                panelPrincipal.Controls.RemoveAt(0);
            }

            Form Nuevoform = parametro as Form;
            Nuevoform.TopLevel = false;
            Nuevoform.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(Nuevoform);
            panelPrincipal.Tag = Nuevoform;
            Nuevoform.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Conexion BD = new Conexion();

            if (BD.Abrir())
            {
                SqlCommand comando = new SqlCommand("SELECT CodTipoDeUsuario_Usua, Nombre_Usua, Apellido_Usua FROM Usuarios WHERE Email_Usua = '" + txtEmail.Text + "' AND Contraseña_Usua = '" + txtContraseña.Text + "'", BD.conectarBD);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    //SI LOS DATOS INGRESADOS SON DE UN ADMINISTRADOR, ACA SE ABRE EL MENU ADMINISTRADOR
                    if (reader.GetValue(0).ToString() == "1")
                    {
                        //panelLogin.Visible = false;
                        panelSuperior.Visible = true;
                        labelBienvenvida.Text = "Bienvenido/a " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString();
                        AcoplarForm(new AdminView());
                        
                    }

                    //SI LOS DATOS INGRESADOS SON DE UN OPERARIO, ACA SE ABRE EL MENU OPERARIO
                    if (reader.GetValue(1).ToString() == "2")
                    {

                    }

                    //SI LOS DATOS INGRESADOS SON DE UN ESPECTADOR, ACA SE ABRE EL MENU ESPECTADOR
                    if (reader.GetValue(1).ToString() == "3")
                    {

                    }
                }
                else
                {
                    MessageBox.Show("El email y/o contraseña son incorrectos.", "Datos no validos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Se cerrará la sesion.\n¿Desea continuar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resultado == DialogResult.Yes)
            {
                panelPrincipal.Controls.RemoveByKey("AdminView");
                panelSuperior.Visible = false;
                panelPrincipal.Controls.Add(panelLogin);
                txtEmail.Clear();
                txtContraseña.Clear();
                txtEmail.Focus();
            }
        }

        private void linkRestaurarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RestaurarContraseña ventana = new RestaurarContraseña();
            ventana.Show();
        }
    }
}
