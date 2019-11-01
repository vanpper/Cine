using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IVentaNeg
    {
        bool agregar(Venta venta);
        bool modificar(Venta venta);
        Venta obtener(int id);
        List<Venta> obtenerTodas();
    }
}
