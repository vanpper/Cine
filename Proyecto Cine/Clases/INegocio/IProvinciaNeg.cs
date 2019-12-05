using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IProvinciaNeg
    {
        bool agregar(Provincia provincia);
        bool modificar(Provincia provincia);
        Provincia obtener(int id);
        Provincia obtenerUltima();
        List<Provincia> obtenerTodas();
    }
}
