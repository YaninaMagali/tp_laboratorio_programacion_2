using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public abstract class Receta : IReceta
    {
        //[NonSerialized()] 
        public List<Ingrediente> ingredientes;

        /// <summary>
        /// Constructor sin parametros donde se asigna un diccionario instanciado al atributo ingredientes
        /// </summary>
        public Receta()
        { 
            this.ingredientes = new List<Ingrediente>(); 
        }

        /// <summary>
        /// Constructor con parametros. Recibe los ingredientes y asigna al atributo de la clase 
        /// </summary>
        /// <param name="ingredientes"></param>
        public Receta(List<Ingrediente> ingredientes) :this()
        {
            this.ingredientes = ingredientes;
        }

        /// <summary>
        /// Propiedad de lectura y escritura por la cual se accede al dict de ingredientes y se asignan ingredientes a la receta 
        /// </summary>
        public List<Ingrediente> Ingredientes
        {
            get { return this.ingredientes; }
            set
            {
                if (value != null)
                { this.ingredientes = value; }
            }

        }

        /// <summary>
        /// Crea un string con todos los ingredientes de la receta
        /// </summary>
        /// <returns>Retorna un string con los ingredientes de la receta</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Ingrediente i in ingredientes)
            { 
                sb.AppendLine($"{i.stock.ToString()} gramos de {i.ingredienteTipo.ToString()} "); }
            
            return sb.ToString();

        }

        /// <summary>
        /// Calcula los ingredientes para una receta
        /// </summary>
        /// <returns>Devuelve una receta</returns>
        public abstract void CalcularIngredientes();

    }
}
