using CervezaArtesanal.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CervezaArtesanalForm
{
    public partial class CargarStockForm : Form
    {
        IngredienteDAO dao = new IngredienteDAO();
        public CargarStockForm()
        {
            InitializeComponent();
        }



    }
}
