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
    public partial class RestaurarContraseña : Form
    {
        String contraseña;
        Random random = new Random();

        public RestaurarContraseña(int x, int y)
        {
            InitializeComponent();
            this.Location = new Point(x + 398, y + 94);
        }

        private bool enviarEmail()
        {
            try
            {
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add(txtEmail.Text); //PARA QUIEN ESTA DIRIGIDO
                mmsg.Subject = "Recuperacion de contraseña"; //ASUNTO
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                mmsg.Body = "Estimado/a; <br/>";
                mmsg.Body += "Según nos has solicitado, hemos procedido a cambiar tu contraseña en MovixCinema por una nueva. <br/>";
                mmsg.Body += "Tu nueva contraseña es: " + contraseña + "<br/>";
                mmsg.Body += "Te recomendamos que entres en el sistema y la cambies por otra de tu elección lo antes posible. <br/><br/>";
                mmsg.Body += "Saludos. El equipo de MovixCinema<br/><br/>";
                mmsg.Body += "PD: Este es un mensaje automático. Por favor no lo contestes.";

                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new System.Net.Mail.MailAddress("movixcinema@hotmail.com");

                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials = new System.Net.NetworkCredential("movixcinema@hotmail.com", "XXXXXXXX");

                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.live.com";

                cliente.Send(mmsg);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private bool actualizarContraseñaBD()
        {
            Conexion BD = new Conexion();
            
            if(BD.Abrir())
            {
                SqlCommand comando = new SqlCommand("UPDATE Usuarios SET Contraseña_Usua = '" + contraseña + "' WHERE Email_Usua = '" + txtEmail.Text + "'", BD.conectarBD);

                if (comando.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        private void generarContraseñaAleatoria()
        {
            contraseña = null;

            for (int i = 0; i < 6; i++) contraseña += random.Next(0, 9).ToString();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            generarContraseñaAleatoria();

            if (actualizarContraseñaBD())
            {
                if (enviarEmail())
                {
                    MessageBox.Show("Se ha enviado un correo de recuperacion a la casilla de email indicada.", "Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al intentar enviar el correo.\nVerifique su conexion a internet o intentelo nuevamente mas tarde.", "No enviado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Se ha enviado un correo de recuperacion a la casilla de email indicada.", "Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
