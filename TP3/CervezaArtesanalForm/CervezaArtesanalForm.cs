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

        public CervezaArtesanalForm()
        {
            InitializeComponent();

            // VER QUE LLEVAR AL LOAD()
            recetas = new Dictionary<string, int>();
            RecetaDAO dao = new RecetaDAO();
            recetas = dao.ConsultarRecetas();
            comboTipos.DataSource = recetas.Keys.ToList<string>();
        }

        //private void btCocinar_Click(object sender, EventArgs e)
        //{
        //    ETipoCerveza tipoAux;
        //    float cantidadLitrosAux;


        //    if (float.TryParse(txtCantidadLitros.Text, out cantidadLitrosAux) &&
        //        Enum.TryParse<ETipoCerveza>(comboTipos.SelectedValue.ToString(), out tipoAux))
        //    {
        //        if (FabricaBebidas.Cocinar(tipoAux, cantidadLitrosAux))
        //        { MessageBox.Show("COCINANDO", "Iuju!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        //        else
        //        {
        //            MessageBox.Show("NO HAY FERMENTADORES o STOCK DE INGREDIENTES",
        //            "Error!",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("REVISAR FORMATO AL INGRESAR LOS LITROS A PREPARAR",
        //            "Error!",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning);
        //    }
        //}


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
