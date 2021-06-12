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

        public CervezaKolsh() { }
        public CervezaKolsh(RecetaCerveza receta)
            : base(ETipoCerveza.Kolsh, receta)
        {
            this.ibu = 6;
        }

        public float Ibu
        {
            get { return this.ibu; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"IBU %{this.Ibu} ");  
            sb.AppendLine(base.ToString());
            
            return sb.ToString();
        }
    }
}

