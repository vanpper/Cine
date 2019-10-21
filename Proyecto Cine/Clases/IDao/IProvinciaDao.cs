﻿using Proyecto_Cine.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.IDao
{
    interface IProvinciaDao
    {
        bool agregar(Provincia provincia);
        bool modificar(Provincia provincia);
        Provincia obtener(int id);
        List<Provincia> obtenerTodas();
    }
}