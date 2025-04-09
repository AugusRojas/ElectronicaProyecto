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
        Task AddSale(Sale sale);
        Task UpdateSale(Sale sale);
        Task DeleteSale(int id);
        Task<string> GetCash();
        Task<string> GetCard();
        Task<string> GetTransfer();
        Task<List<object>> GetSummaryProducts();
    }
}
