using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using LogicLayer.ValidatorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PresentationLayer
{
    public partial class Sales : Form
    {
        private readonly PaymentMethodService PaymentMethodService;
        private readonly ProductService ProductServices;
        private readonly SaleService SaleService;
        private readonly ProductsXSalesService ProductsXSalesService;
        private readonly CategoryService CategoryServices;



        public string hour { get; set; }

        public Sales(ProductService ProductServices, PaymentMethodService PaymentMethodService, SaleService SaleService, ProductsXSalesService ProductsXSalesService, CategoryService categoryService)
        {
            InitializeComponent();
            this.ProductServices = ProductServices;
            this.PaymentMethodService = PaymentMethodService;
            this.SaleService = SaleService;
            this.ProductsXSalesService = ProductsXSalesService;
            CategoryServices = categoryService;
        }

        System.Windows.Forms.Timer debounceTimer;

        private async void Sales_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            label_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            hour = DateTime.Now.ToString("HH:mm:ss");

            txtDiscount.Text = 0.ToString();
            label_Total.Text = 0.ToString();
            txt_nameProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_nameProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;

            debounceTimer = new System.Windows.Forms.Timer();
            debounceTimer.Interval = 300;
            debounceTimer.Tick += async (s, ev) =>
            {
                debounceTimer.Stop();
                await LoadAutocomplete();
            };

            var PaymentMethods = await PaymentMethodService.GetPayMethodsAsync();
            comboBoxMethod.DataSource = PaymentMethods;
            comboBoxMethod.DisplayMember = "namePaymentMethod";
            comboBoxMethod.ValueMember = "idPaymentMethod";
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
            subtotales = [];
            double Subtotal = SaleService.TotalProduct(txt_price.Text, numericUpDownquantity.Value.ToString(), txtDiscount.Text);

            dataGridView1.Rows.Add(Codigo_txt.Text, txt_nameProduct.Text, txt_price.Text, numericUpDownquantity.Value.ToString(), txtDiscount.Text, Subtotal.ToString());

            //Carlcular el total a vender por que esa libreria de mierda no la puedo importar

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    subtotales.Add(double.Parse(row.Cells["Subtotal"].Value.ToString()));
                }
            }
            label_Total.Text = 0.ToString();
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
            label_hour.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "X")
            {
                double ValueEliminate = 0;
                double.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Subtotal"].Value?.ToString(), out ValueEliminate);

                subtotales.RemoveAll(x => x == ValueEliminate);

                dataGridView1.Rows.RemoveAt(e.RowIndex);

                label_Total.Text = subtotales.Sum().ToString("0.00");
            }
        }

        private async void buttonPagar_Click(object sender, EventArgs e)
        {
            int idPM = (int)comboBoxMethod.SelectedValue;

            var sale = new Sale
            {
                idPaymentMethod = idPM,
                totalAmount = decimal.Parse(label_Total.Text),
                hour = label_hour.Text,
                date = DateTime.Now.ToString("dd/MM/yyyy")
            };

            int idSale = await SaleService.AddSale(sale);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var pxs = new ProductsXSales
                {
                    idProduct = Convert.ToInt32(row.Cells["Id"].Value),
                    idSale = idSale,
                    amount = Convert.ToInt32(row.Cells["Cantidad_a_vender"].Value),
                    subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value),
                    discount = Convert.ToInt32(row.Cells["Descuento"].Value)
                };

                await ProductsXSalesService.AddPXSAsync(pxs);
            }


            //Limpiar y actualizar el label total

            dataGridView1.Rows.Clear();
            subtotales.Clear();
            subtotales.Add(0);
            label_Total.Text = subtotales[0].ToString();

            /////
            ///
            //
            //

            string path = await SaleService.GeneratePdfAsync(idSale);

            // si la opcion es si, redirecciona al navegador
            var result = MessageBox.Show("¿Desea imprimir el comprobante?", "Comprobante generado", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Process.Start("explorer", path);
            }





            //var errores = await SaleService.StockDiscountAsync();

            //if (errores.Any())
            //{
            //    // Mostrarlos en un MessageBox, panel, o similar
            //    string me = string.Join("\n", errores);
            //    MessageBox.Show(me, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    MessageBox.Show("Stock actualizado correctamente");
            //}

        }
        
        private async void btnCashClosing_Click(object sender, EventArgs e)
        {
            string cash = await SaleService.GetCash(label_hour.Text,hour,label_date.Text);
            string card = await SaleService.GetCard(label_hour.Text, hour, label_date.Text);
            string trasnfer = await SaleService.GetTransfer(label_hour.Text, hour, label_date.Text);
            CashClosing cashClosing = new CashClosing(cash, card, trasnfer, label_hour.Text, label_date.Text, SaleService,hour);
            this.Hide();
            cashClosing.Show();
            

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductWindows ProductWindows = new ProductWindows(ProductServices, CategoryServices);
            this.Hide();
            ProductWindows.Show();
        }
    }
}