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
        public AdminView()
        {
            InitializeComponent();
            AcoplarForm(new AdminViewPrincipal());
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

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["MenuPeliculas"];

            if (control == null)
            {
                AcoplarForm(new MenuPeliculas());
            }
            else
            {
                AcoplarForm(new AdminViewPrincipal());
            }
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Ciudades"];

            if (control == null)
            {
                AcoplarForm(new Ciudades());
            }
            else
            {
                AcoplarForm(new AdminViewPrincipal());
            }
        }

        private void btnCines_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["SalasYCines"];

            if (control == null)
            {
                AcoplarForm(new SalasYCines()); 
            }
            else
            {
                AcoplarForm(new AdminViewPrincipal());
            }
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Funciones"]; 

            if (control == null)
            {
                AcoplarForm(new Funciones());
            }
            else
            {
                AcoplarForm(new AdminViewPrincipal());
            }
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Precios"]; 

            if (control == null)
            {
                AcoplarForm(new Precios());
            }
            else
            {
                AcoplarForm(new AdminViewPrincipal());
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Usuarios"];

            if (control == null)
            {
                AcoplarForm(new Usuarios());
            }
            else
            {
                AcoplarForm(new AdminViewPrincipal());
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Ventas"];

            if (control == null)
            {
                AcoplarForm(new Ventas());
            }
            else
            {
                AcoplarForm(new AdminViewPrincipal());
            }
        }
    }
}
