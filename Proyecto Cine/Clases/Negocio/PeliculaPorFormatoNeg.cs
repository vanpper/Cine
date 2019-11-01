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
    class PeliculaPorFormatoNeg : IPeliculaPorFormatoNeg
    {
        private IPeliculaPorFormatoDao dao = new PeliculaPorFormatoDao();

        public bool agregar(PeliculaPorFormato pxf)
        {
            return dao.agregar(pxf);
        }

        public bool deshabilitar(int idPelicula, int idFormato)
        {
            return dao.deshabilitar(idPelicula, idFormato);
        }

        public bool habilitar(int idPelicula, int idFormato)
        {
            return dao.habilitar(idPelicula, idFormato);
        }

        public PeliculaPorFormato obtener(int idPelicula, int idFormato)
        {
            return dao.obtener(idPelicula, idFormato);
        }

        public List<PeliculaPorFormato> obtenerTodos(int idPelicula)
        {
            return dao.obtenerTodos(idPelicula);
        }
    }
}
