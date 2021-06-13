﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class RecetaCerveza : Receta
    {
        public float litrosAPreparar;
        public ETipoCerveza tipoCerveza;

        /// <summary>
        /// Constructor con parametros. Asigna valores recibidos por parametro a los atributos de la clase. Invoca tambien al constructor de la clase base
        /// </summary>
        /// <param name="tipoCerveza">enum de tipo de cerveza a preparar</param>
        /// <param name="litrosAPreparar">cantidad de litros a preparar</param>
        public RecetaCerveza(ETipoCerveza tipoCerveza, float litrosAPreparar) : base ()
        {
            LitrosAPreparar = litrosAPreparar;
            this.tipoCerveza = tipoCerveza;
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
                { throw new RecetaExcepcion("Para calcular una receta los litros ingresados deben ser mayor a cero"); }
            }
        }

        /// <summary>
        /// Calcula los ingredientes necesarios de acuerdo al tipo de cerveza y la cantidad de litros a preparar
        /// </summary>
        /// <returns>Devuelve una receta de cerveza</returns>
        public override Receta CalcularIngredientes()
        {

            if (this.tipoCerveza is ETipoCerveza.IPA)
            {
                this.ingredientes.Add(EIngredientes.Lupulo, 300 * this.litrosAPreparar);
                this.ingredientes.Add(EIngredientes.Malta, 250 * this.litrosAPreparar);
                this.ingredientes.Add(EIngredientes.Agua, 1000 * this.litrosAPreparar);
            }
            if (this.tipoCerveza is ETipoCerveza.Kolsh)
            {
                this.ingredientes.Add(EIngredientes.Lupulo, 200 * litrosAPreparar);
                this.ingredientes.Add(EIngredientes.Malta, 200 * litrosAPreparar);
                this.ingredientes.Add(EIngredientes.Agua, 1000 * litrosAPreparar);
            }
            return this;
        }
    }
}
