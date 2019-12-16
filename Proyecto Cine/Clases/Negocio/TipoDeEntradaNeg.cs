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
    class TipoDeEntradaNeg : ITipoDeEntradaNeg
    {
        private ITipoDeEntradaDao tipoDao = new TipoDeEntradaDao();

        public bool agregar(TipoDeEntrada tipoEntrada)
        {
            TipoDeEntrada ultimo = tipoDao.obtenerUltimo();

            if(ultimo != null)
            {
                tipoEntrada.setId(ultimo.getId() + 1);
            }
            else
            {
                tipoEntrada.setId(1);
            }

            return tipoDao.agregar(tipoEntrada);
        }

        public bool modificar(TipoDeEntrada tipoEntrada)
        {
            return tipoDao.modificar(tipoEntrada);
        }

        public TipoDeEntrada obtener(int id)
        {
            return tipoDao.obtener(id);
        }

        public List<TipoDeEntrada> obtenerTodos()
        {
            return tipoDao.obtenerTodos();
        }

        public TipoDeEntrada obtenerUltimo()
        {
            return tipoDao.obtenerUltimo();
        }
    }
}
