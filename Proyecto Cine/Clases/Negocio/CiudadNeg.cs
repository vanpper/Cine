using Proyecto_Cine.Clases.Dao;
using Proyecto_Cine.Clases.Entidades;
using Proyecto_Cine.Clases.IDao;
using Proyecto_Cine.Clases.INegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Negocio
{
    class CiudadNeg : ICiudadNeg
    {
        private ICiudadDao ciudadDao = new CiudadDao();

        public bool agregar(Ciudad ciudad)
        {
            Ciudad ultima = ciudadDao.obtenerUltima(ciudad.getProvincia().getId());

            if(ultima != null)
            {
                ciudad.setId(ultima.getId() + 1);
            }
            else
            {
                ciudad.setId(1);
            }

            return ciudadDao.agregar(ciudad);
        }

        public bool modificar(Ciudad ciudad)
        {
            return ciudadDao.modificar(ciudad);
        }

        public Ciudad obtener(int idProvincia, int idCiudad)
        {
            return ciudadDao.obtener(idProvincia, idCiudad);
        }

        public DataTable obtenerTodasDataTable(int idProvincia)
        {
            List<Ciudad> listaCiudades = obtenerTodasList(idProvincia);

            if (listaCiudades == null) return null;

            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo Provincia");
            dt.Columns.Add("Codigo Ciudad");
            dt.Columns.Add("Ciudad");

            foreach (Ciudad ciudad in listaCiudades)
            {
                DataRow row = dt.NewRow();
                row[0] = ciudad.getProvincia().getId();
                row[1] = ciudad.getId();
                row[2] = ciudad.getDescripcion();
                dt.Rows.Add(row);
            }

            return dt;
        }

        public List<Ciudad> obtenerTodasList(int idProvincia)
        {
            return ciudadDao.obtenerTodas(idProvincia);
        }
    }
}
