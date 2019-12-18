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
        public RestaurarContraseña(int x, int y)
        {
            InitializeComponent();
            this.Location = new Point(x + 398, y + 94);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
