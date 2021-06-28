
namespace CervezaArtesanalForm
{
    partial class CargarStockForm
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
            this.components = new System.ComponentModel.Container();
            this.ingredienteDAOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredienteDAOBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ingredienteDAOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredienteDAOBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // ingredienteDAOBindingSource
            // 
            this.ingredienteDAOBindingSource.DataSource = typeof(CervezaArtesanal.DAO.IngredienteDAO);
            // 
            // ingredienteDAOBindingSource1
            // 
            this.ingredienteDAOBindingSource1.DataSource = typeof(CervezaArtesanal.DAO.IngredienteDAO);
            // 
            // CargarStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "CargarStockForm";
            this.Text = "CARGAR STOCK";
            ((System.ComponentModel.ISupportInitialize)(this.ingredienteDAOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredienteDAOBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ingredienteDAOBindingSource1;
        private System.Windows.Forms.BindingSource ingredienteDAOBindingSource;
    }
}