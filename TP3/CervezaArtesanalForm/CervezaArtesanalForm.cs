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
using CervezaArtesanal.DAO;

namespace CervezaArtesanalForm
{
    public partial class CervezaArtesanalForm : Form
    {
        Dictionary<string, int> recetas;
        EmbotelladoraForm embotelladoraFrm;

        public CervezaArtesanalForm()
        {
            InitializeComponent();

            // VER QUE LLEVAR AL LOAD()
            recetas = new Dictionary<string, int>();
            RecetaDAO dao = new RecetaDAO();
            recetas = dao.ConsultarRecetas();
            comboTipos.DataSource = recetas.Keys.ToList<string>();

            FabricaBebidas.PuedeEmpezarACocinarEvento += FabricaBebidas_PuedeEmpezarACocinarEvento;
        }

        private void btCocinar_Click(object sender, EventArgs e)
        {
            float cantidadLitrosAux;
            int idReceta;

            if (float.TryParse(txtCantidadLitros.Text, out cantidadLitrosAux
                )
                && cantidadLitrosAux > 0
                && recetas.TryGetValue(comboTipos.SelectedValue.ToString(), out idReceta))
            {
                if (FabricaBebidas.Cocinar(idReceta, comboTipos.SelectedValue.ToString(), cantidadLitrosAux))
                { MessageBox.Show("COCINANDO", "Iuju!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    MessageBox.Show("NO HAY FERMENTADORES o STOCK DE INGREDIENTES",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("REVISAR FORMATO AL INGRESAR LOS LITROS A PREPARAR",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void FabricaBebidas_PuedeEmpezarACocinarEvento()
        {
            CargarListaStock();
        }

        private void CervezaArtesanalForm_Load(object sender, EventArgs e)
        {
            CargarListaStock();
        }

        private void CargarListaStock()
        {
            FabricaBebidas.StockIngredientes.ToString();
            txtboxStockIngredientes.Text = "";

            foreach (Ingrediente item in FabricaBebidas.StockIngredientes)
            {
                txtboxStockIngredientes.Text += item.ToString() + " \n";
            }

        }

        private void CervezaArtesanalForm_Closing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro que desea salir?", "SALIR ",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnEmbotelladora_Click(object sender, EventArgs e)
        {
            embotelladoraFrm = new EmbotelladoraForm(FabricaBebidas.ControlStockCerveza);
            embotelladoraFrm.Show();
        }
    }
}
