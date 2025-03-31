using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SaleRepository : ISale
    {
        public Task AddSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetSales()
        {
            throw new NotImplementedException();
        }

        public Task UpdateSale(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
