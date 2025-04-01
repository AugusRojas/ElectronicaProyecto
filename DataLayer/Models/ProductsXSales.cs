using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ProductsXSales
    {
        public int idProduct { get; set; }
        public Product product { get; set; }
        public int idSale { get; set; }
        public Sale sale { get; set;  }
        public int amount { get; set; }
        public decimal subtotal { get; set; }
        public int discount { get; set; }
    }
}
