using Proyecto_Cine.Clases.Dao;
using Proyecto_Cine.Clases.Entidades;
using Proyecto_Cine.Clases.IDao;
using Proyecto_Cine.Clases.INegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Negocio
{
    class VentaNeg : IVentaNeg
    {
        private IVentaDao ventaDao = new VentaDao();

        public bool agregar(Venta venta)
        {
            Venta ultima = ventaDao.obtenerUltima();

            if(ultima != null)
            {
                venta.setId(ultima.getId() + 1);
            }
            else
            {
                venta.setId(1);
            }

            return ventaDao.agregar(venta);
        }

        public bool modificar(Venta venta)
        {
            return ventaDao.modificar(venta);
        }

        public Venta obtener(int id)
        {
            return ventaDao.obtener(id);
        }

        public List<Venta> obtenerTodas()
        {
            return ventaDao.obtenerTodas();
        }
    }
}
