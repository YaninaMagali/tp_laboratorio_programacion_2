using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CervezaArtesanal;
using System.Collections.Generic;

namespace CervezaArtesanalTest
{
    [TestClass]
    public class FabricaBebidasTest
    {
        [TestMethod]
        [DataRow(1, EIngredientes.Malta)]
        [DataRow(4, EIngredientes.Lupulo)]
        [DataRow(5, EIngredientes.Lupulo)]
        public void TestValidarStockIngredienteTrue(int cantidad, EIngredientes ingrediente)
        {
            Dictionary<EIngredientes, float> stock = new Dictionary<EIngredientes, float>();
            stock.Add(EIngredientes.Lupulo, 5);
            stock.Add(EIngredientes.Malta, 1);
            Assert.IsTrue(FabricaBebidas.ValidarStockIngrediente(stock, ingrediente, cantidad));
        }

        [TestMethod]
        [DataRow(2, EIngredientes.Malta)]
        [DataRow(6, EIngredientes.Lupulo)]
        public void TestValidarStockIngredienteFalse(int cantidad, EIngredientes ingrediente)
        {
            Dictionary<EIngredientes, float> stock = new Dictionary<EIngredientes, float>();
            stock.Add(EIngredientes.Lupulo, 5);
            stock.Add(EIngredientes.Malta, 1);
            Assert.IsFalse(FabricaBebidas.ValidarStockIngrediente(stock, ingrediente, cantidad));
        }
        
        [TestMethod]
        public void TestCalcularIngredientesRestantes()
        {
            Dictionary<EIngredientes, float> stock = new Dictionary<EIngredientes, float>();
            stock.Add(EIngredientes.Lupulo, 5);
            stock.Add(EIngredientes.Malta, 1);

            Receta receta = new Receta(ETipoCerveza.IPA, 1);
            receta.Ingredientes = new Dictionary<EIngredientes, float>();
            receta.Ingredientes.Add(EIngredientes.Lupulo, 4);
            receta.Ingredientes.Add(EIngredientes.Malta, 1);

            FabricaBebidas.CalcularIngredientesRestantes(receta);

            Assert.AreEqual(1, stock[EIngredientes.Lupulo]);
            Assert.AreEqual(0, stock[EIngredientes.Malta]);
        }
    }
}

