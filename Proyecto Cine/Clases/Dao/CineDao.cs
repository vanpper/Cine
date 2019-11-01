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
    class CineDao : Dao, ICineDao
    {
        public CineDao() : base()
        {

        }

        public bool agregar(Cine cine)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Cines VALUES(@codCine, @nombre, @codProvincia, @codCiudad, @direccion, @descripcion, @estado)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = cine.getId();
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = cine.getNombre();
                comando.Parameters.Add("@codProvincia", SqlDbType.Int);
                comando.Parameters["@codProvincia"].Value = cine.getCiudad().getProvincia().getId();
                comando.Parameters.Add("@codCiudad", SqlDbType.Int);
                comando.Parameters["@codCiudad"].Value = cine.getCiudad().getId();
                comando.Parameters.Add("@direccion", SqlDbType.VarChar);
                comando.Parameters["@direccion"].Value = cine.getDireccion();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = cine.getDescripcion() ?? (object)DBNull.Value;
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = cine.getEstado();

                comando.ExecuteNonQuery();
                conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conexion.cerrar();
                return false;
            }
        }

        public bool deshabilitar(int id)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Cines SET Estado_Cine = 0 WHERE CodCine_Cine = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.ExecuteNonQuery();
                conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conexion.cerrar();
                return false;
            }
        }

        public bool habilitar(int id)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Cines SET Estado_Cine = 1 WHERE CodCine_Cine = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.ExecuteNonQuery();
                conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conexion.cerrar();
                return false;
            }
        }

        public bool modificar(Cine cine)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Cines SET Nombre_Cine = @nombre, CodProvincia_Cine = @codProvincia, " +
                        "CodCiudad_Cine = @codCiudad, Direccion_Cine = @direccion, Descripcion_Cine = @descripcion, " +
                        "Estado_Cine = @estado WHERE CodCine_Cine = @codCine";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = cine.getId();
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = cine.getNombre();
                comando.Parameters.Add("@codProvincia", SqlDbType.Int);
                comando.Parameters["@codProvincia"].Value = cine.getCiudad().getProvincia().getId();
                comando.Parameters.Add("@codCiudad", SqlDbType.Int);
                comando.Parameters["@codCiudad"].Value = cine.getCiudad().getId();
                comando.Parameters.Add("@direccion", SqlDbType.VarChar);
                comando.Parameters["@direccion"].Value = cine.getDireccion();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = cine.getDescripcion() ?? (object)DBNull.Value;
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = cine.getEstado();

                comando.ExecuteNonQuery();
                conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conexion.cerrar();
                return false;
            }
        }

        public Cine obtener(int id)
        {
            try
            {
                ICiudadDao ciudadDao = new CiudadDao();
                conexion.abrir();
                query = "SELECT * FROM Cines WHERE CodCine_Cine = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Cine cine = new Cine();
                cine.setId((int)reader[0]);
                cine.setNombre((string)reader[1]);
                Ciudad ciudad = ciudadDao.obtener((int)reader[2], (int)reader[3]);
                cine.setCiudad(ciudad);
                cine.setDireccion((string)reader[4]);
                if(reader[5] != DBNull.Value) cine.setDescripcion((string)reader[5]);
                cine.setEstado((bool)reader[6]);

                reader.Close();
                conexion.cerrar();
                return cine;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public Cine obtenerUltimo()
        {
            try
            {
                ICiudadDao ciudadDao = new CiudadDao();
                conexion.abrir();
                query = "SELECT TOP 1 * FROM Cines ORDER BY CodCine_Cine DESC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Cine cine = new Cine();
                cine.setId((int)reader[0]);
                cine.setNombre((string)reader[1]);
                Ciudad ciudad = ciudadDao.obtener((int)reader[2], (int)reader[3]);
                cine.setCiudad(ciudad);
                cine.setDireccion((string)reader[4]);
                if (reader[5] != DBNull.Value) cine.setDescripcion((string)reader[5]);
                cine.setEstado((bool)reader[6]);

                reader.Close();
                conexion.cerrar();
                return cine;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Cine> obtenerTodos()
        {
            try
            {
                ICiudadDao ciudadDao = new CiudadDao();
                List<Cine> lista = new List<Cine>();

                conexion.abrir();
                query = "SELECT * FROM Cines";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Cine cine = new Cine();
                    cine.setId((int)reader[0]);
                    cine.setNombre((string)reader[1]);
                    Ciudad ciudad = ciudadDao.obtener((int)reader[2], (int)reader[3]);
                    cine.setCiudad(ciudad);
                    cine.setDireccion((string)reader[4]);
                    if(reader[5] != DBNull.Value) cine.setDescripcion((string)reader[5]);
                    cine.setEstado((bool)reader[6]);

                    lista.Add(cine);
                }

                reader.Close();
                conexion.cerrar();
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }
    }
}
