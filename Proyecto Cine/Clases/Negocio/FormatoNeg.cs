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
    class FormatoNeg : IFormatoNeg
    {
        private IFormatoDao formatoDao = new FormatoDao();

        public bool agregar(Formato formato)
        {
            Formato ultimo = formatoDao.obtenerUltimo();

            if(ultimo != null)
            {
                formato.setId(ultimo.getId() + 1);
            }
            else
            {
                formato.setId(1);
            }

            return formatoDao.agregar(formato);
        }

        public bool modificar(Formato formato)
        {
            return formatoDao.modificar(formato);
        }

        public Formato obtener(int id)
        {
            return formatoDao.obtener(id);
        }

        public List<Formato> obtenerTodos()
        {
            return formatoDao.obtenerTodos();
        }
    }
}
