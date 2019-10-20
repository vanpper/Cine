using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Cine
    {
        private int id;
        private String nombre;
        private Ciudad ciudad;
        private String direccion;
        private String descripcion;
        private List<Sala> salas;
        private bool estado;

        public Cine()
        {

        }

        public Cine(int id, String nombre, Ciudad ciudad, String direccion, String descripcion, List<Sala> salas, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.descripcion = descripcion;
            this.salas = salas;
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

        public void setCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }

        public Ciudad getCiudad()
        {
            return this.ciudad;
        }

        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }

        public String getdireccion()
        {
            return this.direccion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        public void setSalas(List<Sala> salas)
        {
            this.salas = salas;
        }

        public List<Sala> getSalas()
        {
            return this.salas;
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
