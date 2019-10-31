using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Precio
    {
        private Cine cine;
        private TipoDeSala tipoSala;
        private TipoDeEntrada tipoEntrada;
        private int precio;

        public Precio()
        {

        }

        public Precio(Cine cine, TipoDeSala tipoSala, TipoDeEntrada tipoEntrada, int precio)
        {
            this.cine = cine;
            this.tipoSala = tipoSala;
            this.tipoEntrada = tipoEntrada;
            this.precio = precio;
        }

        public void setCine(Cine cine)
        {
            this.cine = cine;
        }

        public Cine getCine()
        {
            return this.cine;
        }

        public void setTipoSala(TipoDeSala tipoSala)
        {
            this.tipoSala = tipoSala;
        }

        public TipoDeSala getTipoSala()
        {
            return this.tipoSala;
        }

        public void setTipoEntrada(TipoDeEntrada tipoEntrada)
        {
            this.tipoEntrada = tipoEntrada;
        }

        public TipoDeEntrada getTipoEntrada()
        {
            return this.tipoEntrada;
        }

        public void setPrecio(int precio)
        {
            this.precio = precio;
        }

        public int getPrecio()
        {
            return this.precio;
        }

        override
        public String ToString()
        {
            return "cine = [" + this.cine.ToString() + "], sala = [" + this.tipoSala.ToString() + "], " +
                   "entrada = [" + this.tipoEntrada.ToString() + "], precio = " + this.precio;
        }
    }
}
