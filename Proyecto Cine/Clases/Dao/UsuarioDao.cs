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
    class UsuarioDao : Dao, IUsuarioDao
    {
        public UsuarioDao() : base()
        {

        }

        public bool agregar(Usuario usuario)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Usuarios VALUES(@cod, @codTipo, @nombre, @apellido, @dni, @cumpleaños, @telefono, " +
                        "@codProvincia, @codCiudad, @direccion, @cp, @email, @contraseña, @estado)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = usuario.getId();
                comando.Parameters.Add("@codTipo", SqlDbType.Int);
                comando.Parameters["@codTipo"].Value = usuario.getTipo().getId();
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = usuario.getNombre();
                comando.Parameters.Add("@apellido", SqlDbType.VarChar);
                comando.Parameters["@apellido"].Value = usuario.getApellido();
                comando.Parameters.Add("@dni", SqlDbType.VarChar);
                comando.Parameters["@dni"].Value = usuario.getDni();
                comando.Parameters.Add("@cumpleaños", SqlDbType.Date);
                comando.Parameters["@cumpleaños"].Value = usuario.getCumpleaños().ToString();
                comando.Parameters.Add("@telefono", SqlDbType.VarChar);
                comando.Parameters["@telefono"].Value = usuario.getTelefono();
                comando.Parameters.Add("@codProvincia", SqlDbType.Int);
                comando.Parameters["@codProvincia"].Value = usuario.getCiudad().getProvincia().getId();
                comando.Parameters.Add("@codCiudad", SqlDbType.Int);
                comando.Parameters["@codCiudad"].Value = usuario.getCiudad().getId();
                comando.Parameters.Add("@direccion", SqlDbType.VarChar);
                comando.Parameters["@direccion"].Value = usuario.getDireccion();
                comando.Parameters.Add("@cp", SqlDbType.VarChar);
                comando.Parameters["@cp"].Value = usuario.getCp();
                comando.Parameters.Add("@email", SqlDbType.VarChar);
                comando.Parameters["@email"].Value = usuario.getEmail();
                comando.Parameters.Add("@contraseña", SqlDbType.VarChar);
                comando.Parameters["@contraseña"].Value = usuario.getContraseña();
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = usuario.getEstado();

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

        public bool modificar(Usuario usuario)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Usuarios SET CodTipoDeUsuario_Usua = @codTipo, Nombre_Usua = @nombre, Apellido_Usua = @apellido, DNI_Usua = @dni, " +
                        "Cumpleaños_Usua = @cumpleaños, Telefono_Usua = @telefono, CodProvincia_Usua = @codProvincia, CodCiudad_Usua = @codCiudad, " +
                        "Direccion_Usua = @direccion, CodigoPostal_Usua = @cp, Email_Usua = @email, Contraseña_Usua = @contraseña, Estado_Usua = @estado " +
                        "WHERE CodUsuario_Usua = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = usuario.getId();
                comando.Parameters.Add("@codTipo", SqlDbType.Int);
                comando.Parameters["@codTipo"].Value = usuario.getTipo().getId();
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = usuario.getNombre();
                comando.Parameters.Add("@apellido", SqlDbType.VarChar);
                comando.Parameters["@apellido"].Value = usuario.getApellido();
                comando.Parameters.Add("@dni", SqlDbType.VarChar);
                comando.Parameters["@dni"].Value = usuario.getDni();
                comando.Parameters.Add("@cumpleaños", SqlDbType.Date);
                comando.Parameters["@cumpleaños"].Value = usuario.getCumpleaños().ToString();
                comando.Parameters.Add("@telefono", SqlDbType.VarChar);
                comando.Parameters["@telefono"].Value = usuario.getTelefono();
                comando.Parameters.Add("@codProvincia", SqlDbType.Int);
                comando.Parameters["@codProvincia"].Value = usuario.getCiudad().getProvincia().getId();
                comando.Parameters.Add("@codCiudad", SqlDbType.Int);
                comando.Parameters["@codCiudad"].Value = usuario.getCiudad().getId();
                comando.Parameters.Add("@direccion", SqlDbType.VarChar);
                comando.Parameters["@direccion"].Value = usuario.getDireccion();
                comando.Parameters.Add("@cp", SqlDbType.VarChar);
                comando.Parameters["@cp"].Value = usuario.getCp();
                comando.Parameters.Add("@email", SqlDbType.VarChar);
                comando.Parameters["@email"].Value = usuario.getEmail();
                comando.Parameters.Add("@contraseña", SqlDbType.VarChar);
                comando.Parameters["@contraseña"].Value = usuario.getContraseña();
                comando.Parameters.Add("@estado", SqlDbType.Bit);
                comando.Parameters["@estado"].Value = usuario.getEstado();

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

        public Usuario obtener(int id)
        {
            try
            {
                ITipoDeUsuarioDao tipoDao = new TipoDeUsuarioDao();
                ICiudadDao ciudadDao = new CiudadDao();

                conexion.abrir();
                query = "SELECT * FROM Usuarios WHERE CodUsuario_Usua = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Usuario usuario = new Usuario();
                usuario.setId((int)reader[0]);
                TipoDeUsuario tipo = tipoDao.obtener((int)reader[1]);
                usuario.setTipo(tipo);
                usuario.setNombre((string)reader[2]);
                usuario.setApellido((string)reader[3]);
                usuario.setDni((string)reader[4]);
                usuario.setCumpleaños(new Fecha((DateTime)reader[5]));
                usuario.setTelefono((string)reader[6]);
                Ciudad ciudad = ciudadDao.obtener((int)reader[7], (int)reader[8]);
                usuario.setCiudad(ciudad);
                usuario.setDireccion((string)reader[9]);
                usuario.setCp((string)reader[10]);
                usuario.setEmail((string)reader[11]);
                usuario.setContraseña((string)reader[12]);
                usuario.setEstado((bool)reader[13]);

                reader.Close();
                conexion.cerrar();
                return usuario;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public Usuario obtener(string email)
        {
            try
            {
                ITipoDeUsuarioDao tipoDao = new TipoDeUsuarioDao();
                ICiudadDao ciudadDao = new CiudadDao();

                conexion.abrir();
                query = "SELECT * FROM Usuarios WHERE Email_Usua = '" + email + "'";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Usuario usuario = new Usuario();
                usuario.setId((int)reader[0]);
                TipoDeUsuario tipo = tipoDao.obtener((int)reader[1]);
                usuario.setTipo(tipo);
                usuario.setNombre((string)reader[2]);
                usuario.setApellido((string)reader[3]);
                usuario.setDni((string)reader[4]);
                usuario.setCumpleaños(new Fecha((DateTime)reader[5]));
                usuario.setTelefono((string)reader[6]);
                Ciudad ciudad = ciudadDao.obtener((int)reader[7], (int)reader[8]);
                usuario.setCiudad(ciudad);
                usuario.setDireccion((string)reader[9]);
                usuario.setCp((string)reader[10]);
                usuario.setEmail((string)reader[11]);
                usuario.setContraseña((string)reader[12]);
                usuario.setEstado((bool)reader[13]);

                reader.Close();
                conexion.cerrar();
                return usuario;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Usuario> obtenerTodos()
        {
            try
            {
                ITipoDeUsuarioDao tipoDao = new TipoDeUsuarioDao();
                ICiudadDao ciudadDao = new CiudadDao();
                List<Usuario> lista = new List<Usuario>();

                conexion.abrir();
                query = "SELECT * FROM Usuarios";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.setId((int)reader[0]);
                    TipoDeUsuario tipo = tipoDao.obtener((int)reader[1]);
                    usuario.setTipo(tipo);
                    usuario.setNombre((string)reader[2]);
                    usuario.setApellido((string)reader[3]);
                    usuario.setDni((string)reader[4]);
                    usuario.setCumpleaños(new Fecha((DateTime)reader[5]));
                    usuario.setTelefono((string)reader[6]);
                    Ciudad ciudad = ciudadDao.obtener((int)reader[7], (int)reader[8]);
                    usuario.setCiudad(ciudad);
                    usuario.setDireccion((string)reader[9]);
                    usuario.setCp((string)reader[10]);
                    usuario.setEmail((string)reader[11]);
                    usuario.setContraseña((string)reader[12]);
                    usuario.setEstado((bool)reader[13]);
                    lista.Add(usuario);
                }

                reader.Close();
                conexion.cerrar();
                return lista;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }
    }
}
