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

        /// <summary>
        /// COnstructor sin parametros. Le asigna un valores por defecto a los atributos
        /// </summary>
        public Fermentador()
        {
            this.capacidadLitros = 50;
            this.tipoCerveza = ETipoCerveza.IPA;
        }

        /// <summary>
        /// Sobrecarga del constructor, si recibe solo el tipo de cerveza lo asigna y le asigna el valor por defecto a la capacidad
        /// </summary>
        /// <param name="tipoCerveza"></param>
        public Fermentador(ETipoCerveza tipoCerveza) : this()
        {
            this.tipoCerveza = tipoCerveza;
        }

        /// <summary>
        ///  Sobrecarga del constructor, asigna valores recibidos por parametro a los atributos de clase
        /// </summary>
        /// <param name="tipoCerveza"></param>
        /// <param name="capacidadLitros"></param>
        public Fermentador(ETipoCerveza tipoCerveza, float capacidadLitros):this(tipoCerveza)
        {
            this.capacidadLitros = capacidadLitros;
        }

        /// <summary>
        /// Propiedad de lectura y escritura. 
        /// Si la capacidad que se le quiere asignar es mayor a la actual no lo permite
        /// </summary>
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

        /// <summary>
        /// Evalua si el fermentador soporta la capacidad que se le quiere asignar para almacenamiento
        /// </summary>
        /// <param name="litrosAAlmacenar"></param>
        /// <returns>Si soporta la capacidad devuelve true, sino false</returns>
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
