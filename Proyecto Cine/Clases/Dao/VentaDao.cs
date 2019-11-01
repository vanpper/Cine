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
    class VentaDao : Dao, IVentaDao
    {
        public VentaDao() : base()
        {

        }

        public bool agregar(Venta venta)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Ventas VALUES(@codVenta, @codUsuario, @codCine, @codSala, @dia, @horario, @codPelicula, @codFormato, " +
                        "@codTipoEntrada, @cantidadEntradas, @total)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codVenta", SqlDbType.Int);
                comando.Parameters["@codVenta"].Value = venta.getId();
                comando.Parameters.Add("@codUsuario", SqlDbType.Int);
                comando.Parameters["@codUsuario"].Value = venta.getUsuario().getId();
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = venta.getFuncion().getCine().getId();
                comando.Parameters.Add("@codSala", SqlDbType.Int);
                comando.Parameters["@codSala"].Value = venta.getFuncion().getSala().getId();
                comando.Parameters.Add("@dia", SqlDbType.Date);
                comando.Parameters["@dia"].Value = venta.getFuncion().getFecha().ToString();
                comando.Parameters.Add("@horario", SqlDbType.VarChar);
                comando.Parameters["@horario"].Value = venta.getFuncion().getHorario().getHHMM();
                comando.Parameters.Add("@codPelicula", SqlDbType.Int);
                comando.Parameters["@codPelicula"].Value = venta.getFuncion().getPelicula().getId();
                comando.Parameters.Add("@codFormato", SqlDbType.Int);
                comando.Parameters["@codFormato"].Value = venta.getFuncion().getFormato().getId();
                comando.Parameters.Add("@codTipoEntrada", SqlDbType.Int);
                comando.Parameters["@codTipoEntrada"].Value = venta.getTipoEntrada().getId();
                comando.Parameters.Add("@cantidadEntradas", SqlDbType.Int);
                comando.Parameters["@cantidadEntradas"].Value = venta.getCantidadEntradas();
                comando.Parameters.Add("@total", SqlDbType.Int);
                comando.Parameters["@total"].Value = venta.getTotal();

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

        public bool modificar(Venta venta)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Ventas SET CodUsuario_Vent = @codUsuario, CodCine_Vent = @codCine, CodSala_Vent = @codSala, Dia_Vent = @dia, " +
                        "Horario_Vent = @horario, CodPelicula_Vent = @codPelicula, CodFormato_Vent = @codFormato, CodTipoDeEntrada_Vent = @codTipoEntrada, " +
                        "CantidadEntradas_Vent = @cantidadEntradas, Total_Vent = @total WHERE CodVenta_Vent = @codVenta";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@codVenta", SqlDbType.Int);
                comando.Parameters["@codVenta"].Value = venta.getId();
                comando.Parameters.Add("@codUsuario", SqlDbType.Int);
                comando.Parameters["@codUsuario"].Value = venta.getUsuario().getId();
                comando.Parameters.Add("@codCine", SqlDbType.Int);
                comando.Parameters["@codCine"].Value = venta.getFuncion().getCine().getId();
                comando.Parameters.Add("@codSala", SqlDbType.Int);
                comando.Parameters["@codSala"].Value = venta.getFuncion().getSala().getId();
                comando.Parameters.Add("@dia", SqlDbType.Date);
                comando.Parameters["@dia"].Value = venta.getFuncion().getFecha().ToString();
                comando.Parameters.Add("@horario", SqlDbType.VarChar);
                comando.Parameters["@horario"].Value = venta.getFuncion().getHorario().getHHMM();
                comando.Parameters.Add("@codPelicula", SqlDbType.Int);
                comando.Parameters["@codPelicula"].Value = venta.getFuncion().getPelicula().getId();
                comando.Parameters.Add("@codFormato", SqlDbType.Int);
                comando.Parameters["@codFormato"].Value = venta.getFuncion().getFormato().getId();
                comando.Parameters.Add("@codTipoEntrada", SqlDbType.Int);
                comando.Parameters["@codTipoEntrada"].Value = venta.getTipoEntrada().getId();
                comando.Parameters.Add("@cantidadEntradas", SqlDbType.Int);
                comando.Parameters["@cantidadEntradas"].Value = venta.getCantidadEntradas();
                comando.Parameters.Add("@total", SqlDbType.Int);
                comando.Parameters["@total"].Value = venta.getTotal();

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

        public Venta obtener(int id)
        {
            try
            {
                IUsuarioDao usuarioDao = new UsuarioDao();
                IFuncionDao funcionDao = new FuncionDao();
                ITipoDeEntradaDao entradaDao = new TipoDeEntradaDao();

                conexion.abrir();
                query = "SELECT * FROM Ventas WHERE CodVenta_Vent = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Venta venta = new Venta();
                venta.setId((int)reader[0]);
                Usuario usuario = usuarioDao.obtener((int)reader[1]);
                venta.setUsuario(usuario);
                Funcion funcion = funcionDao.obtener((int)reader[2], (int)reader[3], new Fecha((DateTime)reader[4]), new Horario((string)reader[5]));
                venta.setFuncion(funcion);
                TipoDeEntrada tipoEntrada = entradaDao.obtener((int)reader[8]);
                venta.setTipoEntrada(tipoEntrada);
                venta.setCantidadEntradas((int)reader[9]);
                venta.setTotal((int)reader[10]);

                reader.Close();
                conexion.cerrar();
                return venta;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public Venta obtenerUltima()
        {
            try
            {
                IUsuarioDao usuarioDao = new UsuarioDao();
                IFuncionDao funcionDao = new FuncionDao();
                ITipoDeEntradaDao entradaDao = new TipoDeEntradaDao();

                conexion.abrir();
                query = "SELECT TOP 1 * FROM Ventas ORDER BY CodVenta_Vent DESC";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Venta venta = new Venta();
                venta.setId((int)reader[0]);
                Usuario usuario = usuarioDao.obtener((int)reader[1]);
                venta.setUsuario(usuario);
                Funcion funcion = funcionDao.obtener((int)reader[2], (int)reader[3], new Fecha((DateTime)reader[4]), new Horario((string)reader[5]));
                venta.setFuncion(funcion);
                TipoDeEntrada tipoEntrada = entradaDao.obtener((int)reader[8]);
                venta.setTipoEntrada(tipoEntrada);
                venta.setCantidadEntradas((int)reader[9]);
                venta.setTotal((int)reader[10]);

                reader.Close();
                conexion.cerrar();
                return venta;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Venta> obtenerTodas()
        {
            try
            {
                IUsuarioDao usuarioDao = new UsuarioDao();
                IFuncionDao funcionDao = new FuncionDao();
                ITipoDeEntradaDao entradaDao = new TipoDeEntradaDao();
                List<Venta> lista = new List<Venta>();

                conexion.abrir();
                query = "SELECT * FROM Ventas";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    Venta venta = new Venta();
                    venta.setId((int)reader[0]);
                    Usuario usuario = usuarioDao.obtener((int)reader[1]);
                    venta.setUsuario(usuario);
                    Funcion funcion = funcionDao.obtener((int)reader[2], (int)reader[3], new Fecha((DateTime)reader[4]), new Horario((string)reader[5]));
                    venta.setFuncion(funcion);
                    TipoDeEntrada tipoEntrada = entradaDao.obtener((int)reader[8]);
                    venta.setTipoEntrada(tipoEntrada);
                    venta.setCantidadEntradas((int)reader[9]);
                    venta.setTotal((int)reader[10]);
                    lista.Add(venta);
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
