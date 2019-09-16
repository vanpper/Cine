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

namespace Proyecto_Cine
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Conexion BD = new Conexion();
            
            if (BD.Abrir())
            {
                SqlCommand comando = new SqlCommand("SELECT CodUsuario_Usua, CodTipoDeUsuario_Usua FROM Usuarios WHERE Email_Usua = '" + txbEmail.Text + "' AND Contraseña_Usua = '" + txbContraseña.Text + "'", BD.conectarBD);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {   
                    //SI LOS DATOS INGRESADOS SON DE UN ADMINISTRADOR, ACA SE ABRE EL MENU ADMINISTRADOR
                    if(reader.GetValue(1).ToString() == "1")
                    {
                        AdminView ventana = new AdminView(reader.GetValue(0).ToString());
                        ventana.Show();
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
                    MessageBox.Show("Los datos ingresados no son validos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbEmail.Focus();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
