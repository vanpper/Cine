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
    class ClasificacionNeg : IClasificacionNeg
    {
        private IClasificacionDao dao = new ClasificacionDao();

        public bool agregar(Clasificacion clasificacion)
        {
            Clasificacion ultima = dao.obtenerUltima();

            if(ultima != null)
            {
                clasificacion.setId(ultima.getId() + 1);
            }
            else
            {
                clasificacion.setId(1);
            }

            return dao.agregar(clasificacion);
        }

        public bool modificar(Clasificacion clasificacion)
        {
            return dao.modificar(clasificacion);
        }

        public Clasificacion obtener(int id)
        {
            return dao.obtener(id);
        }

        public List<Clasificacion> obtenerTodas()
        {
            return dao.obtenerTodas();
        }

        public Clasificacion obtenerUltima()
        {
            return dao.obtenerUltima();
        }
    }
}
