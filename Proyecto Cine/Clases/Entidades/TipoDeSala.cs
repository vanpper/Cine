using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class TipoDeSala
    {
        private int id;
        private String descripcion;

        public TipoDeSala()
        {

        }

        public TipoDeSala(int id, String descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        override
        public String ToString()
        {
            return "id = " + this.id + ", Descripcion = " + this.descripcion;
        }
    }
}
