
namespace CervezaArtesanalForm
{
    partial class EmbotelladoraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxStockCerveza = new System.Windows.Forms.RichTextBox();
            this.btnIniciarEmbotellado = new System.Windows.Forms.Button();
            this.lblCapacidadTotalBotellas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxStockCerveza
            // 
            this.txtBoxStockCerveza.Location = new System.Drawing.Point(27, 37);
            this.txtBoxStockCerveza.Name = "txtBoxStockCerveza";
            this.txtBoxStockCerveza.Size = new System.Drawing.Size(214, 258);
            this.txtBoxStockCerveza.TabIndex = 0;
            this.txtBoxStockCerveza.Text = "";
            this.txtBoxStockCerveza.TextChanged += new System.EventHandler(this.txtBoxStockCerveza_TextChanged);
            // 
            // btnIniciarEmbotellado
            // 
            this.btnIniciarEmbotellado.Location = new System.Drawing.Point(27, 310);
            this.btnIniciarEmbotellado.Name = "btnIniciarEmbotellado";
            this.btnIniciarEmbotellado.Size = new System.Drawing.Size(214, 35);
            this.btnIniciarEmbotellado.TabIndex = 1;
            this.btnIniciarEmbotellado.Text = "INICIAR";
            this.btnIniciarEmbotellado.UseVisualStyleBackColor = true;
            this.btnIniciarEmbotellado.Click += new System.EventHandler(this.btnIniciarEmbotellado_Click);
            // 
            // lblCapacidadTotalBotellas
            // 
            this.lblCapacidadTotalBotellas.AutoSize = true;
            this.lblCapacidadTotalBotellas.Location = new System.Drawing.Point(305, 47);
            this.lblCapacidadTotalBotellas.Name = "lblCapacidadTotalBotellas";
            this.lblCapacidadTotalBotellas.Size = new System.Drawing.Size(35, 13);
            this.lblCapacidadTotalBotellas.TabIndex = 2;
            this.lblCapacidadTotalBotellas.Text = "label1";
            // 
            // EmbotelladoraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 357);
            this.Controls.Add(this.lblCapacidadTotalBotellas);
            this.Controls.Add(this.btnIniciarEmbotellado);
            this.Controls.Add(this.txtBoxStockCerveza);
            this.Name = "EmbotelladoraForm";
            this.Text = "EmbotellarForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmbotellarFormClosing);
            this.Load += new System.EventHandler(this.EmbotelladoraLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtBoxStockCerveza;
        private System.Windows.Forms.Button btnIniciarEmbotellado;
        private System.Windows.Forms.Label lblCapacidadTotalBotellas;
    }
}