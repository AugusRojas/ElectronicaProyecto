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
        //Task<IEnumerable<Sale>> GetSales();
        //Task<Sale> GetSale(int id);
        Task<int> AddSale(Sale sale);
        //Task UpdateSale(Sale sale);
        //Task DeleteSale(int id);
    }
}
