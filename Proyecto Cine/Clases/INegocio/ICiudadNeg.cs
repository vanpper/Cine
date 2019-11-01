using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface ICiudadNeg
    {
        bool agregar(Ciudad ciudad);
        bool modificar(Ciudad ciudad);
        Ciudad obtener(int idProvincia, int idCiudad);
        List<Ciudad> obtenerTodas(int idProvincia);
    }
}
