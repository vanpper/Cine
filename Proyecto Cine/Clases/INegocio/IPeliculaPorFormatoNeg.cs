using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IPeliculaPorFormatoNeg
    {
        bool agregar(PeliculaPorFormato pxf);
        bool deshabilitar(PeliculaPorFormato pxf);
        bool habilitar(PeliculaPorFormato pxf);
        PeliculaPorFormato obtener(int idPelicula, int idFormato);
        List<PeliculaPorFormato> obtenerTodos(int idPelicula);
    }
}
