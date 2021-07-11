using CervezaArtesanal.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CervezaArtesanal;
using System.Threading;

namespace CervezaArtesanal
{
    public delegate void EmbotelladoraDelegado();
    public class Embotelladora
    {
        public List<Botella> botellasDisponibles;
        public static event EmbotelladoraDelegado EmbotellandoEvento;
        private Thread hiloEmbotellador;
        
        /// <summary>
        /// Instancia hilo secundario y lo inicia.
        /// </summary>
        public void IniciarHilo()
        {
            hiloEmbotellador = new Thread(new ParameterizedThreadStart(EmbotellarCerveza));
            hiloEmbotellador.Name = "Hilo Embotellador";
            hiloEmbotellador.Start(FabricaBebidas.ControlStockCerveza);
        }

        /// <summary>
        /// Constructor sin param. Instancia lista, y le asigna lo que trae la consulta a la base de datos.
        /// </summary>
        public Embotelladora()
        {
            this.botellasDisponibles = new List<Botella>();
            BotellaDAO dao = new BotellaDAO();
            this.botellasDisponibles = dao.ConsultarBotellasDisponibles();
        }

        /// <summary>
        /// Devuelve una lista de botellas disponibles para embotellar luego de hacer la consulta a la base de datos
        /// </summary>
        public List<Botella> BotellasDisponiblesActualizadas
        {
            get 
            {
                BotellaDAO dao = new BotellaDAO();
                return this.botellasDisponibles = dao.ConsultarBotellasDisponibles(); 
            }

        }

        /// <summary>
        /// Toma del control stock recibido por parametro la cerveza que esta disponible para embotellar. Si hay stock, y ademas hay stock de botellas, empieza a embotellar.
        /// Se actualiza la disponibilidad de botellas en la base. 
        /// Se actualiza el stock control de cerveza en el xml
        /// </summary>
        /// <param name="controlStockCerveza"></param>
        public void EmbotellarCerveza(object controlStockCerveza)
        {
            List<Cerveza> auxControlStockCerveza = (List<Cerveza>)controlStockCerveza;
            if (ValidarStockCerveza(auxControlStockCerveza) == true)
            {
                float litrosAEmbotellar = auxControlStockCerveza.First().Receta.LitrosAPreparar;
                if (botellasDisponibles != null
                && botellasDisponibles.Count() > 0
                && Botella.CapacidadTotalBotellas(this.botellasDisponibles) > litrosAEmbotellar)
                {
                    Botella.ActualizarBotellasDisponibles(this.botellasDisponibles, litrosAEmbotellar);
                    auxControlStockCerveza.Remove(auxControlStockCerveza.First());
                    Cocina.ActualizarXMLConStockCervezasEnCocina();
                    EmbotellandoEvento?.Invoke();
                }
            }
        }

        /// <summary>
        /// Valida si hay cerveza ya preparada
        /// </summary>
        /// <param name="controlStockCerveza"></param>
        /// <returns></returns>
        public bool ValidarStockCerveza(List<Cerveza> controlStockCerveza)
        {
            bool hayStock = false;

            if(controlStockCerveza != null
                && controlStockCerveza.Count() > 0)
            {
                hayStock = true;
            }

            return hayStock;

        }






    }
}
