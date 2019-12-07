using Proyecto_Cine.Clases.Entidades;
using Proyecto_Cine.Clases.IDao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Dao
{
    class PeliculaDao : Dao, IPeliculaDao
    {
        public PeliculaDao() : base()
        {

        }

        public bool agregar(Pelicula pelicula)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Peliculas VALUES(@cod, @nombre, @duracion, @actores, @director, @codGenero, @CodClasificacion, @descripcion, @portada, @estado)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = pelicula.getId();
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = pelicula.getNombre();
                comando.Parameters.Add("@duracion", SqlDbType.Int);
                comando.Parameters["@duracion"].Value = pelicula.getDuracion();
                comando.Parameters.Add("@actores", SqlDbType.VarChar);
                comando.Parameters["@actores"].Value = pelicula.getActores() ?? (object)DBNull.Value;
                comando.Parameters.Add("@director", SqlDbType.VarChar);
                comando.Parameters["@director"].Value = pelicula.getDirector() ?? (object)DBNull.Value;
                comando.Parameters.Add("@codGenero", SqlDbType.Int);
                comando.Parameters["@codGenero"].Value = pelicula.getGenero().getId();
                comando.Parameters.Add("@codClasificacion", SqlDbType.Int);
                comando.Parameters["@codClasificacion"].Value = pelicula.getClasificacion().getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = pelicula.getDescripcion() ?? (object)DBNull.Value;
                comando.Parameters.Add("@portada", SqlDbType.Image);
                comando.Parameters["@portada"].Value = pelicula.getImagen() ?? (object)DBNull.Value;
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = pelicula.getEstado();

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
                query = "UPDATE Peliculas SET Estado_Peli = 0 WHERE CodPelicula_Peli = " + id;
                
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
                query = "UPDATE Peliculas SET Estado_Peli = 1 WHERE CodPelicula_Peli = " + id;

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

        public bool modificar(Pelicula pelicula)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Peliculas SET Nombre_Peli = @nombre, Duracion_Peli = @duracion, Actores_Peli = @actores, Director_Peli = @director, " +
                        "CodGenero_Peli = @codGenero, CodClasificacion_Peli = @CodClasificacion, Descripcion_Peli = @descripcion, Portada_Peli = @portada, " +
                        "Estado_Peli = @estado WHERE CodPelicula_Peli = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = pelicula.getId();
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = pelicula.getNombre();
                comando.Parameters.Add("@duracion", SqlDbType.Int);
                comando.Parameters["@duracion"].Value = pelicula.getDuracion();
                comando.Parameters.Add("@actores", SqlDbType.VarChar);
                comando.Parameters["@actores"].Value = pelicula.getActores() ?? (object)DBNull.Value;
                comando.Parameters.Add("@director", SqlDbType.VarChar);
                comando.Parameters["@director"].Value = pelicula.getDirector() ?? (object)DBNull.Value;
                comando.Parameters.Add("@codGenero", SqlDbType.Int);
                comando.Parameters["@codGenero"].Value = pelicula.getGenero().getId();
                comando.Parameters.Add("@codClasificacion", SqlDbType.Int);
                comando.Parameters["@codClasificacion"].Value = pelicula.getClasificacion().getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = pelicula.getDescripcion() ?? (object)DBNull.Value;
                comando.Parameters.Add("@portada", SqlDbType.Image);
                comando.Parameters["@portada"].Value = pelicula.getImagen() ?? (object)DBNull.Value;
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = pelicula.getEstado();

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

        public Pelicula obtener(int id)
        {
            try
            {
                IGeneroDao generoDao = new GeneroDao();
                IClasificacionDao clasificacionDao = new ClasificacionDao();

                conexion.abrir();
                query = "SELECT * FROM Peliculas WHERE CodPelicula_Peli = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Pelicula pelicula = new Pelicula();
                pelicula.setId((int)reader[0]);
                pelicula.setNombre((string)reader[1]);
                if(reader[2] != DBNull.Value) pelicula.setDuracion((int)reader[2]);
                if(reader[3] != DBNull.Value) pelicula.setActores((string)reader[3]);
                if(reader[4] != DBNull.Value) pelicula.setDirector((string)reader[4]);
                Genero genero = generoDao.obtener((int)reader[5]);
                pelicula.setGenero(genero);
                Clasificacion clasificacion = clasificacionDao.obtener((int)reader[6]);
                pelicula.setClasificacion(clasificacion);
                if(reader[7] != DBNull.Value) pelicula.setDescripcion((string)reader[7]);
                if(reader[8] != DBNull.Value) pelicula.setImagen((byte[])reader[8]);
                pelicula.setEstado((bool)reader[9]);

                reader.Close();
                conexion.cerrar();
                return pelicula;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public Pelicula obtenerUltima()
        {
            try
            {
                IGeneroDao generoDao = new GeneroDao();
                IClasificacionDao clasificacionDao = new ClasificacionDao();

                conexion.abrir();
                query = "SELECT TOP 1 * FROM Peliculas ORDER BY CodPelicula_Peli DESC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Pelicula pelicula = new Pelicula();
                pelicula.setId((int)reader[0]);
                pelicula.setNombre((string)reader[1]);
                if (reader[2] != DBNull.Value) pelicula.setDuracion((int)reader[2]);
                if (reader[3] != DBNull.Value) pelicula.setActores((string)reader[3]);
                if (reader[4] != DBNull.Value) pelicula.setDirector((string)reader[4]);
                Genero genero = generoDao.obtener((int)reader[5]);
                pelicula.setGenero(genero);
                Clasificacion clasificacion = clasificacionDao.obtener((int)reader[6]);
                pelicula.setClasificacion(clasificacion);
                if (reader[7] != DBNull.Value) pelicula.setDescripcion((string)reader[7]);
                if (reader[8] != DBNull.Value) pelicula.setImagen((byte[])reader[8]);
                pelicula.setEstado((bool)reader[9]);

                reader.Close();
                conexion.cerrar();
                return pelicula;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Pelicula> obtenerTodas()
        {
            try
            {
                IGeneroDao generoDao = new GeneroDao();
                IClasificacionDao clasificacionDao = new ClasificacionDao();
                List<Pelicula> lista = new List<Pelicula>();

                conexion.abrir();
                query = "SELECT * FROM Peliculas ORDER BY Nombre_Peli ASC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Pelicula pelicula = new Pelicula();
                    pelicula.setId((int)reader[0]);
                    pelicula.setNombre((string)reader[1]);
                    if(reader[2] != DBNull.Value) pelicula.setDuracion((int)reader[2]);
                    if(reader[3] != DBNull.Value) pelicula.setActores((string)reader[3]);
                    if(reader[4] != DBNull.Value) pelicula.setDirector((string)reader[4]);
                    Genero genero = generoDao.obtener((int)reader[5]);
                    pelicula.setGenero(genero);
                    Clasificacion clasificacion = clasificacionDao.obtener((int)reader[6]);
                    pelicula.setClasificacion(clasificacion);
                    if(reader[7] != DBNull.Value) pelicula.setDescripcion((string)reader[7]);
                    if(reader[8] != DBNull.Value) pelicula.setImagen((byte[])reader[8]);
                    pelicula.setEstado((bool)reader[9]);
                    lista.Add(pelicula);
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
