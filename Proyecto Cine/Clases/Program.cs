using Proyecto_Cine.Clases.Dao;
using Proyecto_Cine.Clases.Entidades;
using Proyecto_Cine.Clases.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cine
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Forms.Principal());

            IPeliculaDao peliculaDao = new PeliculaDao();
            IGeneroDao generoDao = new GeneroDao();
            IClasificacionDao clasificacionDao = new ClasificacionDao();
            Pelicula pelicula = new Pelicula();

           

            pelicula = peliculaDao.obtener(10);

            Pelicula pelicula2 = peliculaDao.obtener(6);

            pelicula.setImagen(pelicula2.getImagen());
            pelicula.setActores("ActoresTEST");
            pelicula.setDirector("DirectorTEST");
            pelicula.setDescripcion("descripcionTEST");
            pelicula.setDuracion(123);

            peliculaDao.modificar(pelicula);


        }
    }
}
