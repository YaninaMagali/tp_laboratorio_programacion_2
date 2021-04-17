using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form

    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de la calculadora?", "SALIR ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            //string numero1IngresadoStr = this.txtN1.Text;
            //string numero2IngresadoStr = this.txtN2.Text;
            lblResultado.Text = Operar(txtN1.Text, txtN2.Text, comboOperadores.Text).ToString(); 

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Entidades.Numero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            lblResultado.Text = Entidades.Numero.BinarioDecimal(this.lblResultado.Text);
        }

        public static void Limpiar(FormCalculadora form)
        {
            form.txtN1.Text = String.Empty;
            form.txtN2.Text = String.Empty;
            form.comboOperadores.Text = String.Empty;
            form.lblResultado.Text = String.Empty;
        }

        private static double Operar(string numero1, string numero2,string operador)
        {
            double resultado;

            Numero n1 = new Entidades.Numero(numero1);
            Numero n2 = new Entidades.Numero(numero2);

            resultado = Entidades.Calculadora.Operar(n1, n2, operador);

            return resultado;
        }
    }
}
