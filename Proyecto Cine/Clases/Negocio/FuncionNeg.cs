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
    class FuncionNeg : IFuncionNeg
    {
        private IFuncionDao dao = new FuncionDao();

        public bool agregar(Funcion funcion)
        {
            throw new NotImplementedException();
        }

        public bool deshabilitar(Funcion funcion)
        {
            return dao.deshabilitar(funcion);
        }

        public bool habilitar(Funcion funcion)
        {
            return dao.habilitar(funcion);
        }

        public bool modificar(Funcion funcion)
        {
            return dao.modificar(funcion);
        }

        public Funcion obtener(int idCine, int idSala, Fecha fecha, Horario horario)
        {
            return dao.obtener(idCine, idSala, fecha, horario);
        }

        public List<Funcion> obtenerTodas()
        {
            return dao.obtenerTodas();
        }
    }
}
