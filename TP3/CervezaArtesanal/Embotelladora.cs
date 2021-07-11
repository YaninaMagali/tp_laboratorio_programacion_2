using CervezaArtesanal.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CervezaArtesanal;


namespace CervezaArtesanal
{
    public delegate void EmbotelladoraDelegado();
    public class Embotelladora
    {
        public List<Botella> botellasDisponibles;
        public static event EmbotelladoraDelegado EmbotellandoEvento;

        public Embotelladora()
        {
            this.botellasDisponibles = new List<Botella>();
            BotellaDAO dao = new BotellaDAO();
            this.botellasDisponibles = dao.ConsultarBotellasDisponibles();
        }

        public List<Botella> BotellasDisponiblesActualizadas
        {
            get 
            {
                BotellaDAO dao = new BotellaDAO();
                return this.botellasDisponibles = dao.ConsultarBotellasDisponibles(); 
            }

        }

        public List<Cerveza> EmbotellarCerveza(List<Cerveza> controlStockCerveza)
        {
            if(ValidarStockCerveza(controlStockCerveza) == true)
            {
                float litrosAEmbotellar = controlStockCerveza.First().Receta.LitrosAPreparar;
                if (botellasDisponibles != null
                && botellasDisponibles.Count() > 0
                && Botella.CapacidadTotalBotellas(this.botellasDisponibles) > litrosAEmbotellar)
                {
                    Botella.ActualizarBotellasDisponibles(this.botellasDisponibles, litrosAEmbotellar);
                    controlStockCerveza.Remove(controlStockCerveza.First());
                    FabricaBebidas.ActualizarXMLConStockCervezasEnCocina();
                    EmbotellandoEvento?.Invoke();
                }
            }
            return controlStockCerveza;
        }

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
