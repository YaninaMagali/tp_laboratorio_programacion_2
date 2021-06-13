using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class Fermentador
    {
        public float capacidadLitros;
        public RecetaCerveza receta;

        public Fermentador()
        {
            this.capacidadLitros = 50;
        }

        public Fermentador(RecetaCerveza receta) :this()
        {
            this. receta = receta;
        }

        public RecetaCerveza Receta
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

        public float Capacidad
        {
            get { return this.capacidadLitros; }
            set { this.capacidadLitros = value; }
        }

        public bool ValidarCapacidad(RecetaCerveza receta)
        {
            bool tieneCapadidad = false;

            if(receta.litrosAPreparar <= this.capacidadLitros)
            { 
                tieneCapadidad = true; 
            }
            return tieneCapadidad;
        }

        public void ActualizarCapacidad(RecetaCerveza receta)
        {
            this.Capacidad = this.Capacidad - receta.litrosAPreparar;
        }
        
    }
}
