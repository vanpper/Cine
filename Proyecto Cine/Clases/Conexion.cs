using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Cine
{
    class Conexion
    {
        string Cadena = "Data Source=VAN-PC;Initial Catalog=CINE;Integrated Security=True";
        public SqlConnection conectarBD = new SqlConnection();

        public Conexion()
        {
            conectarBD.ConnectionString = Cadena;
        }

        public bool Abrir()
        {
            try
            {
                conectarBD.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al intentar conectar con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void Cerrar()
        {
            conectarBD.Close();
        }
    }
}
