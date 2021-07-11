
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxStockCerveza
            // 
            this.txtBoxStockCerveza.Location = new System.Drawing.Point(24, 98);
            this.txtBoxStockCerveza.Name = "txtBoxStockCerveza";
            this.txtBoxStockCerveza.Size = new System.Drawing.Size(214, 230);
            this.txtBoxStockCerveza.TabIndex = 0;
            this.txtBoxStockCerveza.Text = "";
            this.txtBoxStockCerveza.TextChanged += new System.EventHandler(this.txtBoxStockCerveza_TextChanged);
            // 
            // btnIniciarEmbotellado
            // 
            this.btnIniciarEmbotellado.Location = new System.Drawing.Point(24, 343);
            this.btnIniciarEmbotellado.Name = "btnIniciarEmbotellado";
            this.btnIniciarEmbotellado.Size = new System.Drawing.Size(214, 35);
            this.btnIniciarEmbotellado.TabIndex = 1;
            this.btnIniciarEmbotellado.Text = "INICIAR EMBASADO";
            this.btnIniciarEmbotellado.UseVisualStyleBackColor = true;
            this.btnIniciarEmbotellado.Click += new System.EventHandler(this.btnIniciarEmbotellado_Click);
            // 
            // lblCapacidadTotalBotellas
            // 
            this.lblCapacidadTotalBotellas.AutoSize = true;
            this.lblCapacidadTotalBotellas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacidadTotalBotellas.Location = new System.Drawing.Point(63, 37);
            this.lblCapacidadTotalBotellas.Name = "lblCapacidadTotalBotellas";
            this.lblCapacidadTotalBotellas.Size = new System.Drawing.Size(46, 17);
            this.lblCapacidadTotalBotellas.TabIndex = 2;
            this.lblCapacidadTotalBotellas.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Almacenamiento Disponible";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Control Stock Cerveza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Litros:";
            // 
            // EmbotelladoraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 390);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCapacidadTotalBotellas);
            this.Controls.Add(this.btnIniciarEmbotellado);
            this.Controls.Add(this.txtBoxStockCerveza);
            this.Name = "EmbotelladoraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Embasar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmbotellarFormClosing);
            this.Load += new System.EventHandler(this.EmbotelladoraLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtBoxStockCerveza;
        private System.Windows.Forms.Button btnIniciarEmbotellado;
        private System.Windows.Forms.Label lblCapacidadTotalBotellas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}