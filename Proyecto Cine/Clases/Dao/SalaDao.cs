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
    class SalaDao : Dao, ISalaDao
    {
        public SalaDao() : base()
        {
            
        }

        public bool agregar(Sala sala)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO SalasXCine VALUES(@codCine, @codSala, @codTipoSala, @descripcion, @estado)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = sala.getCine().getId();
                comando.Parameters.Add("@codSala", SqlDbType.Int);
                comando.Parameters["@codSala"].Value = sala.getId();
                comando.Parameters.Add("@codTipoSala", SqlDbType.Int);
                comando.Parameters["@codTipoSala"].Value = sala.getTipo().getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = sala.getDescripcion();
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = sala.getEstado();

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

        public bool deshabilitar(int idCine, int idSala)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE SalasXCine SET Estado_SXC = 0 WHERE CodCine_SXC = " + idCine + " AND CodSala_SXC = " + idSala;

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

        public bool habilitar(int idCine, int idSala)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE SalasXCine SET Estado_SXC = 1 WHERE CodCine_SXC = " + idCine + " AND CodSala_SXC = " + idSala;

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

        public bool modificar(Sala sala)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE SalasXCine SET CodTipoDeSala_SXC = @codTipoSala, Descripcion_SXC = @descripcion, Estado_SXC = @estado " +
                        "WHERE CodCine_SXC = @codCine AND CodSala_SXC = @codSala";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = sala.getCine().getId();
                comando.Parameters.Add("@codSala", SqlDbType.Int);
                comando.Parameters["@codSala"].Value = sala.getId();
                comando.Parameters.Add("@codTipoSala", SqlDbType.Int);
                comando.Parameters["@codTipoSala"].Value = sala.getTipo().getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = sala.getDescripcion();
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = sala.getEstado();

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

        public Sala obtener(int idCine, int idSala)
        {
            try
            {
                ICineDao cineDao = new CineDao();
                ITipoDeSalaDao tipoSalaDao = new TipoDeSalaDao();

                conexion.abrir();
                query = "SELECT * FROM SalasXCine WHERE CodCine_SXC = " + idCine + " AND CodSala_SXC = " + idSala;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Sala sala = new Sala();
                Cine cine = cineDao.obtener((int)reader[0]);
                sala.setCine(cine);
                sala.setId((int)reader[1]);
                TipoDeSala tipo = tipoSalaDao.obtener((int)reader[2]);
                sala.setTipo(tipo);
                sala.setDescripcion((string)reader[3]);
                sala.setEstado((bool)reader[4]);
                
                reader.Close();
                conexion.cerrar();
                return sala;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public Sala obtenerUltima(int idCine)
        {
            try
            {
                ICineDao cineDao = new CineDao();
                ITipoDeSalaDao tipoSalaDao = new TipoDeSalaDao();

                conexion.abrir();
                query = "SELECT TOP 1 * FROM SalasXCine WHERE CodCine_SXC = " + idCine + " ORDER BY CodSala_SXC DESC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Sala sala = new Sala();
                Cine cine = cineDao.obtener((int)reader[0]);
                sala.setCine(cine);
                sala.setId((int)reader[1]);
                TipoDeSala tipo = tipoSalaDao.obtener((int)reader[2]);
                sala.setTipo(tipo);
                sala.setDescripcion((string)reader[3]);
                sala.setEstado((bool)reader[4]);

                reader.Close();
                conexion.cerrar();
                return sala;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Sala> obtenerTodas(int idCine)
        {
            try
            {
                ICineDao cineDao = new CineDao();
                ITipoDeSalaDao tipoSalaDao = new TipoDeSalaDao();
                List<Sala> lista = new List<Sala>();

                conexion.abrir();
                query = "SELECT * FROM SalasXCine WHERE CodCine_SXC = " + idCine + " ORDER BY Descripcion_SXC ASC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                
                while(reader.Read())
                {
                    Sala sala = new Sala();
                    Cine cine = cineDao.obtener((int)reader[0]);
                    sala.setCine(cine);
                    sala.setId((int)reader[1]);
                    TipoDeSala tipo = tipoSalaDao.obtener((int)reader[2]);
                    sala.setTipo(tipo);
                    sala.setDescripcion((string)reader[3]);
                    sala.setEstado((bool)reader[4]);
                    lista.Add(sala);
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
