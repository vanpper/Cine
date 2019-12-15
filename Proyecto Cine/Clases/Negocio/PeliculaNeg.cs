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
    class PeliculaNeg : IPeliculaNeg
    {
        private IPeliculaDao peliculaDao = new PeliculaDao();

        public bool agregar(Pelicula pelicula)
        {
            Pelicula ultima = peliculaDao.obtenerUltima();

            if(ultima != null)
            {
                pelicula.setId(ultima.getId() + 1);
            }
            else
            {
                pelicula.setId(1);
            }

            return peliculaDao.agregar(pelicula);
        }

        public bool deshabilitar(int id)
        {
            return peliculaDao.deshabilitar(id);
        }

        public bool habilitar(int id)
        {
            return peliculaDao.habilitar(id);
        }

        public bool modificar(Pelicula pelicula)
        {
            return peliculaDao.modificar(pelicula);
        }

        public Pelicula obtener(int id)
        {
            return peliculaDao.obtener(1);
        }

        public List<Pelicula> obtenerTodas()
        {
            return peliculaDao.obtenerTodas();
        }

        public Pelicula obtenerUltima()
        {
            return peliculaDao.obtenerUltima();
        }
    }
}
