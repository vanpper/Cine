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
    class ProvinciaNeg : IProvinciaNeg
    {
        private IProvinciaDao provinciaDao = new ProvinciaDao();

        public bool agregar(Provincia provincia)
        {
            Provincia ultima = provinciaDao.obtenerUltima();

            if(ultima != null)
            {
                provincia.setId(ultima.getId() + 1);
            }
            else
            {
                provincia.setId(1);
            }

            return provinciaDao.agregar(provincia);
        }

        public bool modificar(Provincia provincia)
        {
            return provinciaDao.modificar(provincia);
        }

        public Provincia obtener(int id)
        {
            return provinciaDao.obtener(id);
        }

        public DataTable obtenerDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Codigo");
            dt.Columns.Add("Provincia");

            foreach (Provincia provincia in obtenerTodas())
            {
                DataRow row = dt.NewRow();
                row[0] = provincia.getId();
                row[1] = provincia.getDescripcion();
                dt.Rows.Add(row);
            }

            return dt;
        }

        public List<Provincia> obtenerTodas()
        {
            return provinciaDao.obtenerTodas();
        }
    }
}
