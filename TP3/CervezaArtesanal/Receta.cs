using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class Receta : IRecetaCerveza
    {
        public ETipoCerveza tipoCerveza;
        public int litrosAPreparar;
        public Dictionary<EIngredientes, float> ingredientes;

        public Receta(ETipoCerveza tipoCerveza, int litrosAPreparar)
        {
            this.tipoCerveza = tipoCerveza;
            //this.litrosAPreparar = litrosAPreparar;
            this.LitrosAPreparar = litrosAPreparar;
            this.ingredientes = new Dictionary<EIngredientes, float>();
        }

        /// <summary>
        /// Propiedad por la cual se asignan litros para calcular la receta solo si es valor recibido es mayor a 0
        /// </summary>
        public int LitrosAPreparar
        {
            get 
            { 
                return this.litrosAPreparar; 
            }
            set 
            {
                if (value > 0)
                { this.litrosAPreparar = value; }
                else
                { throw new RecetaExcepcion("Para calcular una receta los litros ingresados deben ser mayor a cero"); }
            }
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
        /// Calcula los ingredientes necesarios de acuerdo al tipo de cerveza y la cantidad de litros a preparar
        /// </summary>
        /// <returns></returns>
        public Receta CalcularIngredientes()
        {

            if (this.tipoCerveza is ETipoCerveza.IPA)
            {
                this.ingredientes.Add(EIngredientes.Lupulo, 500 * this.litrosAPreparar);
                this.ingredientes.Add(EIngredientes.Malta, 500 * this.litrosAPreparar);
                this.ingredientes.Add(EIngredientes.Agua, 1000 * this.litrosAPreparar);
            }
            if (this.tipoCerveza is ETipoCerveza.Kolsh)
            {
                this.ingredientes.Add(EIngredientes.Lupulo, 300 * litrosAPreparar);
                this.ingredientes.Add(EIngredientes.Malta, 50 * litrosAPreparar);
                this.ingredientes.Add(EIngredientes.Agua, 1000 * litrosAPreparar);
            }
            return this;
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
    }
}
