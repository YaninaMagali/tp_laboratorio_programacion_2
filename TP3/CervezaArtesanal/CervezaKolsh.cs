using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    class CervezaKolsh : CervezaArtesanal
    {
        public CervezaKolsh(Receta receta)
            : base(ETipoCerveza.Kolsh, receta)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"IBU %2 ");  
            sb.AppendLine(base.ToString());
            
            return sb.ToString();
        }
    }
}

