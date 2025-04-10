using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.DTO;
using LogicLayer.ValidatorService;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace PresentationLayer
{
    public partial class CashClosing : Form
    {
        private readonly SaleService _saleService;
        private readonly DocumentCashClosing documentCashClosing;
        public string _cash { get; set; }
        public string _trasnfer { get; set; }
        public string _card { get; set; }
        public string _hourClosing { get; set; }
        public string _date { get; set; }
        public string _hourOpening { get; set; }
        public CashClosing(string cash, string card, string trasnfer, string hourClosign, string date, SaleService saleService,string hourOpening)
        {
            InitializeComponent();
            _cash = cash;
            _trasnfer = trasnfer;
            _card = card;
            _hourClosing = hourClosign;
            _date = date;
            _saleService = saleService;
            _hourOpening = hourOpening;
        }

        private async void CashClosing_Load(object sender, EventArgs e)
        {
            txtCard.Text = _card;
            txtCash.Text = _cash;
            txtTrasnfer.Text = _trasnfer;
            labelDate.Text = _date;
            labelHour.Text = _hourClosing;
            txtTotal.Text = (Convert.ToDouble(_cash) + Convert.ToDouble(_trasnfer) + Convert.ToDouble(_card)).ToString();

            // Obtener la lista de productos
            var result = await _saleService.GetSummaryProducts(_hourClosing,_hourOpening,labelDate.Text);

            if (result == null || result.Count == 0)
            {
                MessageBox.Show("No hay productos");
                return;
            }
            else
            {
                dataGridViewProducts.DataSource = result;
                dataGridViewProducts.Columns[0].HeaderText = "ID";  // Nombre de la primera columna
                dataGridViewProducts.Columns[0].Visible = false; // Ocultar la columna ID
                dataGridViewProducts.Columns[1].HeaderText = "ID Venta";
                dataGridViewProducts.Columns[1].Visible = false; // Ocultar la columna ID
                dataGridViewProducts.Columns[2].HeaderText = "Nombre";
                dataGridViewProducts.Columns[3].HeaderText = "Cantidad";
                dataGridViewProducts.Columns[4].HeaderText = "Total";       // Nombre de la tercera columna
                dataGridViewProducts.Columns[5].HeaderText = "Subtotal";
                dataGridViewProducts.Columns[6].HeaderText = "Descuento"; // Nombre de la cuarta columna
                dataGridViewProducts.Columns[7].HeaderText = "Fecha"; // Nombre de la cuarta columna
                dataGridViewProducts.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy"; // Formato de fecha
                dataGridViewProducts.Columns[8].HeaderText = "Hora"; // Nombre de la cuarta columna
                dataGridViewProducts.Columns[8].DefaultCellStyle.Format = "HH:mm:ss";
                dataGridViewProducts.Columns[9].HeaderText = "Metodo de pago"; // Nombre de la cuarta column                                                                               // Ajusta las columnas automáticamente al contenido
                dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            }
        }


        private void CashClosing_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCashClose_Click(object sender, EventArgs e)
        {
            List<DTOProductsXSales> productsXSales = new List<DTOProductsXSales>();
            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
            {
                if (row.IsNewRow) continue;
                DTOProductsXSales product = new DTOProductsXSales
                {
                    idProduct = Convert.ToInt32(row.Cells[0].Value),
                    idSale = Convert.ToInt32(row.Cells[1].Value),
                    name = row.Cells[2].Value.ToString(),
                    amount = Convert.ToInt32(row.Cells[3].Value),
                    totalAmount = Convert.ToDecimal(row.Cells[4].Value),
                    subtotal = Convert.ToDecimal(row.Cells[5].Value),
                    discount = Convert.ToDecimal(row.Cells[6].Value),
                    date = DateTime.Parse(row.Cells[7].Value.ToString()),
                    hour = DateTime.Parse(row.Cells[8].Value.ToString()),
                };
                productsXSales.Add(product);
            }
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ResumenDia");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // Obtené el texto y reemplazá los caracteres no válidos; // 12-42-25
            string formatDate = DateTime.Parse(labelDate.Text).ToString("dd-MM-yyyy");
            string formatHour = DateTime.Parse(labelHour.Text).ToString("HH-mm-ss");
            if (productsXSales.Count == 0)
            {
                MessageBox.Show("No se puede imprimir por que no hay productos ahora se cerrara...");
                Application.Exit();

            }
            var documentoPath = Path.Combine(folderPath, $"Comprobante_{formatHour}_{formatDate}.pdf");
            var document = new DocumentCashClosing(productsXSales);
            document.GeneratePdf(documentoPath);
            var result = MessageBox.Show("¿Desea imprimir el comprobante?", "Comprobante generado", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Process.Start("explorer");
            }


            Application.Exit();
        }
    }
}
