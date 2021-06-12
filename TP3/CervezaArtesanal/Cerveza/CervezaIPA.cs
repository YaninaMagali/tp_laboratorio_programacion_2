using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    [Serializable]
    public class CervezaIPA : CervezaArtesanal
    {

        public CervezaIPA() { }
        public CervezaIPA(RecetaCerveza receta) 
            : base(ETipoCerveza.IPA, receta)
        {
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"IBU %6 ");
        //    sb.Append(base.ToString());
            
        //    return sb.ToString();
        //}


    }
}
