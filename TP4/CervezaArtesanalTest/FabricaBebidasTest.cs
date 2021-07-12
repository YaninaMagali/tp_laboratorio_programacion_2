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
        [DataRow(1)]
        public void TestValidarStockIngredienteTrue(int idIngrediente)
        {
            float stockLupulo = FabricaBebidas.Cocina.StockIngredientes[0].Stock;
            Assert.IsTrue(FabricaBebidas.Cocina.ValidarStockIngrediente(idIngrediente, stockLupulo));
            Assert.IsTrue(FabricaBebidas.Cocina.ValidarStockIngrediente(idIngrediente, stockLupulo-1));
        }

        [TestMethod]
        [DataRow(1)]
        public void TestValidarStockIngredienteFalse(int idIngrediente)
        {
            Cocina cocina = new Cocina();
            float i = cocina.StockIngredientes[0].Stock;
            Assert.IsFalse(cocina.ValidarStockIngrediente(idIngrediente, i + 1));
        }

        //[TestMethod]
        //[DataRow(1)]
        //[DataRow(2)]
        //public void TestCalcularStockIngredienteRestante(int cantidadARestar)
        //{
        //    Ingrediente ingredienteARestar = new Ingrediente(1, EIngredientes.Lupulo, cantidadARestar);
        //    float stockLupulo = FabricaBebidas.StockIngredientes[0].Stock;
        //    float auxStockLupulo = stockLupulo - cantidadARestar;

        //    FabricaBebidas.(ingredienteARestar);

        //    Assert.AreEqual(auxStockLupulo, FabricaBebidas.StockIngredientes[0].Stock);

        //}
    }
}

