using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PaymentMethod
    {
        public int idPaymentMethod { get; set; }
        public string namePaymentMethod { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
