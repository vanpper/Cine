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
    class TipoDeUsuarioDao : Dao, ITipoDeUsuarioDao
    {
        public TipoDeUsuarioDao() : base()
        {

        }

        public bool agregar(TipoDeUsuario tipo)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO TiposDeUsuarios VALUES(@cod, @descripcion)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = tipo.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = tipo.getDescripcion();

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

        public bool modificar(TipoDeUsuario tipo)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE TiposDeUsuarios SET Descripcion_TDU = @descripcion WHERE CodTipoDeUsuario_TDU = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = tipo.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = tipo.getDescripcion();

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

        public TipoDeUsuario obtener(int id)
        {
            try
            {
                conexion.abrir();
                query = "SELECT * FROM TiposDeUsuarios WHERE CodTipoDeUsuario_TDU = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                TipoDeUsuario tipo = new TipoDeUsuario();
                tipo.setId((int)reader[0]);
                tipo.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return tipo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }


        public TipoDeUsuario obtenerUltimo()
        {
            try
            {
                conexion.abrir();
                query = "SELECT TOP 1 * FROM TiposDeUsuarios ORDER BY CodTipoDeUsuario_TDU DESC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                TipoDeUsuario tipo = new TipoDeUsuario();
                tipo.setId((int)reader[0]);
                tipo.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return tipo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<TipoDeUsuario> obtenerTodos()
        {
            try
            {
                List<TipoDeUsuario> lista = new List<TipoDeUsuario>();

                conexion.abrir();
                query = "SELECT * FROM TiposDeUsuarios ORDER BY Descripcion_TDU ASC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    TipoDeUsuario tipo = new TipoDeUsuario();
                    tipo.setId((int)reader[0]);
                    tipo.setDescripcion((string)reader[1]);
                    lista.Add(tipo);
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
