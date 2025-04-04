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

        private async void ProductWindows_Load(object sender, EventArgs e)
        {
            dataGridViewProduct.DataSource = await _productService.GetDataGridView();
            dataGridViewProduct.Columns[0].HeaderText = "ID";  // Nombre de la primera columna
            dataGridViewProduct.Columns[0].Visible = false; // Ocultar la columna ID
            dataGridViewProduct.Columns[1].HeaderText = "Nombre";       // Nombre de la segunda columna
            dataGridViewProduct.Columns[2].HeaderText = "Precio";       // Nombre de la tercera columna
            dataGridViewProduct.Columns[3].HeaderText = "Stock";
            dataGridViewProduct.Columns[4].HeaderText = "Categoría"; // Nombre de la cuarta columna
            var result = await _categoryService.GetComboBox();
            boxCategory.DataSource = result;
            boxCategory.DisplayMember = "name";
            boxCategory.ValueMember = "idCategory";
        }
        private async void btnModify_Click_1(object sender, EventArgs e)
        {
            var result = await _productService.ModifyProduct(new Product()
            {
                name = txtProduct.Text ?? " ",
                price = decimal.TryParse(txtPrice.Text, out decimal price) ? price : -1, // Validar el precio
                stock = int.TryParse(txtStock.Text, out int stock) ? stock : -1, // Validar el stock
                idCategory = (int)(boxCategory.SelectedValue ?? 0) // Validar la categoría
            });

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Producto modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewProduct.DataSource = await _productService.GetDataGridView();
                dataGridViewProduct.Columns[0].HeaderText = "com";  // Nombre de la primera columna
                dataGridViewProduct.Columns[1].HeaderText = "Nombre";       // Nombre de la segunda columna
                dataGridViewProduct.Columns[2].HeaderText = "Precio";       // Nombre de la tercera columna
                dataGridViewProduct.Columns[3].HeaderText = "Stock";
                dataGridViewProduct.Columns[4].HeaderText = "Categoría";
            }
            else
            {
                MessageBox.Show("Error al modificar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            var result = await _productService.DeleteProduct(new Product()
            {
                name = txtProduct.Text ?? " ",
                price = decimal.TryParse(txtPrice.Text, out decimal price) ? price : -1, // Validar el precio
                stock = int.TryParse(txtStock.Text, out int stock) ? stock : -1, // Validar el stock
                idCategory = (int)(boxCategory.SelectedValue ?? 0) // Validar la categoría
            });

            if (string.IsNullOrEmpty(result)) // Si la validación fue exitosa
            {
                MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewProduct.DataSource = await _productService.GetDataGridView();
                dataGridViewProduct.Columns[0].HeaderText = "com";  // Nombre de la primera columna
                dataGridViewProduct.Columns[1].HeaderText = "Nombre";       // Nombre de la segunda columna
                dataGridViewProduct.Columns[2].HeaderText = "Precio";       // Nombre de la tercera columna
                dataGridViewProduct.Columns[3].HeaderText = "Stock";
                dataGridViewProduct.Columns[4].HeaderText = "Categoría";
            }
            else // Si hay errores de validación
            {
                MessageBox.Show(result, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Crear el producto a agregar
            var result = await _productService.AddProduct(new Product()
            {
                name = txtProduct.Text ?? " ",
                price = decimal.TryParse(txtPrice.Text, out decimal price) ? price : -1, // Validar el precio
                stock = int.TryParse(txtStock.Text, out int stock) ? stock : -1, // Validar el stock
                idCategory = (int)(boxCategory.SelectedValue ?? 0) // Validar la categoría
            });

            if (string.IsNullOrEmpty(result)) // Si la validación fue exitosa
            {
                MessageBox.Show("Producto agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewProduct.DataSource = await _productService.GetDataGridView();
                dataGridViewProduct.Columns[0].HeaderText = "com";  // Nombre de la primera columna
                dataGridViewProduct.Columns[1].HeaderText = "Nombre";       // Nombre de la segunda columna
                dataGridViewProduct.Columns[2].HeaderText = "Precio";       // Nombre de la tercera columna
                dataGridViewProduct.Columns[3].HeaderText = "Stock";
                dataGridViewProduct.Columns[4].HeaderText = "Categoría";
            }
            else // Si hay errores de validación
            {
                MessageBox.Show(result, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProduct.SelectedRows[0];
                txtProduct.Text = selectedRow.Cells[1].Value.ToString();
                txtPrice.Text = selectedRow.Cells[2].Value.ToString();
                txtStock.Text = selectedRow.Cells[3].Value.ToString();
                var nameCategory = selectedRow.Cells[4].Value;
                boxCategory.Text = nameCategory.ToString();
            }
        }

        private async void btnSearch_TextChanged(object sender, EventArgs e)
        {
            var resuslt = await _productService.GetAllProductsFilters(btnSearch.Text);
            dataGridViewProduct.DataSource = resuslt;
            int columnCount = dataGridViewProduct.Columns.Count;

            // Modificar las cabeceras si las columnas existen
            if (columnCount > 0) dataGridViewProduct.Columns[0].HeaderText = "ID";  // Primera columna
            if (columnCount > 1) dataGridViewProduct.Columns[1].HeaderText = "Nombre"; // Segunda columna
            if (columnCount > 2) dataGridViewProduct.Columns[2].HeaderText = "Precio"; // Tercera columna
            if (columnCount > 3) dataGridViewProduct.Columns[3].HeaderText = "Stock";  // Cuarta columna
            if (columnCount > 4) dataGridViewProduct.Columns[4].HeaderText = "Categoría";  // Quinta columna

            // Ocultar la columna 'ID' si existe
            if (dataGridViewProduct.Columns.Contains("ID"))
            {
                dataGridViewProduct.Columns["ID"].Visible = false;
            }
        }
    }
}
