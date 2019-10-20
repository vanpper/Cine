using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Cine
{
    class Conexion
    {
        private string rutaBD;
        private SqlConnection sqlCn;

        public Conexion()
        {
            try
            {
                rutaBD = File.ReadAllText("\\rutaBD.txt");
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se encontró el archivo que contiene la ruta de la base de datos", "Archivo perdido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlCn = new SqlConnection();
            sqlCn.ConnectionString = rutaBD;
        }

        public SqlConnection getSqlCn()
        {
            return this.sqlCn; 
        }

        public bool Abrir()
        {
            try
            {
                sqlCn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al intentar conectar con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Cerrar()
        {
            try
            {
                sqlCn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al intentar conectar con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
