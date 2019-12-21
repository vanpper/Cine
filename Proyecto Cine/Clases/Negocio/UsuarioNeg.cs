using Proyecto_Cine.Clases.Dao;
using Proyecto_Cine.Clases.Entidades;
using Proyecto_Cine.Clases.IDao;
using Proyecto_Cine.Clases.INegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Negocio
{
    class UsuarioNeg : IUsuarioNeg
    {
        private IUsuarioDao usuarioDao = new UsuarioDao();

        public bool agregar(Usuario usuario)
        {
            Usuario ultimo = usuarioDao.obtenerUltimo();

            if(ultimo != null)
            {
                usuario.setId(ultimo.getId() + 1);
            }
            else
            {
                usuario.setId(1);
            }

            return usuarioDao.agregar(usuario);
        }

        public bool modificar(Usuario usuario)
        {
            return usuarioDao.modificar(usuario);
        }

        public Usuario obtener(int id)
        {
            return usuarioDao.obtener(id);
        }

        public Usuario obtener(string email)
        {
            return usuarioDao.obtener(email);
        }

        public List<Usuario> obtenerTodos()
        {
            return usuarioDao.obtenerTodos();
        }

        public Usuario obtenerUltimo()
        {
            return usuarioDao.obtenerUltimo();
        }
    }
}
