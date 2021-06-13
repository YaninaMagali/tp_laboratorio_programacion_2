
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
            this.SuspendLayout();
            // 
            // txtCantidadLitros
            // 
            this.txtCantidadLitros.Location = new System.Drawing.Point(13, 33);
            this.txtCantidadLitros.Name = "txtCantidadLitros";
            this.txtCantidadLitros.Size = new System.Drawing.Size(124, 20);
            this.txtCantidadLitros.TabIndex = 0;
            // 
            // lblCantidadLitros
            // 
            this.lblCantidadLitros.AutoSize = true;
            this.lblCantidadLitros.Location = new System.Drawing.Point(13, 13);
            this.lblCantidadLitros.Name = "lblCantidadLitros";
            this.lblCantidadLitros.Size = new System.Drawing.Size(92, 13);
            this.lblCantidadLitros.TabIndex = 1;
            this.lblCantidadLitros.Text = "Cantidad de Litros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de Cerveza";
            // 
            // comboTipos
            // 
            this.comboTipos.FormattingEnabled = true;
            this.comboTipos.Location = new System.Drawing.Point(16, 97);
            this.comboTipos.Name = "comboTipos";
            this.comboTipos.Size = new System.Drawing.Size(121, 21);
            this.comboTipos.TabIndex = 4;
            // 
            // btCocinar
            // 
            this.btCocinar.Location = new System.Drawing.Point(13, 147);
            this.btCocinar.Name = "btCocinar";
            this.btCocinar.Size = new System.Drawing.Size(124, 30);
            this.btCocinar.TabIndex = 5;
            this.btCocinar.Text = "COCINAR";
            this.btCocinar.UseVisualStyleBackColor = true;
            this.btCocinar.Click += new System.EventHandler(this.btCocinar_Click);
            // 
            // CervezaArtesanalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 251);
            this.Controls.Add(this.btCocinar);
            this.Controls.Add(this.comboTipos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCantidadLitros);
            this.Controls.Add(this.txtCantidadLitros);
            this.Name = "CervezaArtesanalForm";
            this.Text = "CerveceriaArtesanal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCantidadLitros;
        private System.Windows.Forms.Label lblCantidadLitros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboTipos;
        private System.Windows.Forms.Button btCocinar;
    }
}

