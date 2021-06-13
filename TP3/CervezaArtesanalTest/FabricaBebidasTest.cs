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
        [DataRow(2000, EIngredientes.Malta)]
        [DataRow(9999, EIngredientes.Lupulo)]
        [DataRow(10000, EIngredientes.Lupulo)]
        public void TestValidarStockIngredienteTrue(int cantidad, EIngredientes ingrediente)
        {
            Dictionary<EIngredientes, float> stock = new Dictionary<EIngredientes, float>();
            stock.Add(EIngredientes.Lupulo, 5);
            stock.Add(EIngredientes.Malta, 1);
            Assert.IsTrue(FabricaBebidas.ValidarStockIngrediente(ingrediente, cantidad));
        }

        [TestMethod]
        [DataRow(20001, EIngredientes.Malta)]
        [DataRow(10001, EIngredientes.Lupulo)]
        public void TestValidarStockIngredienteFalse(int cantidad, EIngredientes ingrediente)
        {
            Assert.IsFalse(FabricaBebidas.ValidarStockIngrediente(ingrediente, cantidad));
        }

        [TestMethod]
        public void TestCalcularStockRestante()
        {
            float auxLupulo = 0;
            float auxMalta = 0;
            float auxAgua = 0;

            RecetaCerveza auxReceta = new RecetaCerveza(ETipoCerveza.IPA, 1);
            auxReceta.CalcularIngredientes();

            auxLupulo = FabricaBebidas.stockIngredientes[EIngredientes.Lupulo] - auxReceta.ingredientes[EIngredientes.Lupulo];
            auxMalta = FabricaBebidas.stockIngredientes[EIngredientes.Malta] - auxReceta.ingredientes[EIngredientes.Malta];
            auxAgua = FabricaBebidas.stockIngredientes[EIngredientes.Agua] - auxReceta.ingredientes[EIngredientes.Agua];
            
            FabricaBebidas.CalcularIngredientesRestantes(auxReceta);

            Assert.AreEqual(auxLupulo, FabricaBebidas.StockIngredientes[EIngredientes.Lupulo]);
            Assert.AreEqual(auxMalta, FabricaBebidas.StockIngredientes[EIngredientes.Malta]);
            Assert.AreEqual(auxAgua, FabricaBebidas.StockIngredientes[EIngredientes.Agua]);

        }
    }
}

