using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public static class FabricaBebidas
    {
        public static List<Fermentador> listaFermentadores;
        public static List<Cerveza> controlStockCerveza;
        public static Dictionary<EIngredientes, float> stockIngredientes;

        /// <summary>
        /// Instancio las listas y el diccionario
        /// Carga stock de ingredientes
        /// Agrega fermentadores
        /// </summary>
        /// 
        static FabricaBebidas()
        {
            controlStockCerveza = new List<Cerveza>();
            listaFermentadores = new List<Fermentador>();
            stockIngredientes = new Dictionary<EIngredientes, float>();
        
            listaFermentadores.Add(new Fermentador(ETipoCerveza.Kolsh));
            listaFermentadores.Add(new Fermentador(ETipoCerveza.IPA, 30));
            listaFermentadores.Add(new Fermentador(ETipoCerveza.Kolsh));

            stockIngredientes.Add(EIngredientes.Lupulo, 60000);///1000
            stockIngredientes.Add(EIngredientes.Malta, 60000);///2000
            stockIngredientes.Add(EIngredientes.Agua, 180000000);
        }

        /// <summary>
        /// Propiedad de solo lectura. Devuelve una lista de cervezas en stock
        /// </summary>
        public static List<Cerveza> ControlStockCerveza
        {
            get { return FabricaBebidas.controlStockCerveza; }
        }

        /// <summary>
        /// Propiedad de solo lectura. Devuelve un diccionario cuyo par clave valor representa ingrediente y su cantidad en stock
        /// </summary>
        public static Dictionary<EIngredientes, float> StockIngredientes
        {
            get { return FabricaBebidas.stockIngredientes; }
            //set { myVar = value; }
        }

        /// <summary>
        /// Valida haya suficiente stock de un ingrediente
        /// </summary>
        /// <param name="ingrediente"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static bool ValidarStockIngrediente(EIngredientes ingrediente, float cantidad)
        {
            bool hayStock = false;

            if (ingrediente == EIngredientes.Lupulo && FabricaBebidas.stockIngredientes[EIngredientes.Lupulo] >= cantidad)
            {
                hayStock = true;
            }
            else if (ingrediente == EIngredientes.Malta && FabricaBebidas.stockIngredientes[EIngredientes.Lupulo] >= cantidad)
            {
                hayStock = true;
            }
            else if (ingrediente == EIngredientes.Agua)
            {
                hayStock = true;

            }
            return hayStock;
        }

        /// <summary>
        /// Resta al stock los ingredientes usados para la fabrica
        /// </summary>
        /// <param name="receta">receta que contiene litros a preparar, ingredientes y sus cantidades</param>
        public static void CalcularIngredientesRestantes(RecetaCerveza receta)
        {
            foreach (KeyValuePair<EIngredientes, float> i in receta.ingredientes)
            {
                if (i.Key == EIngredientes.Lupulo)
                {

                    FabricaBebidas.stockIngredientes[EIngredientes.Lupulo] = stockIngredientes[EIngredientes.Lupulo] - i.Value;
                }
                else if (i.Key == EIngredientes.Malta)
                {
                    FabricaBebidas.stockIngredientes[EIngredientes.Malta] = stockIngredientes[EIngredientes.Malta] - i.Value;
                }
                else if (i.Key == EIngredientes.Agua)
                {
                    FabricaBebidas.stockIngredientes[EIngredientes.Agua] = stockIngredientes[EIngredientes.Agua] - i.Value;
                }
            }
        }

        /// <summary>
        /// Valida haya suficiente stock de una lista ingredientes
        /// </summary>
        /// <param name="stockIngredientes"></param>
        /// <param name="receta"></param>
        /// <returns></returns>
        public static bool ValidarStockListaIngredientes(Dictionary<EIngredientes, float> stockIngredientes, RecetaCerveza receta)
        {
            bool hayStock = true;

            foreach (KeyValuePair<EIngredientes, float> i in receta.ingredientes)
            {
                if (!ValidarStockIngrediente(i.Key, i.Value))
                {
                    hayStock = false;
                    break;
                }
            }
            return hayStock;
        }
         
        /// <summary>
        /// Busca un fermentador disponible teniendo en cuenta el tipo de cerveza que se va a guardar y la capacidad de almacenamiento
        /// </summary>
        /// <param name="receta"></param>
        /// <returns>Devuelve un fermentador si cumple con las condiciones, sino null</returns>
        public static Fermentador BuscarFermentadorDisponible(RecetaCerveza receta)
        {
            Fermentador fermentadorDisponible = null;

            foreach (Fermentador fermentador in listaFermentadores)
            {
                if(fermentador .tipoCerveza == receta.tipoCerveza && 
                    fermentador.CapacidadLitros >= receta.litrosAPreparar)
                {
                    fermentadorDisponible = fermentador;

                    break;
                }
            }
            return fermentadorDisponible;
        }

        /// <summary>
        /// Empieza a cocinar la cerveza siempre que haya stock de ingrdientes necesarios
        /// Si falla se guarda el error en un archivo de log
        /// Si puede empezar a cocinar se suma la cerveza al stock actual y se restan delstock de ingredientes los utilizados
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="litros"></param>
        /// <returns>Devuelve true si puede empezar a cocinar la cerveza, false caso contrario</returns>
        public static bool Cocinar(ETipoCerveza tipo, float litros)
        {
            bool estaCocinando = false;
            Texto<string> archivoLog = new Texto<string>();
            XML<List<Cerveza>> xmlStockCerveza= new XML<List<Cerveza>>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/controlStockCerveza.xml";
            string pathErrorLog = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/errorsLog.txt";

            try
            {
                RecetaCerveza receta = new RecetaCerveza(tipo, litros);
                receta.CalcularIngredientes();
                Cerveza cerveza;
                Fermentador fermentador = BuscarFermentadorDisponible(receta);

                if(ValidarStockListaIngredientes(FabricaBebidas.stockIngredientes, receta) &&
                    fermentador != null)
                {
                    if (tipo is ETipoCerveza.IPA)
                    {
                        cerveza = new CervezaIPA(receta);
                        controlStockCerveza.Add(cerveza);
                    }
                    else if (tipo is ETipoCerveza.Kolsh)
                    {
                        cerveza = new CervezaKolsh(receta);
                        controlStockCerveza.Add(cerveza);
                    }
                    CalcularIngredientesRestantes(receta);
                    fermentador.CapacidadLitros = receta.LitrosAPreparar;
                    estaCocinando = true;
                    xmlStockCerveza.Guardar(path, FabricaBebidas.controlStockCerveza);
                }
             }
            catch (LitrosAPrepararExcepcion ex)
            {
                archivoLog.Guardar(pathErrorLog, new Error(ex).ToString());
            }
            catch (NullReferenceException ex)
            {
                archivoLog.Guardar(pathErrorLog, new Error(ex).ToString());
            }
            return estaCocinando;
        }   


        
        
    



    }
}
