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
    class TipoDeSalaDao : Dao, ITipoDeSalaDao
    {
        public TipoDeSalaDao() : base()
        {

        }

        public bool agregar(TipoDeSala tipoSala)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO TiposDeSalas VALUES(@cod, @descripcion)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = tipoSala.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = tipoSala.getDescripcion();

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

        public bool modificar(TipoDeSala tipoSala)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE TiposDeSalas SET Descripcion_TDS = @descripcion WHERE CodTipoDeSala_TDS = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = tipoSala.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = tipoSala.getDescripcion();

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

        public TipoDeSala obtener(int id)
        {
            try
            {
                conexion.abrir();
                query = "SELECT * FROM TiposDeSalas WHERE CodTipoDeSala_TDS = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                TipoDeSala tipoSala = new TipoDeSala();
                tipoSala.setId((int)reader[0]);
                tipoSala.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return tipoSala;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public TipoDeSala obtenerUltimo()
        {
            try
            {
                conexion.abrir();
                query = "SELECT TOP 1 * FROM TiposDeSalas ORDER BY CodTipoDeSala_TDS DESC"; 

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                TipoDeSala tipoSala = new TipoDeSala();
                tipoSala.setId((int)reader[0]);
                tipoSala.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return tipoSala;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<TipoDeSala> obtenerTodos()
        {
            try
            {
                List<TipoDeSala> lista = new List<TipoDeSala>();
                conexion.abrir();
                query = "SELECT * FROM TiposDeSalas ORDER BY Descripcion_TDS ASC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                
                while (reader.Read())
                {
                    TipoDeSala tipoSala = new TipoDeSala();
                    tipoSala.setId((int)reader[0]);
                    tipoSala.setDescripcion((string)reader[1]);
                    lista.Add(tipoSala);
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
