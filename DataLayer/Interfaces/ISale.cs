using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ISale
    {
        Task<int> AddSale(Sale sale);
        Task<Sale> GeneratePdf(int idSale);
        Task StockDiscount(List<Product> products);
    }
}
