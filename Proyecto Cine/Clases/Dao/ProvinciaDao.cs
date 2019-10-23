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
    class ProvinciaDao : Dao, IProvinciaDao
    {
        public ProvinciaDao() : base()
        {

        }

        public bool agregar(Provincia provincia)
        {
            try
            {
                conexion.abrir();
                query = "INSERT INTO Provincias VALUES(@cod, @descripcion)";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = provincia.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = provincia.getDescripcion();

                comando.ExecuteNonQuery();
                conexion.cerrar();
                return true;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                conexion.cerrar();
                return false;
            }
        }

        public bool modificar(Provincia provincia)
        {
            try
            {
                conexion.abrir();
                query = "UPDATE Provincias SET Descripcion_Prov = @descripcion WHERE CodProvincia_Prov = @cod";

                comando = new SqlCommand(query, conexion.getSqlConnection());
                comando.Parameters.Add("@cod", SqlDbType.Int);
                comando.Parameters["@cod"].Value = provincia.getId();
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
                comando.Parameters["@descripcion"].Value = provincia.getDescripcion();

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

        public Provincia obtener(int id)
        {
            try
            {
                conexion.abrir();
                query = "SELECT * FROM Provincias WHERE CodProvincia_Prov = " + id;

                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                reader.Read();

                Provincia provincia = new Provincia();
                provincia.setId((int)reader[0]);
                provincia.setDescripcion((string)reader[1]);

                reader.Close();
                conexion.cerrar();
                return provincia;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
                conexion.cerrar();
                return null;
            }
        }

        public List<Provincia> obtenerTodas()
        {
            try
            {
                conexion.abrir();
                query = "SELECT * FROM Provincias";
                List<Provincia> lista = new List<Provincia>();
                comando = new SqlCommand(query, conexion.getSqlConnection());
                reader = comando.ExecuteReader();
                
                while(reader.Read())
                {
                    Provincia provincia = new Provincia();
                    provincia.setId((int)reader[0]);
                    provincia.setDescripcion((string)reader[1]);
                    lista.Add(provincia);
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
