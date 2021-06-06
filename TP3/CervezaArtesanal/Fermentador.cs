using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class Fermentador
    {
        public int capacidadLitros;
        public Receta receta;

        public Fermentador()
        {
            this.capacidadLitros = 50;
        }

        public Fermentador(Receta receta) :this()
        {
            this. receta = receta;
        }

        public Receta Receta
            {
            get { return this.receta;  }
            set
            {
                if (ValidarCapacidad(value))
                {
                    this.receta = value;
                }

            }
            }

        public int Capacidad
        {
            get { return this.capacidadLitros; }
            set { this.capacidadLitros = value; }
        }

        public bool ValidarCapacidad(Receta receta)
        {
            bool tieneCapadidad = false;

            if(receta.litrosAPreparar <= this.capacidadLitros)
            { 
                tieneCapadidad = true; 
            }
            return tieneCapadidad;
        }

        public void ActualizarCapacidad(Receta receta)
        {
            this.Capacidad = this.Capacidad - receta.litrosAPreparar;
        }
        
        //public bool ValidarDisponibilidad()
        //{
        //    bool estaLibre = false;

        //    if(this.receta is null)
        //    {
        //        estaLibre = true;
        //    }

        //    return estaLibre;
        //}




    }
}
