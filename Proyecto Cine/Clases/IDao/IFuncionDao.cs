using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.IDao
{
    interface IFuncionDao
    {
        bool agregar(Funcion funcion);
        bool modificar(Funcion funcion);
        bool deshabilitar(Funcion funcion);
        bool habilitar(Funcion funcion);
        Funcion obtener(int idCine, int idSala, Fecha fecha, Horario horario);
        List<Funcion> obtenerTodas();
    }
}
