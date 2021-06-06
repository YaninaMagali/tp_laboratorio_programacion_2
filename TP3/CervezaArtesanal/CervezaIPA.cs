using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class CervezaIPA : CervezaArtesanal
    {
        public CervezaIPA(Receta receta) 
            : base(ETipoCerveza.IPA, receta)
        {
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"IBU %6 ");
            sb.Append(base.ToString());
            
            return sb.ToString();
        }


    }
}
