using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Fecha
    {
        private int dia;
        private int mes;
        private int año;

        public Fecha()
        {

        }

        public Fecha(int dia, int mes, int año)
        {
            this.dia = dia;
            this.mes = mes;
            this.año = año;
        }

        public void setDia(int dia)
        {
            this.dia = dia;
        }

        public int getDia()
        {
            return this.dia;
        }

        public void setMes(int mes)
        {
            this.mes = mes;
        }

        public int getMes()
        {
            return this.mes;
        }

        public void setAño(int año)
        {
            this.año = año;
        }

        public int getAño()
        {
            return this.año;
        }

        public String toString()
        {
            return dia + "-" + mes + "-" + año;
        }
    }
}
