using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DTO
{
    public class DTOProductsXSales
    {
        public int idProduct { get; set; }
        public int idSale { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public decimal totalAmount { get; set; }
        public decimal subtotal { get; set; }
        public decimal discount { get; set; }
        public DateTime date { get; set; }
        public DateTime hour { get; set; }
    }
}
