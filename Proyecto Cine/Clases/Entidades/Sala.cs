using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Sala
    {
        private Cine cine;
        private int id;
        private TipoDeSala tipo;
        private String descripcion;
        private bool estado;

        public Sala()
        {

        }

        public Sala(Cine cine, int id, TipoDeSala tipo, String descripcion, bool estado)
        {
            this.cine = cine;
            this.id = id;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        public void setCine(Cine cine)
        {
            this.cine = cine;
        }

        public Cine getCine()
        {
            return this.cine;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setTipo(TipoDeSala tipo)
        {
            this.tipo = tipo;
        }

        public TipoDeSala getTipo()
        {
            return this.tipo;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        public void setEstado(bool estado)
        {
            this.estado = estado;
        }

        public bool getEstado()
        {
            return this.estado;
        }

        override
        public String ToString()
        {
            return "id = " + this.id + ", descripcion = " + this.descripcion + ", estado = " + this.estado + ", tipo = " + this.tipo.ToString() + ", " +
                   "cine = " + cine.ToString();
        }
    }
}
