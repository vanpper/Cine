using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.IDao
{
    interface ITipoDeEntradaDao
    {
        bool agregar(TipoDeEntrada tipoEntrada);
        bool modificar(TipoDeEntrada tipoEntrada);
        TipoDeEntrada obtener(int id);
        List<TipoDeEntrada> obtenerTodos();
    }
}
