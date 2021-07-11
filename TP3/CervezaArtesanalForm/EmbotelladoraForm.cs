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
        }

        private void Embotelladora_EmbotellandoEvento()
        {
            //FabricaBebidas.CargarControlStockCerveza();
            txtBoxStockCerveza.Text = "";
            lblCapacidadTotalBotellas.Text = "";
            CargarStockCerveza(controlStockCerveza);
            //lblCapacidadTotalBotellas.Text = Botella.CapacidadTotalBotellas(FabricaBebidas.embotelladora.botellasDisponibles).ToString();
            lblCapacidadTotalBotellas.Text = Botella.CapacidadTotalBotellas(FabricaBebidas.embotelladora.BotellasDisponiblesActualizadas).ToString();
        }

        private void txtBoxStockCerveza_TextChanged(object sender, EventArgs e)
        {

        }

        public void CargarStockCerveza(List<Cerveza> controlStockCerveza)
        {
            foreach (Cerveza item in FabricaBebidas.ControlStockCerveza)
            {
                txtBoxStockCerveza.Text += "Tipo: " + item.TipoCerveza.ToString() + " \n";
                txtBoxStockCerveza.Text += "Litros: " + item.Receta.LitrosAPreparar.ToString() + " \n";
                txtBoxStockCerveza.Text += "--------------------------------" + " \n";
            }
        }

        private void btnIniciarEmbotellado_Click(object sender, EventArgs e)
        {
            FabricaBebidas.embotelladora.EmbotellarCerveza(controlStockCerveza);
        }

        private void EmbotelladoraLoad(object sender, EventArgs e)
        {
            CargarStockCerveza(controlStockCerveza);
            lblCapacidadTotalBotellas.Text =  Botella.CapacidadTotalBotellas(FabricaBebidas.embotelladora.botellasDisponibles).ToString();

        }
    }
}
