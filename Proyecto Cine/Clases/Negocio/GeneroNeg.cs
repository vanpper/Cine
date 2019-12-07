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
    class GeneroNeg : IGeneroNeg
    {
        private IGeneroDao generoDao = new GeneroDao();

        public bool agregar(Genero genero)
        {
            Genero ultimo = generoDao.obtenerUltimo();

            if(ultimo != null)
            {
                genero.setId(ultimo.getId() + 1);
            }
            else
            {
                genero.setId(1);
            }

            return generoDao.agregar(genero);
        }

        public bool modificar(Genero genero)
        {
            return generoDao.modificar(genero);
        }

        public Genero obtener(int id)
        {
            return generoDao.obtener(id);
        }

        public List<Genero> obtenerTodos()
        {
            return generoDao.obtenerTodos();
        }

        public Genero obtenerUltimo()
        {
            return generoDao.obtenerUltimo();
        }
    }
}
