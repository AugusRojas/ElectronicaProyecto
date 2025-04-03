using DataLayer.Models;
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
    public partial class ProductWindows : Form
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        public ProductWindows(ProductService productService, CategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
        }

        private void ProductWindows_Load(object sender, EventArgs e)
        {
            var result = _categoryService.GetComboBox();
            boxCategory.DataSource = result;
            boxCategory.DisplayMember = "name";
            boxCategory.ValueMember = "idCategory";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await _productService.AddProduct(new Product()
            {
                name = txtProduct.Text,
                price = decimal.Parse(txtPrice.Text),
                stock = int.Parse(txtStock.Text),
                idCategory = (int)boxCategory.SelectedValue
            });
        }

        private async void btnModify_Click(object sender, EventArgs e)
        {
            await _productService.ModifyProduct(new Product()
            {
                name = txtProduct.Text,
                price = decimal.Parse(txtPrice.Text),
                stock = int.Parse(txtStock.Text),
                idCategory = (int)boxCategory.SelectedValue
            });
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await _productService.DeleteProduct(txtProduct.Text);
        }
    }
}
