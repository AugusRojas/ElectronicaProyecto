using DataLayer.Interfaces;
using DataLayer.Repositories;
using LogicLayer.ValidatorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Sales : Form
    {
        private readonly ProductService ProductService;
        public Sales(ProductService ProductService)
        {
            InitializeComponent();
            this.ProductService = ProductService;
        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abre el formulario emergente pasando la instancia de IProduct
            var emergingProducts = new emerging_products(ProductService);
            emergingProducts.Show();
        }
    }
}
