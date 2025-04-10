using DataLayer.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ISale
    {
        Task<IEnumerable<Sale>> GetSales();
        Task<Sale> GetSale(int id);
        Task UpdateSale(Sale sale);
        Task DeleteSale(int id);
        Task<string> GetCash(string label_hour, string hour, string label_date);
        Task<string> GetCard(string label_hour, string hour, string label_date);
        Task<string> GetTransfer(string label_hour, string hour, string label_date);
        Task<List<object>> GetSummaryProducts(string hourClosing,string hourOpening, string date);
        Task<int> AddSale(Sale sale);
        Task<Sale> GeneratePdf(int idSale);
        Task StockDiscount(List<Product> products);

    }
}
