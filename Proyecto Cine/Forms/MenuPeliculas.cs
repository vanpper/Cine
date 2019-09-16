using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cine.Forms
{
    public partial class MenuPeliculas : Form
    {
        public MenuPeliculas()
        {
            InitializeComponent();

            AcoplarForm(new Peliculas());
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
            AcoplarForm(new Peliculas());
        }

        private void btnFormatos_Click(object sender, EventArgs e)
        {
            AcoplarForm(new Formatos());
        }

        private void btnGYC_Click(object sender, EventArgs e)
        {
            AcoplarForm(new ClasificacionesYGeneros());
        }
    }
}
