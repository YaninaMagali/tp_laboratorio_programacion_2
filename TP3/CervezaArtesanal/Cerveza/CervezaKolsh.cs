using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    [Serializable]
    public class CervezaKolsh : CervezaArtesanal
    {
        private float ibu;

        /// <summary>
        /// Constructor sin parametros para permitir la serializacion
        /// </summary>
        public CervezaKolsh() { }

        /// <summary>
        /// COnstructor con parametros
        /// </summary>
        /// <param name="receta">receta que tiene ingredientes y cantidades</param>
        public CervezaKolsh(RecetaCerveza receta)
            : base(ETipoCerveza.Kolsh, receta)
        {
            this.ibu = 6;
        }

        /// <summary>
        /// Propiedad de solo lectura para el atributo Ibu
        /// </summary>
        public float Ibu
        {
            get { return this.ibu; }
        }

        /// <summary>
        /// Devuelve en formato string los atributos de la cerveza Kolsh
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"IBU %{this.Ibu} ");  
            sb.AppendLine(base.ToString());
            
            return sb.ToString();
        }
    }
}

