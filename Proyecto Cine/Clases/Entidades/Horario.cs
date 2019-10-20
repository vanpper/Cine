using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Cine.Clases.Entidades
{
    class Horario
    {
        private int hora;
        private int minuto;

        public Horario()
        {

        }

        public Horario(int hora, int minuto)
        {
            this.hora = hora;
            this.minuto = minuto;
        }

        public void setHora(int hora)
        {
            this.hora = hora;
        }

        public int getHora()
        {
            return this.hora;
        }

        public void setMinuto(int minuto)
        {
            this.minuto = minuto;
        }

        public int getMinuto()
        {
            return this.minuto;
        }

        public String getHorario()
        {
            String horas;
            String minutos;

            if (this.hora >= 0 && this.hora <= 9) horas = "0" + this.hora;
            else horas = this.hora.ToString();

            if (this.minuto >= 0 && this.minuto <= 9) minutos = "0" + this.minuto;
            else minutos = this.minuto.ToString();

            return horas + ":" + minutos;
        }
    }
}
