using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class PeliculaPorFormato
    {
        private Pelicula pelicula;
        private Formato formato;
        private bool estado;

        public PeliculaPorFormato()
        {

        }

        public PeliculaPorFormato(Pelicula pelicula, Formato formato, bool estado)
        {
            this.pelicula = pelicula;
            this.formato = formato;
            this.estado = estado;
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
            return "formato = [" + this.formato.ToString() + "], estado = " + this.estado + ", pelicula = [" + this.pelicula.ToString() + "]";
        }
    }
}
