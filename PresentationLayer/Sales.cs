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
        SaleService services = new SaleService();
        public Sales(ProductService ProductServices)
        {
            InitializeComponent();
            this.ProductServices = ProductServices;
        }

        System.Windows.Forms.Timer debounceTimer;

        private void Sales_Load(object sender, EventArgs e)
        {
            label_date.Text = DateTime.Now.ToString("d");

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

        List<double> subtotales = new List<double>();
        private async void buttonAgregar_Click(object sender, EventArgs e)
        {
            //Agrega los productos al datagridview
            double Subtotal = services.TotalProduct(txt_price.Text, numericUpDownquantity.Value.ToString(), txtDiscount.Text);

            dataGridView1.Rows.Add(Codigo_txt.Text, txt_nameProduct.Text, txt_price.Text, numericUpDownquantity.Value.ToString(), txtDiscount.Text, Subtotal.ToString());

            //Carlcular el total a vender por que esa libreria de mierda no la puedo importar

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    subtotales.Add(double.Parse(row.Cells["Subtotal"].Value.ToString()));
                }
            }

            label_Total.Text = subtotales.Sum().ToString("0.00");

            //limpia los textboxs
            txtDiscount.Text = 0.ToString();
            txt_price.Clear();
            Codigo_txt.Clear();
            txt_nameProduct.Clear();
            label_stock.Text = "";
            numericUpDownquantity.Value = 0;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_hour.Text = DateTime.Now.ToString("T");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "X")
            {
                double ValueEliminate = 0;
                double.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Subtotal"].Value?.ToString(), out ValueEliminate);

                // Eliminar de la lista (por valor exacto)
                subtotales.RemoveAll(x => x == ValueEliminate);

                dataGridView1.Rows.RemoveAt(e.RowIndex);

                label_Total.Text = subtotales.Sum().ToString("0.00");
            }
        }

    }
}
