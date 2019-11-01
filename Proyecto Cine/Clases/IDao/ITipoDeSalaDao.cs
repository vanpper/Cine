using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.IDao
{
    interface ITipoDeSalaDao
    {
        bool agregar(TipoDeSala tipoSala);
        bool modificar(TipoDeSala tipoSala);
        TipoDeSala obtener(int id);
        TipoDeSala obtenerUltimo();
        List<TipoDeSala> obtenerTodos();
    }
}
