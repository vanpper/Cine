using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Sala
    {
        private int id;
        private TipoDeSala tipo;
        private String descripcion;
        private bool estado;

        public Sala()
        {

        }

        public Sala(int id, TipoDeSala tipo, String descripcion, bool estado)
        {
            this.id = id;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.estado = estado;
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
    }
}
