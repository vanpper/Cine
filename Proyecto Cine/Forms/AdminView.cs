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
        bool ciudades = false;

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
                btnPeliculas.BackgroundImage = Properties.Resources.peliculas_selected;
                btnCiudades.BackgroundImage = Properties.Resources.ciudades_unselected;
                btnCines.BackgroundImage = Properties.Resources.cines_unselected;
                btnFunciones.BackgroundImage = Properties.Resources.funciones_unselected;
                btnPrecios.BackgroundImage = Properties.Resources.precios_unselected;
                btnUsuarios.BackgroundImage = Properties.Resources.usuarios_unselected;
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
                btnPeliculas.BackgroundImage = Properties.Resources.peliculas_unselected;
            }
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Ciudades"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new Ciudades()); //ACOPLAR EL MENU SOLICITADO
                btnCiudades.BackgroundImage = Properties.Resources.ciudades_selected;
                btnCines.BackgroundImage = Properties.Resources.cines_unselected;
                btnPeliculas.BackgroundImage = Properties.Resources.peliculas_unselected;
                btnFunciones.BackgroundImage = Properties.Resources.funciones_unselected;
                btnPrecios.BackgroundImage = Properties.Resources.precios_unselected;
                btnUsuarios.BackgroundImage = Properties.Resources.usuarios_unselected;
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
                btnCiudades.BackgroundImage = Properties.Resources.ciudades_unselected;
            }
        }

        private void btnCines_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["SalasYCines"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new SalasYCines()); //ACOPLAR EL MENU SOLICITADO
                btnCines.BackgroundImage = Properties.Resources.cines_selected;
                btnCiudades.BackgroundImage = Properties.Resources.ciudades_unselected;
                btnPeliculas.BackgroundImage = Properties.Resources.peliculas_unselected;
                btnFunciones.BackgroundImage = Properties.Resources.funciones_unselected;
                btnPrecios.BackgroundImage = Properties.Resources.precios_unselected;
                btnUsuarios.BackgroundImage = Properties.Resources.usuarios_unselected;
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
                btnCines.BackgroundImage = Properties.Resources.cines_unselected;
            }
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Funciones"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new Funciones()); //ACOPLAR EL MENU SOLICITADO
                btnFunciones.BackgroundImage = Properties.Resources.funciones_selected;
                btnCiudades.BackgroundImage = Properties.Resources.ciudades_unselected;
                btnCines.BackgroundImage = Properties.Resources.cines_unselected;
                btnPeliculas.BackgroundImage = Properties.Resources.peliculas_unselected;
                btnPrecios.BackgroundImage = Properties.Resources.precios_unselected;
                btnUsuarios.BackgroundImage = Properties.Resources.usuarios_unselected;
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
                btnFunciones.BackgroundImage = Properties.Resources.funciones_unselected;
            }
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Precios"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new Precios()); //ACOPLAR EL MENU SOLICITADO
                btnPrecios.BackgroundImage = Properties.Resources.precios_selected;
                btnCiudades.BackgroundImage = Properties.Resources.ciudades_unselected;
                btnCines.BackgroundImage = Properties.Resources.cines_unselected;
                btnFunciones.BackgroundImage = Properties.Resources.funciones_unselected;
                btnPeliculas.BackgroundImage = Properties.Resources.peliculas_unselected;
                btnUsuarios.BackgroundImage = Properties.Resources.usuarios_unselected;
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
                btnPrecios.BackgroundImage = Properties.Resources.precios_unselected;
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Control control = panelPrincipal.Controls["Usuarios"];  //CHECKEAR SI EL MENU YA ESTA PUESTO EN EL PANEL 

            if (control == null) //SI EL CONTROL ES NULL, ES DECIR, EL MENU SOLICITADO NO ESTABA PUESTO
            {
                AcoplarForm(new Usuarios()); //ACOPLAR EL MENU SOLICITADO
                btnUsuarios.BackgroundImage = Properties.Resources.usuarios_selected;
                btnCiudades.BackgroundImage = Properties.Resources.ciudades_unselected;
                btnCines.BackgroundImage = Properties.Resources.cines_unselected;
                btnFunciones.BackgroundImage = Properties.Resources.funciones_unselected;
                btnPrecios.BackgroundImage = Properties.Resources.precios_unselected;
                btnPeliculas.BackgroundImage = Properties.Resources.peliculas_unselected;
            }
            else //SI EL MENU SOLICITADO YA ESTABA PUESTO
            {
                AcoplarForm(new AdminViewPrincipal()); //CERRAR MENU, ACOPLANDO EL FORM PRINCIPAL DEL ADMINVIEW NUEVAMENTE
                btnUsuarios.BackgroundImage = Properties.Resources.usuarios_unselected;
            }
        }

        private void desactivarBotones()
        {

        }
    }
}
