using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface IUsuarioNeg
    {
        bool agregar(Usuario usuario);
        bool modificar(Usuario usuario);
        Usuario obtener(int id);
        Usuario obtener(String email);
        Usuario obtenerUltimo();
        List<Usuario> obtenerTodos();
    }
}
