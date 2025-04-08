using DataLayer.Interfaces;
using DataLayer.Models;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SaleRepository : ISale
    {
        private readonly Db_Context context;

        public SaleRepository(Db_Context context)
        {
            this.context = context;
        }

        public async Task<int> AddSale(Sale sale)
        {
            await context.Sale.AddAsync(sale);
            await context.SaveChangesAsync();
            return sale.idSale;
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
