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
    class PeliculaPorFormatoDao : Dao, IPeliculaPorFormatoDao
    {
        public PeliculaPorFormatoDao() : base()
        {

        }

        public bool agregar(PeliculaPorFormato pxf)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO PeliculasXFormato VALUES(@codPelicula, @codFormato, @estado)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codPelicula", SqlDbType.Int);
                comando.Parameters["@codPelicula"].Value = pxf.getPelicula().getId();
                comando.Parameters.Add("@codFormato", SqlDbType.Int);
                comando.Parameters["@codFormato"].Value = pxf.getFormato().getId();
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = pxf.getEstado();

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

        public bool deshabilitar(int idPelicula, int idFormato)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE PeliculasXFormato SET Estado_PXF = 0 WHERE CodPelicula_PXF = @codPelicula AND CodFormato_PXF = @codFormato";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codPelicula", SqlDbType.Int);
                comando.Parameters["@codPelicula"].Value = idPelicula;
                comando.Parameters.Add("@codFormato", SqlDbType.Int);
                comando.Parameters["@codFormato"].Value = idFormato;

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

        public bool habilitar(int idPelicula, int idFormato)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE PeliculasXFormato SET Estado_PXF = 1 WHERE CodPelicula_PXF = @codPelicula AND CodFormato_PXF = @codFormato";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codPelicula", SqlDbType.Int);
                comando.Parameters["@codPelicula"].Value = idPelicula;
                comando.Parameters.Add("@codFormato", SqlDbType.Int);
                comando.Parameters["@codFormato"].Value = idFormato;

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

        public PeliculaPorFormato obtener(int idPelicula, int idFormato)
        {
            try
            {
                IPeliculaDao peliculaDao = new PeliculaDao();
                IFormatoDao formatoDao = new FormatoDao();

                conexion.abrir();
                query = "SELECT * FROM PeliculasXFormato WHERE CodPelicula_PXF = " + idPelicula + " AND CodFormato_PXF = " + idFormato;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                PeliculaPorFormato pxf = new PeliculaPorFormato();
                Pelicula pelicula = peliculaDao.obtener((int)reader[0]);
                pxf.setPelicula(pelicula);
                Formato formato = formatoDao.obtener((int)reader[1]);
                pxf.setFormato(formato);
                pxf.setEstado((bool)reader[2]);

                reader.Close();
                conexion.cerrar();
                return pxf;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<PeliculaPorFormato> obtenerTodos(int idPelicula)
        {
            try
            {
                IPeliculaDao peliculaDao = new PeliculaDao();
                IFormatoDao formatoDao = new FormatoDao();
                List<PeliculaPorFormato> lista = new List<PeliculaPorFormato>();

                conexion.abrir();
                query = "SELECT * FROM PeliculasXFormato WHERE CodPelicula_PXF = " + idPelicula;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    PeliculaPorFormato pxf = new PeliculaPorFormato();
                    Pelicula pelicula = peliculaDao.obtener((int)reader[0]);
                    pxf.setPelicula(pelicula);
                    Formato formato = formatoDao.obtener((int)reader[1]);
                    pxf.setFormato(formato);
                    pxf.setEstado((bool)reader[2]);
                    lista.Add(pxf);
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
