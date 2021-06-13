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
    public partial class CervezaArtesanalForm : Form
    {
        public CervezaArtesanalForm()
        {
            InitializeComponent();
            comboTipos.DataSource = Enum.GetValues(typeof(ETipoCerveza));
        }

        private void btCocinar_Click(object sender, EventArgs e)
        {
            ETipoCerveza tipoAux;
            float cantidadLitrosAux;
            

            if(float.TryParse(txtCantidadLitros.Text, out cantidadLitrosAux) &&
                Enum.TryParse<ETipoCerveza>(comboTipos.SelectedValue.ToString(), out tipoAux))
            {
                if(FabricaBebidas.Cocinar(tipoAux, cantidadLitrosAux))
                { MessageBox.Show("COCINANDO", "Iuju!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                { MessageBox.Show("NO HAY FERMENTADORES o STOCK DE INGREDIENTES", 
                    "Error!",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error); }
            }
            else 
            {
                MessageBox.Show("REVISAR FORMATO AL INGRESAR LOS LITROS A PREPARAR",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }  
        }

        private void CervezaArtesanalForm_Load(object sender, EventArgs e)
        {

        }

        private void CervezaArtesanalForm_(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro que desea salir?", "SALIR ",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
