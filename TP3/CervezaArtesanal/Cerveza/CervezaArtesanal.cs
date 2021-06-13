using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CervezaArtesanal
{
    [Serializable]
    [XmlInclude(typeof(CervezaIPA))]
    [XmlInclude(typeof(CervezaKolsh))]

    public abstract class CervezaArtesanal
    {
        public ETipoCerveza tipo;
        [NonSerialized()]private RecetaCerveza receta;

        public CervezaArtesanal() { }
        public CervezaArtesanal(ETipoCerveza tipo, RecetaCerveza receta)
        {
            this.tipo = tipo;
            this.receta = receta;
        }

        public ETipoCerveza TipoCerveza{ get { return this.tipo; } }

        public RecetaCerveza Receta { get { return this.receta; } }

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
