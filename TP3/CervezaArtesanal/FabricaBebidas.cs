using CervezaArtesanal.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public static class FabricaBebidas
    {
        public static List<Cerveza> controlStockCerveza;
        public static XML<List<Cerveza>> xmlStockCerveza;
        public static string pathControlStockCerveza;

        private static Embotelladora embotelladora;
        private static Cocina cocina;


        /// <summary>
        /// Instancio objetos
        /// Setteo path a donde buscar xml
        /// </summary>
        /// 
        static FabricaBebidas()
        {
            xmlStockCerveza = new XML<List<Cerveza>>();
            pathControlStockCerveza = AppDomain.CurrentDomain.BaseDirectory + "controlStockCerveza.xml";
            CargarControlStockCerveza(pathControlStockCerveza);

            cocina = new Cocina();
            embotelladora = new Embotelladora();
            
        }

        /// <summary>
        /// Propiedad de solo lectura. Devuelve una lista de cervezas en stock
        /// </summary>
        public static List<Cerveza> ControlStockCerveza
        {
            get { return FabricaBebidas.controlStockCerveza; }
        }

        /// <summary>
        /// Propiedad de solo lectura. Devuelve una cocina
        /// </summary>
        public static Cocina Cocina
        {
            get { return FabricaBebidas.cocina; }
        }

        /// <summary>
        /// Propiedad de solo lectura. Devuelve una Embotelladora
        /// </summary>
        public static Embotelladora Embotelladora
        {
            get { return FabricaBebidas.embotelladora; }
        }

        /// <summary>
        /// Levanta de un xml el stock de la cerveza ya lista para embotellar
        /// </summary>
        /// <param name="pathControlStockCerveza"></param>
        public static void CargarControlStockCerveza(string pathControlStockCerveza)
        {
            controlStockCerveza = new List<Cerveza>();
            controlStockCerveza = xmlStockCerveza.Leer(pathControlStockCerveza);
        }
    }
}
