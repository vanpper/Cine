using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Venta
    {
        private int id;
        private Usuario usuario;
        private Funcion funcion;
        private TipoDeEntrada tipoEntrada;
        private int cantidadEntradas;
        private int total;

        public Venta()
        {

        }

        public Venta(int id, Usuario usuario, Funcion funcion, TipoDeEntrada tipoEntrada, int cantidadEntradas, int total)
        {
            this.id = id;
            this.usuario = usuario;
            this.funcion = funcion;
            this.tipoEntrada = tipoEntrada;
            this.cantidadEntradas = cantidadEntradas;
            this.total = total;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public Usuario getUsuario()
        {
            return this.usuario;
        }

        public void setFuncion(Funcion funcion)
        {
            this.funcion = funcion;
        }

        public Funcion getFuncion()
        {
            return this.funcion;
        }

        public void setTipoEntrada(TipoDeEntrada tipoEntrada)
        {
            this.tipoEntrada = tipoEntrada;
        }

        public TipoDeEntrada getTipoEntrada()
        {
            return this.tipoEntrada;
        }

        public void setCantidadEntradas(int cantidadEntradas)
        {
            this.cantidadEntradas = cantidadEntradas;
        }

        public int getCantidadEntradas()
        {
            return this.cantidadEntradas;
        }

        public void setTotal(int total)
        {
            this.total = total;
        }

        public int getTotal()
        {
            return this.total;
        }

        override
        public String ToString()
        {
            return "id = " + this.id + ", usuario = [" + usuario.ToString() + "], funcion = [" + funcion.ToString() + "], tipoEntrada = [" + tipoEntrada.ToString() + "], " +
                   "cantidadEntradas = " + cantidadEntradas + ", total = " + total;
        }
    }
}