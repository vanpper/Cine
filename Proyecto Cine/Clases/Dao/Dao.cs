using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Dao
{
    class Dao
    {
        protected string query;
        protected Conexion conexion;
        protected SqlCommand comando;
        protected SqlDataReader reader;

        public Dao()
        {
            conexion = new Conexion();
            comando = null;
            reader = null;
        }
    }
}
