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
    class PrecioDao : Dao, IPrecioDao
    {
        public PrecioDao() : base()
        {

        }

        public bool agregar(Precio precio)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Precios VALUES(@codCine, @codTipoSala, @codTipoEntrada, @precio)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = precio.getCine().getId();
                comando.Parameters.Add("@codTipoSala", SqlDbType.Int);
                comando.Parameters["@codTipoSala"].Value = precio.getTipoSala().getId();
                comando.Parameters.Add("@codTipoEntrada", SqlDbType.Int);
                comando.Parameters["@codTipoEntrada"].Value = precio.getTipoEntrada().getId();
                comando.Parameters.Add("@precio", SqlDbType.Int);
                comando.Parameters["@precio"].Value = precio.getPrecio();

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

        public bool modificar(Precio precio)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Precios SET Precio_Prec = @precio WHERE CodCine_Prec = @codCine AND " +
                        "CodTipoDeSala_Prec = @codTipoSala AND CodTipoDeEntrada_Prec = @codTipoEntrada";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = precio.getCine().getId();
                comando.Parameters.Add("@codTipoSala", SqlDbType.Int);
                comando.Parameters["@codTipoSala"].Value = precio.getTipoSala().getId();
                comando.Parameters.Add("@codTipoEntrada", SqlDbType.Int);
                comando.Parameters["@codTipoEntrada"].Value = precio.getTipoEntrada().getId();
                comando.Parameters.Add("@precio", SqlDbType.Int);
                comando.Parameters["@precio"].Value = precio.getPrecio();

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

        public Precio obtener(int idCine, int idTipoSala, int idTipoEntrada)
        {
            try
            {
                ICineDao cineDao = new CineDao();
                ITipoDeSalaDao salaDao = new TipoDeSalaDao();
                ITipoDeEntradaDao entradaDao = new TipoDeEntradaDao();

                conexion.abrir();
                query = "SELECT * FROM Precios WHERE CodCine_Prec = " + idCine + " AND " +
                        "CodTipoDeSala_Prec = " + idTipoSala + " AND CodTipoDeEntrada_Prec = " + idTipoEntrada;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Precio precio = new Precio();
                Cine cine = cineDao.obtener((int)reader[0]);
                precio.setCine(cine);
                TipoDeSala tipoSala = salaDao.obtener((int)reader[1]);
                precio.setTipoSala(tipoSala);
                TipoDeEntrada tipoEntrada = entradaDao.obtener((int)reader[2]);
                precio.setTipoEntrada(tipoEntrada);
                precio.setPrecio((int)reader[3]);

                reader.Close();
                conexion.cerrar();
                return precio;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Precio> obtenerTodos(int idCine, int idTipoSala)
        {
            try
            {
                ICineDao cineDao = new CineDao();
                ITipoDeSalaDao salaDao = new TipoDeSalaDao();
                ITipoDeEntradaDao entradaDao = new TipoDeEntradaDao();
                List<Precio> lista = new List<Precio>();

                conexion.abrir();
                query = "SELECT * FROM Precios WHERE CodCine_Prec = " + idCine + " AND CodTipoDeSala_Prec = " + idTipoSala;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    Precio precio = new Precio();
                    Cine cine = cineDao.obtener((int)reader[0]);
                    precio.setCine(cine);
                    TipoDeSala tipoSala = salaDao.obtener((int)reader[1]);
                    precio.setTipoSala(tipoSala);
                    TipoDeEntrada tipoEntrada = entradaDao.obtener((int)reader[2]);
                    precio.setTipoEntrada(tipoEntrada);
                    precio.setPrecio((int)reader[3]);
                    lista.Add(precio);
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
