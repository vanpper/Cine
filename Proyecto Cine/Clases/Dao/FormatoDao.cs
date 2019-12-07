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
    class FormatoDao : Dao, IFormatoDao
    {
        public FormatoDao() : base()
        {

        }

        public bool agregar(Formato formato)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Formatos VALUES(@cod, @descripcion)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = formato.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = formato.getDescripcion();

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

        public bool modificar(Formato formato)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Formatos SET Descripcion_Form = @descripcion WHERE CodFormato_Form = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = formato.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = formato.getDescripcion();

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

        public Formato obtener(int id)
        {
            try
            {
                conexion.abrir();
                query = "SELECT * FROM Formatos WHERE CodFormato_Form = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Formato formato = new Formato();
                formato.setId((int)reader[0]);
                formato.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return formato;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public Formato obtenerUltimo()
        {
            try
            {
                conexion.abrir();
                query = "SELECT TOP 1 * FROM Formatos ORDER BY CodFormato_Form DESC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Formato formato = new Formato();
                formato.setId((int)reader[0]);
                formato.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return formato;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Formato> obtenerTodos()
        {
            try
            {
                List<Formato> lista = new List<Formato>();

                conexion.abrir();
                query = "SELECT * FROM Formatos ORDER BY Descripcion_Form ASC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Formato formato = new Formato();
                    formato.setId((int)reader[0]);
                    formato.setDescripcion((string)reader[1]);
                    lista.Add(formato);
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
