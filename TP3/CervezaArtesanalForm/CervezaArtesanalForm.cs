﻿using System;
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
            int cantidadLitrosAux;
            

            if(int.TryParse(txtCantidadLitros.Text, out cantidadLitrosAux) &&
                Enum.TryParse<ETipoCerveza>(comboTipos.SelectedValue.ToString(), out tipoAux))
            {
                if(FabricaBebidas.Cocinar(tipoAux, cantidadLitrosAux))
                { MessageBox.Show("COCINANDO..."); }
                else
                { MessageBox.Show("NO SE PUEDE COCINAR...", 
                    "Error!",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error); }
            }

            
        }
    }
}