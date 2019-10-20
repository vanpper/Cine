using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Ciudad
    {
        private Provincia provincia;
        private int id;
        private String descripcion;

        public Ciudad()
        {

        }

        public Ciudad(Provincia provincia, int id, String descripcion)
        {
            this.provincia = provincia;
            this.id = id;
            this.descripcion = descripcion;
        }

        public void setProvincia(Provincia provincia)
        {
            this.provincia = provincia;
        }

        public Provincia getProvincia()
        {
            return this.provincia;
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

        public String toString()
        {
            return "id = " + id + ", descripcion = " + descripcion + ", provincia = [" + provincia.toString() + "]";
        }
    }
}
