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
            Control control = panelPrincipal.Controls["MenuPeliculas"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new MenuPeliculas()); //ACOPLAR EL MENU SOLICITADO
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
            }
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Ciudades"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new Ciudades()); //ACOPLAR EL MENU SOLICITADO
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
            }
        }

        private void btnCines_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["SalasYCines"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new SalasYCines()); //ACOPLAR EL MENU SOLICITADO
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
            }
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Funciones"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new Funciones()); //ACOPLAR EL MENU SOLICITADO
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
            }
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Precios"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new Precios()); //ACOPLAR EL MENU SOLICITADO
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Usuarios"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new Usuarios()); //ACOPLAR EL MENU SOLICITADO
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
            }
        }
    }
}
