using CervezaArtesanal.DAO;
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

        public float Stock
        {
            get { return this.stock; }
            set
            {
                if (value >= 0)
                {
                    this.stock = value;
                }
                else
                {
                    this.stock = 0;
                }
            }    
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.ingredienteTipo.ToString()}: {this.Stock.ToString()} gramos ");
            return sb.ToString();
        }

        public void RestarStock(Ingrediente ingredienteARestarStock, List<Ingrediente> ingredientesActuales)
        {
            foreach (Ingrediente i in ingredientesActuales)
            {
                if (i.idIngrediente == ingredienteARestarStock.idIngrediente)
                {
                    i.Stock = i.Stock - ingredienteARestarStock.Stock;
                    break;
                }
            }
        }


        //public void ActualizarStockBaseDatos(List<Ingrediente> ingredientes)
        //{
        //    IngredienteDAO ingredientesDAO = new IngredienteDAO();
        //    ingredientesDAO.ActualizarStockIngredientes(ingredientes);
        //}


    }

    
}
