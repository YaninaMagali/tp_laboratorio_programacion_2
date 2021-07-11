using CervezaArtesanal.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public delegate void CocinarDelegado();
    public class Cocina
    {
        public  List<Ingrediente> stockIngredientes;
        public  List<Fermentador> listaFermentadores;
        public  event CocinarDelegado PuedeEmpezarACocinarEvento;

        public Cocina()
        {
            stockIngredientes = new List<Ingrediente>();
            IngredientesLoad();
            FermentadoresLoad();
            PuedeEmpezarACocinarEvento += ActualizarBaseDatosConNuevoStockIngredientes;
            PuedeEmpezarACocinarEvento += ActualizarXMLConStockCervezasEnCocina;
        }

        public void FermentadoresLoad()
        {
            listaFermentadores = new List<Fermentador>();
            listaFermentadores.Add(new Fermentador(ETipoCerveza.Kolsh));
            listaFermentadores.Add(new Fermentador(ETipoCerveza.IPA, 30));
            listaFermentadores.Add(new Fermentador(ETipoCerveza.Kolsh));
        }
        public void IngredientesLoad() 
        {
            IngredienteDAO ingredientesDAO = new IngredienteDAO();
            stockIngredientes = ingredientesDAO.ConsultarStockIngredientes();
        }

        /// <summary>
        /// Propiedad de solo lectura. Devuelve una lista de ingredientes
        /// </summary>
        public List<Ingrediente> StockIngredientes
        {
            get { return this.stockIngredientes; }
        }

        /// <summary>
        /// Valida haya suficiente stock de un ingrediente
        /// </summary>
        /// <param name="ingrediente"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public bool ValidarStockIngrediente(int idIngrediente, float cantidad)
        {
            bool hayStock = false;

            foreach (Ingrediente i in this.StockIngredientes)
            {
                if (idIngrediente == i.idIngrediente && cantidad <= i.stock)
                {
                    hayStock = true;
                    break;
                }
            }
            return hayStock;
        }

        /// <summary>
        /// Valida haya suficiente stock de una lista ingredientes
        /// </summary>
        /// <param name="stockIngredientes"></param>
        /// <param name="receta"></param>
        /// <returns></returns>
        public bool ValidarStockListaIngredientes(RecetaCerveza receta)
        {
            bool hayStock = true;

            foreach (Ingrediente i in receta.ingredientes)
            {
                if (!this.ValidarStockIngrediente(i.idIngrediente, i.stock))
                {
                    hayStock = false;
                    break;
                }
            }
            return hayStock;
        }

        /// <summary>
        /// Empieza a cocinar la cerveza siempre que haya stock de ingredientes necesarios
        /// Si falla se guarda el error en un archivo de log
        /// Si puede empezar a cocinar se suma la cerveza al stock actual y se restan delstock de ingredientes los utilizados
        /// </summary>
        /// <param name="idTipoCerveza"></param>
        /// <param name="tipo"></param>
        /// <param name="litros"></param>
        /// <returns>Devuelve true si puede empezar a cocinar la cerveza, false caso contrario</returns>
        public bool Cocinar(int idTipoCerveza, string tipoReceta, float litros)
        {
            bool estaCocinando = false;
            ETipoCerveza tipoCervezaAux;
            Cerveza cerveza;
            RecetaCerveza receta = null;
            Fermentador fermentadorDisponible = null;


            try
            {
                if (Enum.TryParse<ETipoCerveza>(tipoReceta, out tipoCervezaAux))
                {
                    receta = new RecetaCerveza(idTipoCerveza, tipoCervezaAux, litros);
                    receta.CalcularIngredientes();
                    fermentadorDisponible = BuscarFermentadorDisponible(receta);
                }

                if (receta != null
                    && fermentadorDisponible != null
                    && this.ValidarStockListaIngredientes(receta)
                    )
                {
                    if (tipoCervezaAux is ETipoCerveza.IPA)
                    {
                        cerveza = new CervezaIPA(receta);
                        FabricaBebidas.controlStockCerveza.Add(cerveza);

                    }
                    else if (tipoCervezaAux is ETipoCerveza.Kolsh)
                    {
                        cerveza = new CervezaKolsh(receta);
                        FabricaBebidas.controlStockCerveza.Add(cerveza);
                    }

                    CalcularStockRestanteIngredientes(receta);
                    fermentadorDisponible.CapacidadLitros = receta.LitrosAPreparar;

                    PuedeEmpezarACocinarEvento?.Invoke();
                    estaCocinando = true;

                }
            }
            catch (LitrosAPrepararExcepcion ex)
            {
                Error err = new Error(ex);
                err.LoguearError();
            }
            catch (NullReferenceException ex)
            {
                Error err = new Error(ex);
                err.LoguearError();
            }
            return estaCocinando;
        }

        /// <summary>
        /// Busca un fermentador disponible teniendo en cuenta el tipo de cerveza que se va a guardar y la capacidad de almacenamiento
        /// </summary>
        /// <param name="receta"></param>
        /// <returns>Devuelve un fermentador si cumple con las condiciones, sino null</returns>
        public Fermentador BuscarFermentadorDisponible(RecetaCerveza receta)
        {
            Fermentador fermentadorDisponible = null;

            foreach (Fermentador fermentador in listaFermentadores)
            {
                if (fermentador.tipoCerveza == receta.tipoCerveza &&
                    fermentador.CapacidadLitros >= receta.LitrosAPreparar)
                {
                    fermentadorDisponible = fermentador;

                    break;
                }
            }
            return fermentadorDisponible;
        }

        /// <summary>
        /// Actualiza el stock de ingredientes 
        /// </summary>
        /// <param name="receta">receta que contiene litros a preparar, ingredientes y sus cantidades necesarias</param>
        public void CalcularStockRestanteIngredientes(RecetaCerveza receta)
        {
            foreach (Ingrediente ingredienteARestarStock in receta.ingredientes)
            {
                ingredienteARestarStock.RestarStock(ingredienteARestarStock, this.StockIngredientes);
            }
        }


        /// <summary>
        /// Actualiza la base con el nuevo stock de ingredientes
        /// </summary>
        public void ActualizarBaseDatosConNuevoStockIngredientes()
        {
            IngredienteDAO i = new IngredienteDAO();
            i.ActualizarStockIngredientes(this.stockIngredientes);
        }


        /// <summary>
        /// Modifica el XML con datos actualizados
        /// </summary>
        public static void ActualizarXMLConStockCervezasEnCocina()
        {
            FabricaBebidas.xmlStockCerveza.Guardar(FabricaBebidas.pathControlStockCerveza, FabricaBebidas.controlStockCerveza);
        }




    }
}
