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
        private SqlConnection sqlConnection;

        public Conexion()
        {
            try
            {
                rutaBD = File.ReadAllText(@"..\..\BD\rutaBD.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("No se encontró el archivo que contiene la ruta de la base de datos.", "Archivo perdido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = rutaBD;
        }

        public SqlConnection getSqlConnection()
        {
            return this.sqlConnection; 
        }

        public bool abrir()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show("Ha ocurrido un error al intentar conectar con el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool cerrar()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Ha ocurrido un error al intentar conectar con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
