using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public static class FabricaBebidas
    {
        //public static float litrosCapacidadOlla;
        public static List<Fermentador> listaFermentadores;
        public static List<CervezaArtesanal> listaIPA;
        public static List<CervezaArtesanal> listaKolsh;
        public static Dictionary<EIngredientes, float> stockIngredientes;

        /// <summary>
        /// Inicializa stock de ingredientes y lista de ollas disponibles
        /// </summary>
        static FabricaBebidas()
        {
            Fermentador olla1 = new Fermentador(new Receta(ETipoCerveza.Kolsh, 2));
            Fermentador olla2 = new Fermentador(new Receta(ETipoCerveza.Kolsh, 2));
            Fermentador olla3 = new Fermentador(new Receta(ETipoCerveza.Kolsh, 2));
            listaFermentadores = new List<Fermentador>();
            listaFermentadores.Add(olla1);
            listaFermentadores.Add(olla2);
            listaFermentadores.Add(olla3);
            stockIngredientes = new Dictionary<EIngredientes, float>();
            stockIngredientes.Add(EIngredientes.Lupulo, 800000);
            stockIngredientes.Add(EIngredientes.Malta, 900000);
            stockIngredientes.Add(EIngredientes.Agua, 1800000);
        }

        /// <summary>
        /// Valida haya suficiente stock de un ingrediente
        /// </summary>
        /// <param name="stockIngredientes"></param>
        /// <param name="ingrediente"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static bool ValidarStockIngrediente(Dictionary<EIngredientes, float> stockIngredientes, EIngredientes ingrediente, float cantidad)
        {
            bool hayStock = false;

            foreach (KeyValuePair<EIngredientes, float> i in stockIngredientes)
            {
                if (ingrediente == EIngredientes.Lupulo && cantidad <= i.Value)
                {
                    hayStock = true;
                    break;
                }
                else if (ingrediente == EIngredientes.Malta && cantidad <= i.Value)
                {
                    hayStock = true;
                    break;
                }
                else if (ingrediente == EIngredientes.Agua)
                { 
                    hayStock = true; 
                    break; }
            }
            return hayStock;
        }

        /// <summary>
        /// Resta al stock los ingredientes usados para la fabrica
        /// </summary>
        /// <param name="ingredientesUsados"></param>
        public static void CalcularIngredientesRestantes(Receta receta)//(Dictionary<EIngredientes, float> receta)
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
        public static bool ValidarStockListaIngredientes(Dictionary<EIngredientes, float> stockIngredientes, Receta receta)
        {
            bool hayStock = true;

            foreach (KeyValuePair<EIngredientes, float> i in receta.ingredientes)
            {
                if (!ValidarStockIngrediente(stockIngredientes, i.Key, i.Value))
                {
                    hayStock = false;
                    break;
                }

            }
            return hayStock;
        }
     
        /// <summary>
        /// Agrega ingredientes a la olla solo si la olla esta libre, si tiene  capacidad y si hay stock de ingredientes
        /// </summary>
        /// <param name="stockIngredientes"></param>
        /// <param name="ingredientesReceta"></param>
        /// <returns></returns>
        public static bool AgregarIngredientes(Dictionary<EIngredientes, float> stockIngredientes, Receta receta)
        {
            bool puedoEmpezarACocinar = false;
            foreach (Fermentador f in listaFermentadores)
            {
                if (f.ValidarCapacidad(receta)
                    && ValidarStockListaIngredientes(stockIngredientes, receta))
                {
                    f.Receta = receta;
                    CalcularIngredientesRestantes(receta);
                    f.ActualizarCapacidad(receta);
                    puedoEmpezarACocinar = true;
                    break;
                }
                //else { puedoEmpezarACocinar = false; }
            }
            return puedoEmpezarACocinar;
        }

        public static bool Cocinar(ETipoCerveza tipo, int litros)
        {
            bool estaCocinando = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/www.txt";
            string pathErrorLog = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/errorsLog.txt";

            try
            {
                Receta receta = new Receta(tipo, litros);
                receta.CalcularIngredientes();

                if (AgregarIngredientes(FabricaBebidas.stockIngredientes, receta))
                {//un ir por cada tipo? o resuelve con generics???
                    if (tipo is ETipoCerveza.IPA)
                    {
                        CervezaIPA cerveza = new CervezaIPA(receta);
                        //Actualizar lista ipa
                        Archivo.GuardarTexto(path, cerveza.ToString());
                    }
                    else if (tipo is ETipoCerveza.Kolsh)
                    {
                        CervezaKolsh cerveza = new CervezaKolsh(receta);
                        //Actualizar lista Kolsh
                        Archivo.GuardarTexto(path, cerveza.ToString());
                    }
                }
                estaCocinando = true;
            }
            catch (RecetaExcepcion ex)
            {
                Archivo.GuardarTexto(pathErrorLog, new Error(ex).ToString());

            }
            return estaCocinando;
        }

        public static void Enfriar(int minutos, int temperatura)
        { }

        public static void Fermentar(int minutos)
        { }

        public static bool ValidarFermentoParaEmbasado(int minutosTranscurridos, int minutosEsperados)
        {
            return true;
        }

        public static void Embasar(int minutos)
        { }

        //static Dictionary<float, EIngredientes> IngresarStock(Dictionary<EIngredientes, float> nuevoStock)
        //{
        //    foreach(KeyValuePair<EIngredientes, float> i in nuevoStock)
        //    {
        //        if(i.Key is EIngredientes.Malta)
        //        {

        //        }
        //        if (i.Key is EIngredientes.Malta)
        //        {

        //        }
        //        if (i.Key is EIngredientes.Malta)
        //        {

        //        }
        //    }
        //    FabricaBebidas.StockIngredientes = nuevoStock;


        //    return nuevoStock;
        //}
    }
}
