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
        private readonly ProductService ProductServices;
        public Sales(ProductService ProductServices)
        {
            InitializeComponent();
            this.ProductServices = ProductServices;
        }

        System.Windows.Forms.Timer debounceTimer;

        private void Sales_Load(object sender, EventArgs e)
        {
            txtDiscount.Text = 0.ToString();
            txt_nameProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_nameProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;

            debounceTimer = new System.Windows.Forms.Timer();
            debounceTimer.Interval = 300; 
            debounceTimer.Tick += async (s, ev) =>
            {
                debounceTimer.Stop();
                await LoadAutocomplete();
            };
        }

        private string lastQuery = "";
        private List<string> Suggestions = new List<string>();
        private async Task LoadAutocomplete()
        {
            string name = txt_nameProduct.Text;

            if (string.IsNullOrWhiteSpace(name) || name.Length < 1 || name == lastQuery) return;

            lastQuery = name;

            var names = await ProductServices.AutocompleteAsync(name);

            if (names.SequenceEqual(Suggestions)) return; 

            Suggestions = names;

            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(names.ToArray());

            txt_nameProduct.AutoCompleteCustomSource = autoComplete;
        }

        private void txt_nameProduct_TextChanged(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            debounceTimer.Start();
        }


        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(Codigo_txt.Text,txt_nameProduct.Text,txt_price.Text);
        }

        private async void txt_nameProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string name = txt_nameProduct.Text;
                var product = await ProductServices.GetProductByNameAsync(name);

                if (product == null)
                {
                    MessageBox.Show("Producto no encontrado.");
                }
                else
                {
                    Codigo_txt.Text = product.idProduct.ToString();
                    txt_price.Text = product.price.ToString();
                    label_stock.Text = product.stock.ToString();
                }
            }
        }



    }
}
