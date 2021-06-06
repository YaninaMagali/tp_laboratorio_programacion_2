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
        [DataRow(ETipoCerveza.IPA, 2)]
        public void TestCrearRecetaOk(ETipoCerveza tipoCerveza, int litrosAPrepa)
        {
            Assert.IsNotNull(new Receta(tipoCerveza, litrosAPrepa));
        }

        [TestMethod]
        [DataRow(ETipoCerveza.IPA, -2)]
        [ExpectedException(typeof(Exception))]
        public void TestCrearRecetaLitrosMenorA1(ETipoCerveza tipoCerveza, int litrosAPrepa)
        {
            new Receta(tipoCerveza, litrosAPrepa);
        }

        [TestMethod]
        [DataRow(ETipoCerveza.IPA, 2)]
        public void TestCalcularIngredientesIPA(ETipoCerveza tipo, int cantidad)
        {
            Receta receta = new Receta(tipo, cantidad);
            receta.CalcularIngredientes();
            Assert.AreEqual(1000, receta.Ingredientes[EIngredientes.Lupulo]);
            Assert.AreEqual(1000, receta.Ingredientes[EIngredientes.Malta]);
            Assert.AreEqual(2000, receta.Ingredientes[EIngredientes.Agua]);
        }

        [TestMethod]
        [DataRow(ETipoCerveza.Kolsh, 2)]
        public void TestCalcularIngredientesKolsh(ETipoCerveza tipo, int cantidad)
        {
            Receta receta = new Receta(tipo, cantidad);
            receta.CalcularIngredientes();
            Assert.AreEqual(600, receta.Ingredientes[EIngredientes.Lupulo]);
            Assert.AreEqual(100, receta.Ingredientes[EIngredientes.Malta]);
            Assert.AreEqual(2000, receta.Ingredientes[EIngredientes.Agua]);
        }

    }
}
