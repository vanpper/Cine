using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IPrecioNeg
    {
        bool agregar(Precio precio);
        bool modificar(Precio precio);
        Precio obtener(int idCine, int idTipoSala, int idTipoEntrada);
        List<Precio> obtenerTodos(int idCine, int idTipoSala);
    }
}
