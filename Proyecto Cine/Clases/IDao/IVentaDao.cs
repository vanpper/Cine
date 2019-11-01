using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.IDao
{
    interface IVentaDao
    {
        bool agregar(Venta venta);
        bool modificar(Venta venta);
        Venta obtener(int id);
        Venta obtenerUltima();
        List<Venta> obtenerTodas();
    }
}
