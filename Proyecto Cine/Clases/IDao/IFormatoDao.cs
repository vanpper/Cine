using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.IDao
{
    interface IFormatoDao
    {
        bool agregar(Formato formato);
        bool modificar(Formato formato);
        Formato obtener(int id);
        List<Formato> obtenerTodos();
    }
}
