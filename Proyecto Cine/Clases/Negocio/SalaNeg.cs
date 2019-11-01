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
    class SalaNeg : ISalaNeg
    {
        private ISalaDao salaDao = new SalaDao();

        public bool agregar(Sala sala)
        {
            Sala ultima = salaDao.obtenerUltima(sala.getCine().getId());

            if(ultima != null)
            {
                sala.setId(ultima.getId() + 1);
            }
            else
            {
                sala.setId(1);
            }

            return salaDao.agregar(sala);
        }

        public bool deshabilitar(int idCine, int idSala)
        {
            return salaDao.deshabilitar(idCine, idSala);
        }

        public bool habilitar(int idCine, int idSala)
        {
            return salaDao.habilitar(idCine, idSala);
        }

        public bool modificar(Sala sala)
        {
            return salaDao.modificar(sala);
        }

        public Sala obtener(int idCine, int idSala)
        {
            return salaDao.obtener(idCine, idSala);
        }

        public List<Sala> obtenerTodas(int idCine)
        {
            return salaDao.obtenerTodas(idCine);
        }
    }
}
