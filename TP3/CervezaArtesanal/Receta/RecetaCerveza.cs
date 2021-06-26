using CervezaArtesanal.DAO;
using System.Collections.Generic;

namespace CervezaArtesanal
{
    public class RecetaCerveza : Receta
    {
        public int idTipoCerveza;
        public ETipoCerveza tipoCerveza;
        private float litrosAPreparar;

        public RecetaCerveza() : base() { }

        /// <summary>
        /// Constructor con parametros. Asigna valores recibidos por parametro a los atributos de la clase. Invoca tambien al constructor de la clase base
        /// </summary>
        /// <param name="idTipoCerveza">id del tipo de cerveza a preparar</param>
        /// <param name="tipoCerveza">enum de tipo de cerveza a preparar</param>
        /// <param name="litrosAPreparar">cantidad de litros a preparar</param>
        public RecetaCerveza(int idTipoCerveza, ETipoCerveza tipoCerveza, float litrosAPreparar) : base()
        {
            LitrosAPreparar = litrosAPreparar;
            this.tipoCerveza = tipoCerveza;
            this.idTipoCerveza = idTipoCerveza;
        }

        /// <summary>
        /// Propiedad por de lectura y escritura. Se asignan litros para calcular la receta solo si es valor recibido es mayor a 0
        /// </summary>
        public float LitrosAPreparar
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
                { throw new LitrosAPrepararExcepcion("Para calcular una receta los litros ingresados deben ser mayor a cero"); }
            }
        }

         /// <summary>
        /// Calcula los ingredientes necesarios de acuerdo al tipo de cerveza y la cantidad de litros a preparar
        /// </summary>
        /// <returns>Devuelve una receta de cerveza</returns>
        public override void CalcularIngredientes()
        {
            List<Ingrediente> auxIngredientes = new List<Ingrediente>();

            IngredienteDAO dao = new IngredienteDAO();
            auxIngredientes = dao.ConsultarIngredientesPorIdTipoCerveza(this.idTipoCerveza);

            foreach (Ingrediente i in auxIngredientes)
            {
                base.ingredientes.Add(new Ingrediente(i.idIngrediente, i.ingredienteTipo, (i.stock * this.litrosAPreparar)));
            }
        }

    }
}
