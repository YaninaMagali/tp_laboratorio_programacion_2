using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CervezaArtesanal;
using System.Collections.Generic;

namespace CervezaArtesanalTest
{
    [TestClass]
    public class RecetaTest
    {
        [TestMethod]
        [DataRow(1, ETipoCerveza.IPA, 2)]
        public void TestCrearRecetaOk(ETipoCerveza tipoCerveza, int idTipoCerveza, int litrosAPrepa)
        {
            Assert.IsNotNull(new RecetaCerveza(idTipoCerveza, tipoCerveza, litrosAPrepa));
        }

        [TestMethod]
        [DataRow(1, ETipoCerveza.IPA, -1)]
        [DataRow(1, ETipoCerveza.IPA, 0)]
        [ExpectedException(typeof(LitrosAPrepararExcepcion))]
        public void TestCrearRecetaLitrosMenorA1(int idTipoCerveza, ETipoCerveza tipoCerveza, int litrosAPrepa)
        {
            new RecetaCerveza(idTipoCerveza, tipoCerveza, litrosAPrepa);
        }

        [TestMethod]
        [DataRow(1, ETipoCerveza.IPA, 2)]
        public void TestCalcularIngredientesIPA(int idTipoCerveza, ETipoCerveza tipo, int cantidad)
        {
            Receta receta = new RecetaCerveza(idTipoCerveza, tipo, cantidad);
            receta.CalcularIngredientes();
            Assert.AreEqual(500, receta.Ingredientes[0].Stock);
            Assert.AreEqual(338, receta.Ingredientes[1].Stock);
            Assert.AreEqual(2000, receta.Ingredientes[2].Stock);
        }

    }
}
