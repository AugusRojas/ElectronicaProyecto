using LogicLayer.ValidatorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
        public string _cash { get; set; }
        public string _trasnfer { get; set; }
        public string _card { get; set; }
        public string _hourClosing { get; set; }
        public string _date { get; set; }
        public CashClosing(string cash, string card, string trasnfer, string hourClosign, string date, SaleService saleService)
        {
            InitializeComponent();
            _cash = cash;
            _trasnfer = trasnfer;
            _card = card;
            _hourClosing = hourClosign;
            _date = date;
            _saleService = saleService;
        }

        private async void CashClosing_Load(object sender, EventArgs e)
        {
            txtCard.Text = _card;
            txtCash.Text = _cash;
            txtTrasnfer.Text = _trasnfer;
            labelDate.Text = DateTime.Now.ToString("d");
            labelHour.Text = _hourClosing;
            txtTotal.Text = (Convert.ToDouble(_cash) + Convert.ToDouble(_trasnfer) + Convert.ToDouble(_card)).ToString();

            // Obtener la lista de productos
            var result = await _saleService.GetSummaryProducts();

            if (result == null || result.Count == 0)
            {
                MessageBox.Show("No hay productos");
                return;
            }
            else
            {
                dataGridViewProducts.DataSource = await _saleService.GetSummaryProducts();
                dataGridViewProducts.Columns[0].HeaderText = "ID";  // Nombre de la primera columna
                dataGridViewProducts.Columns[0].Visible = false; // Ocultar la columna ID
                dataGridViewProducts.Columns[1].HeaderText = "ID Venta";
                dataGridViewProducts.Columns[1].Visible = false; // Ocultar la columna ID
                dataGridViewProducts.Columns[2].HeaderText = "Nombre";       // Nombre de la segunda columna
                dataGridViewProducts.Columns[3].HeaderText = "Total";       // Nombre de la tercera columna
                dataGridViewProducts.Columns[4].HeaderText = "Subtotal";
                dataGridViewProducts.Columns[5].HeaderText = "Descuento"; // Nombre de la cuarta columna
                dataGridViewProducts.Columns[6].HeaderText = "Fecha"; // Nombre de la cuarta columna
                dataGridViewProducts.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy"; // Formato de fecha
                dataGridViewProducts.Columns[7].HeaderText = "Hora"; // Nombre de la cuarta columna
                dataGridViewProducts.Columns[7].DefaultCellStyle.Format = "HH:mm:ss";
                dataGridViewProducts.Columns[8].HeaderText = "Metodo de pago"; // Nombre de la cuarta column                                                                               // Ajusta las columnas automáticamente al contenido
                dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            }
        }


        private void CashClosing_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCashClose_Click(object sender, EventArgs e)
        {



            Application.Exit();
        }
    }
}
