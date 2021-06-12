using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public abstract class Receta : IReceta
    {
        public Dictionary<EIngredientes, float> ingredientes;

        public Receta()
        { 
            this.ingredientes = new Dictionary<EIngredientes, float>();
        }

        /// <summary>
        /// Propiedad por la cual se accede al dict de ingredientes y se asignan ingredientes a la receta 
        /// </summary>
        public Dictionary<EIngredientes, float> Ingredientes
        { 
            get { return this.ingredientes; }
            set
            {
                this.ingredientes = value;
            }
        
        }

        /// <summary>
        /// Crea un string con todos los ingredientes de la receta
        /// </summary>
        /// <returns>Retorna un string con los ingredientes de la receta</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(KeyValuePair<EIngredientes, float> i in ingredientes)
            { 
                sb.AppendLine($"{i.Value.ToString()} gramos de {i.Key.ToString()} "); }
            
            return sb.ToString();

        }

        public abstract Receta CalcularIngredientes();
    }
}
