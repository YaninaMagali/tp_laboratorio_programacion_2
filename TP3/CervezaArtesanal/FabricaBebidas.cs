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
        public static List<Fermentador> listaFermentadores;
        public static List<Cerveza> controlStockCerveza;
        public static List<Ingrediente> stockIngredientes;

        public static Texto<string> archivoLogErrores;
        public static XML<List<Cerveza>> xmlStockCerveza;
        public static string pathControlStockCerveza;
        public static string pathLogErrores;

        /// <summary>
        /// Instancio objetos
        /// Carga stock de ingredientes de la base de datos
        /// Carga stock de cerveza fabricada desde el xml
        /// Agrega fermentadores
        /// </summary>
        /// 
        static FabricaBebidas()
        {

            archivoLogErrores = new Texto<string>();
            xmlStockCerveza = new XML<List<Cerveza>>();
            pathControlStockCerveza = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/controlStockCerveza.xml";
            pathLogErrores = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/errorsLog.txt";

            controlStockCerveza = new List<Cerveza>();
            controlStockCerveza = xmlStockCerveza.Leer(pathControlStockCerveza);

            stockIngredientes = new List<Ingrediente>();
            IngredienteDAO ingredientesDAO = new IngredienteDAO();
            stockIngredientes = ingredientesDAO.ConsultarStockIngredientes();

            listaFermentadores = new List<Fermentador>();
            listaFermentadores.Add(new Fermentador(ETipoCerveza.Kolsh));
            listaFermentadores.Add(new Fermentador(ETipoCerveza.IPA, 30));
            listaFermentadores.Add(new Fermentador(ETipoCerveza.Kolsh));
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
        public static List<Ingrediente> StockIngredientes
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

            foreach(Ingrediente i in FabricaBebidas.StockIngredientes)
            {
                if(ingrediente == i.ingredienteTipo && cantidad <= i.stock)
                {
                    hayStock = true;
                    break;
                }
            }
            return hayStock;
        }

        /// <summary>
        /// Actualiza el stock de ingredientes 
        /// </summary>
        /// <param name="receta">receta que contiene litros a preparar, ingredientes y sus cantidades necesarias</param>
        public static void CalcularStockRestanteIngredientes(RecetaCerveza receta)
        {
            foreach (Ingrediente ingredienteARestarStock in receta.ingredientes)
            {
                CalcularStockRestantePorIngrediente(ingredienteARestarStock);
            }
        }

        /// <summary>
        /// Resta del stock de un ingrediente la cantidad que se va a usar para cocinar
        /// </summary>
        /// <param name="ingredienteARestarStock"></param>
        public static void CalcularStockRestantePorIngrediente(Ingrediente ingredienteARestarStock)
        {
            foreach (Ingrediente i in FabricaBebidas.stockIngredientes)
            {
                if (i.idIngrediente == ingredienteARestarStock.idIngrediente)
                {
                    i.Stock = i.Stock - ingredienteARestarStock.Stock;
                }
            }
        }

        /// <summary>
        /// Valida haya suficiente stock de una lista ingredientes
        /// </summary>
        /// <param name="stockIngredientes"></param>
        /// <param name="receta"></param>
        /// <returns></returns>
        public static bool ValidarStockListaIngredientes(List<Ingrediente> stockIngredientes, RecetaCerveza receta)
        {
            bool hayStock = true;

            foreach(Ingrediente i in receta.ingredientes)
            {
                if (!ValidarStockIngrediente(i.ingredienteTipo, i.stock))
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
                    fermentador.CapacidadLitros >= receta.LitrosAPreparar)
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
        //public static bool CocinarOld(ETipoCerveza tipo, float litros)
        //{
        //    bool estaCocinando = false;
        //    Texto<string> archivoLog = new Texto<string>();
        //    XML<List<Cerveza>> xmlStockCerveza= new XML<List<Cerveza>>();
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/controlStockCerveza.xml";
        //    string pathErrorLog = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/errorsLog.txt";

        //    try
        //    {
        //        RecetaCerveza receta = new RecetaCerveza(tipo, litros);
        //        receta.CalcularIngredientes();
        //        Cerveza cerveza;
        //        Fermentador fermentador = BuscarFermentadorDisponible(receta);

        //        if(ValidarStockListaIngredientes(FabricaBebidas.stockIngredientes, receta) &&
        //            fermentador != null)
        //        {
        //            if (tipo is ETipoCerveza.IPA)
        //            {
        //                cerveza = new CervezaIPA(receta);
        //                controlStockCerveza.Add(cerveza);
        //            }
        //            else if (tipo is ETipoCerveza.Kolsh)
        //            {
        //                cerveza = new CervezaKolsh(receta);
        //                controlStockCerveza.Add(cerveza);
        //            }
        //            CalcularIngredientesRestantes(receta);
        //            fermentador.CapacidadLitros = receta.LitrosAPreparar;
        //            estaCocinando = true;
        //            xmlStockCerveza.Guardar(path, FabricaBebidas.controlStockCerveza);
        //        }
        //     }
        //    catch (LitrosAPrepararExcepcion ex)
        //    {
        //        archivoLog.Guardar(pathErrorLog, new Error(ex).ToString());
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        archivoLog.Guardar(pathErrorLog, new Error(ex).ToString());
        //    }
        //    return estaCocinando;
        //}


        /// <summary>
        /// Empieza a cocinar la cerveza siempre que haya stock de ingredientes necesarios
        /// Si falla se guarda el error en un archivo de log
        /// Si puede empezar a cocinar se suma la cerveza al stock actual y se restan delstock de ingredientes los utilizados
        /// </summary>
        /// <param name="idTipoCerveza"></param>
        /// <param name="tipo"></param>
        /// <param name="litros"></param>
        /// <returns>Devuelve true si puede empezar a cocinar la cerveza, false caso contrario</returns>
        public static bool Cocinar(int idTipoCerveza, string tipoReceta, float litros)
        {
            
            bool estaCocinando = false;
            ETipoCerveza tipoCervezaAux;

            try
            {
                Enum.TryParse<ETipoCerveza>(tipoReceta, out tipoCervezaAux);
                RecetaCerveza receta = new RecetaCerveza(idTipoCerveza, tipoCervezaAux, litros);
                receta.CalcularIngredientes();
                Cerveza cerveza;
                Fermentador fermentador = BuscarFermentadorDisponible(receta);

                if (fermentador != null && 
                    ValidarStockListaIngredientes(FabricaBebidas.stockIngredientes, receta)
                    )
                {
                    if (tipoCervezaAux is ETipoCerveza.IPA)
                    {
                        cerveza = new CervezaIPA(receta);
                        controlStockCerveza.Add(cerveza);
                    }
                    else if (tipoCervezaAux is ETipoCerveza.Kolsh)
                    {
                        cerveza = new CervezaKolsh(receta);
                        controlStockCerveza.Add(cerveza);
                    }
                    CalcularStockRestanteIngredientes(receta);
                    IngredienteDAO ingredientesDAO = new IngredienteDAO();
                    ingredientesDAO.ActualizarStockIngredientes(FabricaBebidas.stockIngredientes);
                    fermentador.CapacidadLitros = receta.LitrosAPreparar;
                    estaCocinando = true;
                    xmlStockCerveza.Guardar(pathControlStockCerveza, FabricaBebidas.controlStockCerveza);
                }
            }
            catch (LitrosAPrepararExcepcion ex)
            {
                archivoLogErrores.Guardar(pathLogErrores, new Error(ex).ToString());
            }
            catch (NullReferenceException ex)
            {
                archivoLogErrores.Guardar(pathLogErrores, new Error(ex).ToString());
            }
            return estaCocinando;
        }



        }
}
