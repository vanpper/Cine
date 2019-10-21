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

            
            

            IProvinciaDao provDao = new ProvinciaDao();
            List<Provincia> lista = provDao.obtenerTodas();

            foreach(Provincia provincia in lista)
            {
                Console.WriteLine(provincia.ToString());
            }



        }
    }
}
