using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Product
    {
        public int idProduct { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
