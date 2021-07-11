
namespace CervezaArtesanalForm
{
    partial class CervezaArtesanalForm
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
            this.txtCantidadLitros = new System.Windows.Forms.TextBox();
            this.lblCantidadLitros = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboTipos = new System.Windows.Forms.ComboBox();
            this.btCocinar = new System.Windows.Forms.Button();
            this.txtboxStockIngredientes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEmbotellar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCantidadLitros
            // 
            this.txtCantidadLitros.Location = new System.Drawing.Point(193, 33);
            this.txtCantidadLitros.Name = "txtCantidadLitros";
            this.txtCantidadLitros.Size = new System.Drawing.Size(124, 20);
            this.txtCantidadLitros.TabIndex = 0;
            // 
            // lblCantidadLitros
            // 
            this.lblCantidadLitros.AutoSize = true;
            this.lblCantidadLitros.Location = new System.Drawing.Point(196, 13);
            this.lblCantidadLitros.Name = "lblCantidadLitros";
            this.lblCantidadLitros.Size = new System.Drawing.Size(92, 13);
            this.lblCantidadLitros.TabIndex = 1;
            this.lblCantidadLitros.Text = "Cantidad de Litros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de Cerveza";
            // 
            // comboTipos
            // 
            this.comboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipos.FormattingEnabled = true;
            this.comboTipos.Location = new System.Drawing.Point(196, 91);
            this.comboTipos.Name = "comboTipos";
            this.comboTipos.Size = new System.Drawing.Size(121, 21);
            this.comboTipos.TabIndex = 4;
            // 
            // btCocinar
            // 
            this.btCocinar.Location = new System.Drawing.Point(193, 138);
            this.btCocinar.Name = "btCocinar";
            this.btCocinar.Size = new System.Drawing.Size(124, 30);
            this.btCocinar.TabIndex = 5;
            this.btCocinar.Text = "COCINAR";
            this.btCocinar.UseVisualStyleBackColor = true;
            this.btCocinar.Click += new System.EventHandler(this.btCocinar_Click);
            // 
            // txtboxStockIngredientes
            // 
            this.txtboxStockIngredientes.Location = new System.Drawing.Point(12, 33);
            this.txtboxStockIngredientes.Name = "txtboxStockIngredientes";
            this.txtboxStockIngredientes.Size = new System.Drawing.Size(159, 214);
            this.txtboxStockIngredientes.TabIndex = 6;
            this.txtboxStockIngredientes.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Stock Ingredientes";
            // 
            // btnEmbotellar
            // 
            this.btnEmbotellar.Location = new System.Drawing.Point(355, 136);
            this.btnEmbotellar.Name = "btnEmbotellar";
            this.btnEmbotellar.Size = new System.Drawing.Size(124, 34);
            this.btnEmbotellar.TabIndex = 8;
            this.btnEmbotellar.Text = "EMBOTELLAR";
            this.btnEmbotellar.UseVisualStyleBackColor = true;
            this.btnEmbotellar.Click += new System.EventHandler(this.btnEmbotelladora_Click);
            // 
            // CervezaArtesanalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 297);
            this.Controls.Add(this.btnEmbotellar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxStockIngredientes);
            this.Controls.Add(this.btCocinar);
            this.Controls.Add(this.comboTipos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCantidadLitros);
            this.Controls.Add(this.txtCantidadLitros);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CervezaArtesanalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CerveceriaArtesanal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CervezaArtesanalForm_Closing);
            this.Load += new System.EventHandler(this.CervezaArtesanalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCantidadLitros;
        private System.Windows.Forms.Label lblCantidadLitros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboTipos;
        private System.Windows.Forms.Button btCocinar;
        private System.Windows.Forms.RichTextBox txtboxStockIngredientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEmbotellar;
    }
}

