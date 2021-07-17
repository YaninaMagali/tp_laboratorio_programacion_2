
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCantidadLitros
            // 
            this.txtCantidadLitros.Location = new System.Drawing.Point(30, 239);
            this.txtCantidadLitros.Name = "txtCantidadLitros";
            this.txtCantidadLitros.Size = new System.Drawing.Size(155, 20);
            this.txtCantidadLitros.TabIndex = 0;
            // 
            // lblCantidadLitros
            // 
            this.lblCantidadLitros.AutoSize = true;
            this.lblCantidadLitros.Location = new System.Drawing.Point(27, 222);
            this.lblCantidadLitros.Name = "lblCantidadLitros";
            this.lblCantidadLitros.Size = new System.Drawing.Size(92, 13);
            this.lblCantidadLitros.TabIndex = 1;
            this.lblCantidadLitros.Text = "Cantidad de Litros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de Cerveza";
            // 
            // comboTipos
            // 
            this.comboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipos.FormattingEnabled = true;
            this.comboTipos.Location = new System.Drawing.Point(30, 286);
            this.comboTipos.Name = "comboTipos";
            this.comboTipos.Size = new System.Drawing.Size(155, 21);
            this.comboTipos.TabIndex = 4;
            // 
            // btCocinar
            // 
            this.btCocinar.Location = new System.Drawing.Point(30, 317);
            this.btCocinar.Name = "btCocinar";
            this.btCocinar.Size = new System.Drawing.Size(155, 47);
            this.btCocinar.TabIndex = 5;
            this.btCocinar.Text = "COCINAR";
            this.btCocinar.UseVisualStyleBackColor = true;
            this.btCocinar.Click += new System.EventHandler(this.btCocinar_Click);
            // 
            // txtboxStockIngredientes
            // 
            this.txtboxStockIngredientes.Location = new System.Drawing.Point(26, 57);
            this.txtboxStockIngredientes.Name = "txtboxStockIngredientes";
            this.txtboxStockIngredientes.ReadOnly = true;
            this.txtboxStockIngredientes.Size = new System.Drawing.Size(159, 159);
            this.txtboxStockIngredientes.TabIndex = 6;
            this.txtboxStockIngredientes.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Stock Ingredientes";
            // 
            // btnEmbotellar
            // 
            this.btnEmbotellar.Location = new System.Drawing.Point(16, 305);
            this.btnEmbotellar.Name = "btnEmbotellar";
            this.btnEmbotellar.Size = new System.Drawing.Size(152, 47);
            this.btnEmbotellar.TabIndex = 8;
            this.btnEmbotellar.Text = "EMBASAR";
            this.btnEmbotellar.UseVisualStyleBackColor = true;
            this.btnEmbotellar.Click += new System.EventHandler(this.btnEmbotelladora_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 375);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COCINA";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEmbotellar);
            this.groupBox2.Location = new System.Drawing.Point(215, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 372);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EMBASADO";
            // 
            // CervezaArtesanalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 395);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxStockIngredientes);
            this.Controls.Add(this.btCocinar);
            this.Controls.Add(this.comboTipos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCantidadLitros);
            this.Controls.Add(this.txtCantidadLitros);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CervezaArtesanalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CerveceriaArtesanal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CervezaArtesanalForm_Closing);
            this.Load += new System.EventHandler(this.CervezaArtesanalForm_Load);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

