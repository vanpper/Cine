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
    class CiudadDao : ICiudadDao
    {
        private string query;
        private Conexion conexion;
        private SqlCommand comando;
        private SqlDataReader reader;

        public CiudadDao()
        {
            conexion = new Conexion();
            comando = null;
            reader = null;
        }

        public bool agregar(Ciudad ciudad)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Ciudades VALUES(@codProvincia, @codCiudad, @descripcion)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codProvincia", SqlDbType.Int);
                comando.Parameters["@codProvincia"].Value = ciudad.getProvincia().getId();
                comando.Parameters.Add("@codCiudad", SqlDbType.Int);
                comando.Parameters["@codCiudad"].Value = ciudad.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = ciudad.getDescripcion();

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

        public bool modificar(Ciudad ciudad)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Ciudades SET Descripcion_Ciud = @descripcion WHERE CodProvincia_Ciud = @codProvincia AND CodCiudad_Ciud = @codCiudad";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codProvincia", SqlDbType.Int);
                comando.Parameters["@codProvincia"].Value = ciudad.getProvincia().getId();
                comando.Parameters.Add("@codCiudad", SqlDbType.Int);
                comando.Parameters["@codCiudad"].Value = ciudad.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = ciudad.getDescripcion();

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

        public Ciudad obtener(int idProvincia, int idCiudad)
        {
            try
            {
                IProvinciaDao provinciaDao = new ProvinciaDao();

                conexion.abrir();
                query = "SELECT * FROM Ciudades WHERE CodProvincia_Ciud = " + idProvincia + " AND CodCiudad_Ciud = " + idCiudad;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Ciudad ciudad = new Ciudad();

                Provincia provincia = provinciaDao.obtener((int)reader[0]);
                ciudad.setProvincia(provincia);
                ciudad.setId((int)reader[1]);
                ciudad.setDescripcion((string)reader[2]);

                reader.Close();
                conexion.cerrar();
                return ciudad;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Ciudad> obtenerTodas(int idProvincia)
        {
            try
            {
                IProvinciaDao provinciaDao = new ProvinciaDao();
                List<Ciudad> lista = new List<Ciudad>();

                conexion.abrir();
                query = "SELECT * FROM Ciudades WHERE CodProvincia_Ciud = " + idProvincia;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Ciudad ciudad = new Ciudad();

                    Provincia provincia = provinciaDao.obtener((int)reader[0]);
                    ciudad.setProvincia(provincia);
                    ciudad.setId((int)reader[1]);
                    ciudad.setDescripcion((string)reader[2]);

                    lista.Add(ciudad);
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
