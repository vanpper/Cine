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
    class PrecioNeg : IPrecioNeg
    {
        private IPrecioDao dao = new PrecioDao();

        public bool agregar(Precio precio)
        {
            return dao.agregar(precio);
        }

        public bool modificar(Precio precio)
        {
            return dao.modificar(precio);
        }

        public Precio obtener(int idCine, int idTipoSala, int idTipoEntrada)
        {
            return dao.obtener(idCine, idTipoSala, idTipoEntrada);
        }

        public List<Precio> obtenerTodos(int idCine, int idTipoSala)
        {
            return dao.obtenerTodos(idCine, idTipoSala);
        }
    }
}
