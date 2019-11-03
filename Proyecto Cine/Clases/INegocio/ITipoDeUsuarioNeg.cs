﻿using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.INegocio
{
    interface ITipoDeUsuarioNeg
    {
        bool agregar(TipoDeUsuario tipo);
        bool modificar(TipoDeUsuario tipo);
        TipoDeUsuario obtener(int id);
        List<TipoDeUsuario> obtenerTodos();
    }
}