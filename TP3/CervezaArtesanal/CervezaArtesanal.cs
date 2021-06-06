using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{

    public abstract class CervezaArtesanal
    {
        public ETipoCerveza tipo;
        public Receta receta;


        public CervezaArtesanal(ETipoCerveza tipo, Receta receta)
        {
            this.tipo = tipo;
            this.receta = receta;
        }

        public ETipoCerveza TipoCerveza{ get { return this.tipo; } }

        public Receta Receta { get { return this.receta; } }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tipo: {this.TipoCerveza.ToString()}");
            sb.AppendLine($"Ingredientes:");
            sb.Append($"{this.receta.ToString()}");
            return sb.ToString();
        }
    }
}
