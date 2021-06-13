﻿using System;
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
        
        /// <summary>
        /// Constructor sin parametros para permitir la serializacion
        /// </summary>
        public CervezaArtesanal() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="tipo">tipo de cerveza a preparar</param>
        /// <param name="receta">receta con ingredientes y cantidad necesaria de ellos</param>
        public CervezaArtesanal(ETipoCerveza tipo, RecetaCerveza receta)
        {
            this.tipo = tipo;
            this.receta = receta;
        }

        /// <summary>
        /// Propiedad de solo lectura: tipo de cerveza
        /// </summary>
        public ETipoCerveza TipoCerveza{ get { return this.tipo; } }

        /// <summary>
        /// Propiedad de solo lectura: receta con ingredientes y cantidad necesaria de ellos
        /// </summary>
        public RecetaCerveza Receta { get { return this.receta; } }

        /// <summary>
        /// Devuelve en formato string los atributos de la cerveza
        /// </summary>
        /// <returns></returns>
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
