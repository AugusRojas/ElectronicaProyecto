using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidatorService
{
    public class SaleService
    {
        public double TotalProduct(string price, string quantity, string discount)
        {
            double sub = (double.Parse(price) * int.Parse(quantity));
            if (string.IsNullOrEmpty(quantity)) return 0;

            else if (discount == "") return sub;

            else if (int.Parse(discount) > 0)
            {
                double disco = (sub * int.Parse(discount)) / 100;

                return sub - disco;
            }

            else if (int.Parse(discount) == 0) return sub;

            return 0;
        }

        
    }
}
