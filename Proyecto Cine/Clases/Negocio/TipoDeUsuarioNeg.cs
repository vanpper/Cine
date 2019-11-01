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
    class TipoDeUsuarioNeg : ITipoDeUsuarioNeg
    {
        private ITipoDeUsuarioDao tipoDao = new TipoDeUsuarioDao();

        public bool agregar(TipoDeUsuario tipo)
        {
            TipoDeUsuario ultimo = tipoDao.obtenerUltimo();

            if(ultimo != null)
            {
                tipo.setId(ultimo.getId() + 1);
            }
            else
            {
                tipo.setId(1);
            }

            return tipoDao.agregar(tipo);
        }

        public bool modificar(TipoDeUsuario tipo)
        {
            return tipoDao.modificar(tipo);
        }

        public TipoDeUsuario obtener(int id)
        {
            return tipoDao.obtener(id);
        }

        public List<TipoDeUsuario> obtenerTodos()
        {
            return tipoDao.obtenerTodos();
        }
    }
}
