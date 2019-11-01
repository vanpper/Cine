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
    class TipoDeSalaNeg : ITipoDeSalaNeg
    {
        private ITipoDeSalaDao tipoDao = new TipoDeSalaDao();

        public bool agregar(TipoDeSala tipoSala)
        {
            TipoDeSala ultimo = tipoDao.obtenerUltimo();

            if(ultimo != null)
            {
                tipoSala.setId(ultimo.getId() + 1);
            }
            else
            {
                tipoSala.setId(1);
            }

            return tipoDao.agregar(tipoSala);
        }

        public bool modificar(TipoDeSala tipoSala)
        {
            return tipoDao.modificar(tipoSala);
        }

        public TipoDeSala obtener(int id)
        {
            return tipoDao.obtener(id);
        }

        public List<TipoDeSala> obtenerTodos()
        {
            return tipoDao.obtenerTodos();
        }
    }
}
