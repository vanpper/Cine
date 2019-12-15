using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IPeliculaNeg
    {
        bool agregar(Pelicula pelicula);
        bool modificar(Pelicula pelicula);
        bool deshabilitar(int id);
        bool habilitar(int id);
        Pelicula obtener(int id);
        Pelicula obtenerUltima();
        List<Pelicula> obtenerTodas();
    }
}
