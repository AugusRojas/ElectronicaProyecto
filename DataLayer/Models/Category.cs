using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Category
    {
        public int idCategory { get; set; }
        public string name { get; set; }
        public List<Product> Products { get; set; }
    }
}
