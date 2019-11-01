using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface ITipoDeSalaNeg
    {
        bool agregar(TipoDeSala tipoSala);
        bool modificar(TipoDeSala tipoSala);
        TipoDeSala obtener(int id);
        List<TipoDeSala> obtenerTodos();
    }
}
