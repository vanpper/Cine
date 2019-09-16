using Proyecto_Cine.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cine
{
    public partial class AdminView : Form
    {
        string CodUsuario;

        public AdminView(string _CodUsuario = "1")
        {
            InitializeComponent();
            CodUsuario = _CodUsuario;
        }

        private void AcoplarForm(object parametro)
        {
            if (Panel.Controls.Count > 0)
            {
                Panel.Controls.RemoveAt(0);
            }

            Form Nuevoform = parametro as Form;
            Nuevoform.TopLevel = false;
            Nuevoform.Dock = DockStyle.Fill;
            Panel.Controls.Add(Nuevoform);
            Panel.Tag = Nuevoform;
            Nuevoform.Show();
        }

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            AcoplarForm(new MenuPeliculas());
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            AcoplarForm(new Ciudades());
        }

        private void btnCines_Click(object sender, EventArgs e)
        {
            AcoplarForm(new SalasYCines());
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            AcoplarForm(new Funciones());
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            AcoplarForm(new Precios());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AcoplarForm(new Usuarios());
        }
    }
}
