using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Usuario
    {
        private int id;
        private TipoDeUsuario tipo;
        private String nombre;
        private String apellido;
        private String dni;
        private Fecha cumpleaños;
        private String telefono;
        private Ciudad ciudad;
        private String direccion;
        private String cp;
        private String email;
        private String contraseña;
        private bool estado;

        public Usuario()
        {

        }

        public Usuario(int id, TipoDeUsuario tipo, String nombre, String apellido, String dni, Fecha cumpleaños, 
        String telefono, Ciudad ciudad, String direccion, String cp, String email, String contraseña, bool estado)
        {
            this.id = id;
            this.tipo = tipo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.cumpleaños = cumpleaños;
            this.telefono = telefono;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.cp = cp;
            this.email = email;
            this.contraseña = contraseña;
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

        public void setTipo(TipoDeUsuario tipo)
        {
            this.tipo = tipo;
        }

        public TipoDeUsuario getTipo()
        {
            return this.tipo;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public void setApellido(String apellido)
        {
            this.apellido = apellido;
        }

        public String getApellido()
        {
            return this.apellido;
        }

        public void setDni(String dni)
        {
            this.dni = dni;
        }

        public String getDni()
        {
            return this.dni;
        }

        public void setCumpleaños(Fecha cumpleaños)
        {
            this.cumpleaños = cumpleaños;
        }

        public Fecha getCumpleaños()
        {
            return this.cumpleaños;
        }

        public void setTelefono(String telefono)
        {
            this.telefono = telefono;
        }

        public String getTelefono()
        {
            return this.telefono;
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

        public String getDireccion()
        {
            return this.direccion;
        }

        public void setCp(String cp)
        {
            this.cp = cp;
        }

        public String getCp()
        {
            return this.cp;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public String getEmail()
        {
            return this.email;
        }

        public void setContraseña(String contraseña)
        {
            this.contraseña = contraseña;
        }

        public String getContraseña()
        {
            return this.contraseña;
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
