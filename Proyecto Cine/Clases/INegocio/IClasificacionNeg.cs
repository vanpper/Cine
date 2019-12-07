using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IClasificacionNeg
    {
        bool agregar(Clasificacion clasificacion);
        bool modificar(Clasificacion clasificacion);
        Clasificacion obtener(int id);
        Clasificacion obtenerUltima();
        List<Clasificacion> obtenerTodas();
    }
}
