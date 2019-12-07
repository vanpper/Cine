using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IGeneroNeg
    {
        bool agregar(Genero genero);
        bool modificar(Genero genero);
        Genero obtener(int id);
        Genero obtenerUltimo();
        List<Genero> obtenerTodos();
    }
}
