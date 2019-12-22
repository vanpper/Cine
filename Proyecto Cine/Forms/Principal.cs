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
    public partial class Principal : Form
    {
        private IUsuarioNeg usuarioNeg = new UsuarioNeg();

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
            Usuario usuario = usuarioNeg.obtener(txtEmail.Text);

            if(usuario != null && usuario.getContraseña() == txtContraseña.Text)
            {
                panelSuperior.Visible = true;
                AcoplarForm(new AdminView());
                MessageBox.Show("¡Bienvenido al sistema!", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos.", "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
