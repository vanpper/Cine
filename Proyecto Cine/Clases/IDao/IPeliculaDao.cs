using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.IDao
{
    interface IPeliculaDao
    {
        bool agregar(Pelicula pelicula);
        bool modificar(Pelicula pelicula);
        bool deshabilitar(int id);
        bool habilitar(int id);
        Pelicula obtener(int id);
        List<Pelicula> obtenerTodas();
    }
}
