using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IFormatoNeg
    {
        bool agregar(Formato formato);
        bool modificar(Formato formato);
        Formato obtener(int id);
        List<Formato> obtenerTodos();
    }
}
