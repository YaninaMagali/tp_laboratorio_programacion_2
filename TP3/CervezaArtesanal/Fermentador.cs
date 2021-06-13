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
        public ETipoCerveza tipoCerveza;

        public Fermentador()
        {
            this.capacidadLitros = 50;
        }

        public Fermentador(ETipoCerveza tipoCerveza) : this()
        {
        }

        public Fermentador(ETipoCerveza tipoCerveza, float capacidadLitros):this()
        {
            this.tipoCerveza = tipoCerveza;
            this.capacidadLitros = capacidadLitros;
        }

        public float CapacidadLitros
        {
            get { return this.capacidadLitros;  }
            set
            {
                if (ValidarCapacidad(value))
                {
                    this.capacidadLitros = this.capacidadLitros - value;
                }

            }
            }

        public bool ValidarCapacidad(float litrosAAlmacenar)
        {
            bool tieneCapadidad = false;

            if(litrosAAlmacenar <= this.capacidadLitros)
            { 
                tieneCapadidad = true; 
            }
            return tieneCapadidad;
        }

    }
}
