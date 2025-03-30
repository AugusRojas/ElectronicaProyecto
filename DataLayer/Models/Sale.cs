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
        public decimal total { get; set; }
        public DateTime date { get; set; }

        public List<Product> Products { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
