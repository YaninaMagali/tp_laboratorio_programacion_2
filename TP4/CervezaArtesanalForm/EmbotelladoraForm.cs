using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CervezaArtesanal;

namespace CervezaArtesanalForm
{
    public partial class EmbotelladoraForm : Form
    {
        List<Cerveza> controlStockCerveza;

        public EmbotelladoraForm(List<Cerveza> controlStockCerveza)
        {
            InitializeComponent();
            this.controlStockCerveza = controlStockCerveza;
            Embotelladora.EmbotellandoEvento += Embotelladora_EmbotellandoEvento;
            Embotelladora.EmbotellandoEvento += Embotelladora_MostrarMensajeExito; ;
            FabricaBebidas.Cocina.PuedeEmpezarACocinarEvento += Embotelladora_EmbotellandoEvento;
            Embotelladora.FinEmbotelladoEvento += InformarFinEmbotellado;
            Embotelladora.NoHayBotellasDisponiblesEvento += InformarNoHayBotellasDisponiblesEvento;
            Embotelladora.NoHayCervezaParaEmbotelladoEvento += InformarNoHayCervezaParaEmbotelladoEvento;
        }

        private void InformarNoHayCervezaParaEmbotelladoEvento()
        {
            MessageBox.Show("No hay cerveza lista para envasar");
        }

        private void InformarNoHayBotellasDisponiblesEvento()
        {
            MessageBox.Show("No hay botellas disponibles para iniciar en envasado o la capacidad no es suficiente");
        }

        private void InformarFinEmbotellado()
        {
            MessageBox.Show("Fin envasado");
        }

        private void Embotelladora_MostrarMensajeExito()
        {
            MessageBox.Show("Envasado iniciado");
        }

        /// <summary>
        /// Se invoca al momemento en que se dispara el EmbotellandoEvento, a fin de actualizar los datos del form
        /// </summary>
        private void Embotelladora_EmbotellandoEvento()
        {
            if (this.InvokeRequired)
            {
                EmbotelladoraDelegado d = new EmbotelladoraDelegado(this.Embotelladora_EmbotellandoEvento);
                this.Invoke(d);
            }
            else 
            {
                txtBoxStockCerveza.Text = "";
                lblCapacidadTotalBotellas.Text = "";
                StockCervezaLoad(controlStockCerveza);
                lblCapacidadTotalBotellas.Text = Botella.CapacidadTotalBotellas(FabricaBebidas.Embotelladora.BotellasDisponiblesActualizadas).ToString();
            }
                
        }

        private void txtBoxStockCerveza_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Muestra el stock de cervezas para embotellar en el form
        /// </summary>
        /// <param name="controlStockCerveza"></param>
        public void StockCervezaLoad(List<Cerveza> controlStockCerveza)
        {
            foreach (Cerveza item in FabricaBebidas.ControlStockCerveza)
            {
                txtBoxStockCerveza.Text += "Tipo: " + item.TipoCerveza.ToString() + " \n";
                txtBoxStockCerveza.Text += "Litros: " + item.Receta.LitrosAPreparar.ToString() + " \n";
                txtBoxStockCerveza.Text += "--------------------------------" + " \n";
            }
        }

        /// <summary>
        /// Invoca el metodo que inicia el hilo secundario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciarEmbotellado_Click(object sender, EventArgs e)
        {
            FabricaBebidas.Embotelladora.IniciarHilo();
        }

        /// <summary>
        /// Al cargar el form se invoca el metodo que carga stock de cerveza a embotellar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmbotelladoraLoad(object sender, EventArgs e)
        {
            StockCervezaLoad(controlStockCerveza);
            lblCapacidadTotalBotellas.Text =  Botella.CapacidadTotalBotellas(FabricaBebidas.Embotelladora.botellasDisponibles).ToString();

        }

        private void EmbotellarFormClosing(object sender, FormClosingEventArgs e)
        {
           FabricaBebidas.Embotelladora.AbortarHilo();
        }
    }
}
