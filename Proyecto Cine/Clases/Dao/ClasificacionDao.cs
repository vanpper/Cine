using Proyecto_Cine.Clases.Entidades;
using Proyecto_Cine.Clases.IDao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Dao
{
    class ClasificacionDao : Dao, IClasificacionDao
    {
        public ClasificacionDao() : base()
        {

        }

        public bool agregar(Clasificacion clasificacion)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Clasificaciones VALUES(@cod, @descripcion)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = clasificacion.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = clasificacion.getDescripcion();

                comando.ExecuteNonQuery();
                conexion.cerrar();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                conexion.cerrar();
                return false;
            }
        }

        public bool modificar(Clasificacion clasificacion)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Clasificaciones SET Descripcion_Clas = @descripcion WHERE CodClasificacion_Clas = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = clasificacion.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = clasificacion.getDescripcion();

                comando.ExecuteNonQuery();
                conexion.cerrar();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                conexion.cerrar();
                return false;
            }
        }

        public Clasificacion obtener(int id)
        {
            try
            {
                conexion.abrir();
                query = "SELECT * FROM Clasificaciones WHERE CodClasificacion_Clas = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Clasificacion clasificacion = new Clasificacion();
                clasificacion.setId((int)reader[0]);
                clasificacion.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return clasificacion;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Clasificacion> obtenerTodas()
        {
            try
            {
                List<Clasificacion> lista = new List<Clasificacion>();

                conexion.abrir();
                query = "SELECT * FROM Clasificaciones";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Clasificacion clasificacion = new Clasificacion();
                    clasificacion.setId((int)reader[0]);
                    clasificacion.setDescripcion((string)reader[1]);
                    lista.Add(clasificacion);
                }

                reader.Close();
                conexion.cerrar();
                return lista;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }
    }
}
