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
    class CineNeg : ICineNeg
    {
        private ICineDao cineDao = new CineDao();

        public bool agregar(Cine cine)
        {
            Cine ultimo = cineDao.obtenerUltimo();

            if(ultimo != null)
            {
                cine.setId(ultimo.getId() + 1);
            }
            else
            {
                cine.setId(1);
            }

            return cineDao.agregar(cine);
        }

        public bool deshabilitar(int id)
        {
            return cineDao.deshabilitar(id);
        }

        public bool habilitar(int id)
        {
            return cineDao.habilitar(id);
        }

        public bool modificar(Cine cine)
        {
            return cineDao.modificar(cine);
        }

        public Cine obtener(int id)
        {
            return cineDao.obtener(id);
        }

        public List<Cine> obtenerTodos()
        {
            return cineDao.obtenerTodos();
        }

        public Cine obtenerUltimo()
        {
            return cineDao.obtenerUltimo();
        }
    }
}
