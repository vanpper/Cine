using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface ICineNeg
    {
        bool agregar(Cine cine);
        bool modificar(Cine cine);
        bool deshabilitar(int id);
        bool habilitar(int id);
        Cine obtener(int id);
        Cine obtenerUltimo();
        List<Cine> obtenerTodos();
    }
}
