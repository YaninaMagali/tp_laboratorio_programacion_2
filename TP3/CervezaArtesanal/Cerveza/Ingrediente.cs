using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class Ingrediente
    {
        public int idIngrediente;
        public EIngredientes ingredienteTipo;
        public float stock;

        public Ingrediente() { }
        public Ingrediente(int idIngrediente, EIngredientes ingrediente, float stock)
        {
            this.idIngrediente = idIngrediente;
            this.ingredienteTipo = ingrediente;
            this.stock = stock;
        }




    }

    
}
