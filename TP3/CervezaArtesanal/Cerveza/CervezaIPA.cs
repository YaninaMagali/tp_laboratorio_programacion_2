using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    [Serializable]
    public class CervezaIPA : Cerveza
    {
        /// <summary>
        /// Constructor sin parametros para permitir la serializacion
        /// </summary>
        public CervezaIPA() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="receta">receta que tiene ingredientes y cantidades</param>
        public CervezaIPA(RecetaCerveza receta) 
            : base(ETipoCerveza.IPA, receta)
        {
        }

    }
}
