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
    class GeneroDao : Dao, IGeneroDao
    {
        public GeneroDao() : base()
        {
            
        }

        public bool agregar(Genero genero)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Generos VALUES(@cod, @descripcion)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = genero.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = genero.getDescripcion();

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

        public bool modificar(Genero genero)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Generos SET Descripcion_Gene = @descripcion WHERE CodGenero_Gene = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = genero.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = genero.getDescripcion();

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

        public Genero obtener(int id)
        {
            try
            {
                conexion.abrir();
                query = "SELECT * FROM Generos WHERE CodGenero_Gene = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Genero genero = new Genero();
                genero.setId((int)reader[0]);
                genero.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return genero;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public Genero obtenerUltimo()
        {
            try
            {
                conexion.abrir();
                query = "SELECT TOP 1 * FROM Generos ORDER BY CodGenero_Gene DESC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Genero genero = new Genero();
                genero.setId((int)reader[0]);
                genero.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return genero;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Genero> obtenerTodos()
        {
            try
            {
                List<Genero> lista = new List<Genero>();

                conexion.abrir();
                query = "SELECT * FROM Generos";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Genero genero = new Genero();
                    genero.setId((int)reader[0]);
                    genero.setDescripcion((string)reader[1]);
                    lista.Add(genero);
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
