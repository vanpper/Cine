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
    class FuncionDao : Dao, IFuncionDao
    {
        public FuncionDao() : base()
        {

        }

        public bool agregar(Funcion funcion)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Funciones VALUES(@codCine, @codSala, @dia, @horario, @codPelicula, @codFormato, @stock, @estado)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = funcion.getCine().getId(); 
                comando.Parameters.Add("@codSala", SqlDbType.Int);
                comando.Parameters["@codSala"].Value = funcion.getSala().getId();
                comando.Parameters.Add("@dia", SqlDbType.Date);
                comando.Parameters["@dia"].Value = funcion.getFecha().ToString();
                comando.Parameters.Add("@horario", SqlDbType.VarChar);
                comando.Parameters["@horario"].Value = funcion.getHorario().getHHMM();
                comando.Parameters.Add("@codPelicula", SqlDbType.Int);
                comando.Parameters["@codPelicula"].Value = funcion.getPelicula().getId();
                comando.Parameters.Add("@codFormato", SqlDbType.Int);
                comando.Parameters["@codFormato"].Value = funcion.getFormato().getId();
                comando.Parameters.Add("@stock", SqlDbType.Int);
                comando.Parameters["@stock"].Value = funcion.getStock();
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = funcion.getEstado();

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
    
        public bool deshabilitar(Funcion funcion)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Funciones SET Estado_Func = 0 WHERE CodCine_Func = @codCine AND CodSala_Func = @codSala AND Dia_Func = @dia AND Horario_Func = @horario";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = funcion.getCine().getId();
                comando.Parameters.Add("@codSala", SqlDbType.Int);
                comando.Parameters["@codSala"].Value = funcion.getSala().getId();
                comando.Parameters.Add("@dia", SqlDbType.Date);
                comando.Parameters["@dia"].Value = funcion.getFecha().ToString();
                comando.Parameters.Add("@horario", SqlDbType.VarChar);
                comando.Parameters["@horario"].Value = funcion.getHorario().getHHMM();

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

        public bool habilitar(Funcion funcion)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Funciones SET Estado_Func = 1 WHERE CodCine_Func = @codCine AND CodSala_Func = @codSala AND Dia_Func = @dia AND Horario_Func = @horario";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = funcion.getCine().getId();
                comando.Parameters.Add("@codSala", SqlDbType.Int);
                comando.Parameters["@codSala"].Value = funcion.getSala().getId();
                comando.Parameters.Add("@dia", SqlDbType.Date);
                comando.Parameters["@dia"].Value = funcion.getFecha().ToString();
                comando.Parameters.Add("@horario", SqlDbType.VarChar);
                comando.Parameters["@horario"].Value = funcion.getHorario().getHHMM();

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

        public bool modificar(Funcion funcion)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Funciones SET CodPelicula_Func = @codPelicula, CodFormato_Func = @codFormato, Stock_Func = @stock, Estado_Func = @estado " +
                        "WHERE CodCine_Func = @codCine AND CodSala_Func = @codSala AND Dia_Func = @dia AND Horario_Func = @horario";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = funcion.getCine().getId();
                comando.Parameters.Add("@codSala", SqlDbType.Int);
                comando.Parameters["@codSala"].Value = funcion.getSala().getId();
                comando.Parameters.Add("@dia", SqlDbType.Date);
                comando.Parameters["@dia"].Value = funcion.getFecha().ToString();
                comando.Parameters.Add("@horario", SqlDbType.VarChar);
                comando.Parameters["@horario"].Value = funcion.getHorario().getHHMM();
                comando.Parameters.Add("@codPelicula", SqlDbType.Int);
                comando.Parameters["@codPelicula"].Value = funcion.getPelicula().getId();
                comando.Parameters.Add("@codFormato", SqlDbType.Int);
                comando.Parameters["@codFormato"].Value = funcion.getFormato().getId();
                comando.Parameters.Add("@stock", SqlDbType.Int);
                comando.Parameters["@stock"].Value = funcion.getStock();
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = funcion.getEstado();

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

        public Funcion obtener(int idCine, int idSala, Fecha fecha, Horario horario)
        {
            try
            {
                ICineDao cineDao = new CineDao();
                ISalaDao salaDao = new SalaDao();
                IPeliculaDao peliculaDao = new PeliculaDao();
                IFormatoDao formatoDao = new FormatoDao();

                conexion.abrir();
                query = "SELECT * FROM Funciones WHERE CodCine_Func = " + idCine + " AND CodSala_Func = " + idSala + " AND " +
                        "Dia_Func = " + fecha.ToString() + " AND Horario_Func = " + horario.getHHMM();

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Funcion funcion = new Funcion();
                Cine cine = cineDao.obtener(idCine);
                funcion.setCine(cine);
                Sala sala = salaDao.obtener(idCine, idSala);
                funcion.setSala(sala);
                funcion.setFecha(new Fecha((string)reader[2]));
                funcion.setHorario(new Horario((string)reader[3]));

                reader.Close();
                conexion.cerrar();
                return formato;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Pelicula> obtenerTodas()
        {
            throw new NotImplementedException();
        }
    }
}
