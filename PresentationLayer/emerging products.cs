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
    public partial class emerging_products : Form
    {
        private readonly ProductService ProductService;
        public emerging_products(ProductService ProductService)
        {
            InitializeComponent();
            this.ProductService = ProductService;
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxFilter.SelectedItem == null) return;

            string decision = comboBoxFilter.SelectedItem.ToString();
            string filter = "";
            string value = textBox1.Text;

            switch (decision)
            {
                case "Nombre":
                    filter = "name";
                    break;

                case "Categoria":
                    filter = "category";
                    break;
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {
                
                dataGridView1.DataSource = await ProductService.GetProductsFilterAsync(filter, value);

                dataGridView1.AutoGenerateColumns = true;
                //dataGridView1.Columns["Category"].DataPropertyName = "Category.name";
                //dataGridView1.Columns["Category"].HeaderText = "Categoría";


            }
        }

    }
}
