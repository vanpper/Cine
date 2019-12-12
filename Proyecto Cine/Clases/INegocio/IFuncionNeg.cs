using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IFuncionNeg
    {
        bool agregar(Funcion funcion);
        bool modificar(Funcion funcion, Funcion old);
        bool deshabilitar(Funcion funcion);
        bool habilitar(Funcion funcion);
        bool comprobarExistencia(Funcion funcion);
        Funcion obtener(int idCine, int idSala, Fecha fecha, Horario horario);
        List<Funcion> obtenerTodas();
    }
}
