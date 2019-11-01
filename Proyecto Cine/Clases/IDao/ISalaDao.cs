using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.IDao
{
    interface ISalaDao
    {
        bool agregar(Sala sala);
        bool modificar(Sala sala);
        bool deshabilitar(int idCine, int idSala);
        bool habilitar(int idCine, int idSala);
        Sala obtener(int idCine, int idSala);
        Sala obtenerUltima(int idCine);
        List<Sala> obtenerTodas(int idCine);
    }
}
