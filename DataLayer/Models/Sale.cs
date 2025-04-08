using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Sale
    {
        public int idSale { get; set; }
        public int idPaymentMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal totalAmount { get; set; }
        public TimeSpan hour { get; set; }
        public string date { get; set; }
        public List<ProductsXSales> ProductsXSales { get; set; }
    }
}
