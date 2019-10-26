using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Pelicula
    {
        private int id;
        private String nombre;
        private int duracion;
        private String actores;
        private String director;
        private Genero genero;
        private Clasificacion clasificacion;
        private String descripcion;
        private byte[] imagen;
        private bool estado;

        public Pelicula()
        {

        }

        public Pelicula(int id, String nombre, int duracion, String actores, String director, Genero genero,
        Clasificacion clasificacion, String descripcion, byte[] imagen, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.duracion = duracion;
            this.actores = actores;
            this.director = director;
            this.genero = genero;
            this.clasificacion = clasificacion;
            this.descripcion = descripcion;
            this.imagen = imagen;
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

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public void setDuracion(int duracion)
        {
            this.duracion = duracion;
        }

        public int getDuracion()
        {
            return this.duracion;
        }

        public void setActores(String actores)
        {
            this.actores = actores;
        }

        public String getActores()
        {
            return this.actores;
        }

        public void setDirector(String director)
        {
            this.director = director;
        }

        public String getDirector()
        {
            return this.director;
        }

        public void setGenero(Genero genero)
        {
            this.genero = genero;
        }

        public Genero getGenero()
        {
            return this.genero;
        }
        
        public void setClasificacion(Clasificacion clasificacion)
        {
            this.clasificacion = clasificacion;
        }

        public Clasificacion getClasificacion()
        {
            return this.clasificacion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        public void setImagen(byte[] imagen)
        {
            this.imagen = imagen;
        }

        public byte[] getImagen()
        {
            return this.imagen;
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
            return "id = " + this.id + ", nombre = " + this.nombre + ", duracion = " + this.duracion + ", actores = " + this.actores + ", " +
                   "director = " + this.director + ", genero = [" + this.genero.ToString() + "], clasificacion = [" + this.clasificacion.ToString() + "], " +
                   "descripcion = " + this.descripcion + ", imagen = " + this.imagen + ", estado = " + this.estado;
        }
    }
}
