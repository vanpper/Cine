using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Funcion
    {
        private Cine cine;
        private Sala sala;
        private Fecha fecha;
        private Horario horario;
        private Pelicula pelicula;
        private Formato formato;
        private int stock;
        private bool estado;

        public Funcion()
        {

        }

        public Funcion(Cine cine, Sala sala, Fecha fecha, Horario horario, Pelicula pelicula, Formato formato, int stock, bool estado)
        {
            this.cine = cine;
            this.sala = sala;
            this.fecha = fecha;
            this.horario = horario;
            this.pelicula = pelicula;
            this.formato = formato;
            this.stock = stock;
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

        public void setSala(Sala sala)
        {
            this.sala = sala;
        }

        public Sala getSala()
        {
            return this.sala;
        }

        public void setFecha(Fecha fecha)
        {
            this.fecha = fecha;
        }

        public Fecha getFecha()
        {
            return this.fecha;
        }

        public void setHorario(Horario horario)
        {
            this.horario = horario;
        }

        public Horario getHorario()
        {
            return this.horario;
        }

        public void setPelicula(Pelicula pelicula)
        {
            this.pelicula = pelicula;
        }

        public Pelicula getPelicula()
        {
            return this.pelicula;
        }

        public void setFormato(Formato formato)
        {
            this.formato = formato;
        }

        public Formato getFormato()
        {
            return this.formato;
        }

        public void setStock(int stock)
        {
            this.stock = stock;
        }

        public int getStock()
        {
            return this.stock;
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
