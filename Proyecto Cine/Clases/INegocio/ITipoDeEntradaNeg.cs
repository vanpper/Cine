using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface ITipoDeEntradaNeg
    {
        bool agregar(TipoDeEntrada tipoEntrada);
        bool modificar(TipoDeEntrada tipoEntrada);
        TipoDeEntrada obtener(int id);
        TipoDeEntrada obtenerUltimo();
        List<TipoDeEntrada> obtenerTodos();
    }
}
