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
    class TipoDeEntradaDao : Dao, ITipoDeEntradaDao
    {
        public TipoDeEntradaDao() : base()
        {

        }

        public bool agregar(TipoDeEntrada tipoEntrada)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO TiposDeEntradas VALUES(@cod, @descripcion)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = tipoEntrada.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = tipoEntrada.getDescripcion();

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

        public bool modificar(TipoDeEntrada tipoEntrada)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE TiposDeEntradas SET Descripcion_TDE = @descripcion WHERE CodTipoDeEntrada_TDE = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = tipoEntrada.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = tipoEntrada.getDescripcion();

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

        public TipoDeEntrada obtener(int id)
        {
            try
            {
                conexion.abrir();
                query = "SELECT * FROM TiposDeEntradas WHERE CodTipoDeEntrada_TDE = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                TipoDeEntrada tipoEntrada = new TipoDeEntrada();
                tipoEntrada.setId((int)reader[0]);
                tipoEntrada.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return tipoEntrada;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public TipoDeEntrada obtenerUltimo()
        {
            try
            {
                conexion.abrir();
                query = "SELECT TOP 1 * FROM TiposDeEntradas ORDER BY CodTipoDeEntrada_TDE DESC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                TipoDeEntrada tipoEntrada = new TipoDeEntrada();
                tipoEntrada.setId((int)reader[0]);
                tipoEntrada.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return tipoEntrada;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<TipoDeEntrada> obtenerTodos()
        {
            try
            {
                List<TipoDeEntrada> lista = new List<TipoDeEntrada>();

                conexion.abrir();
                query = "SELECT * FROM TiposDeEntradas";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    TipoDeEntrada tipoEntrada = new TipoDeEntrada();
                    tipoEntrada.setId((int)reader[0]);
                    tipoEntrada.setDescripcion((string)reader[1]);
                    lista.Add(tipoEntrada);
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
