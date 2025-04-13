using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ProductsXSalesRepository : IProductsXSales
    {
        private readonly Db_Context context;
        public ProductsXSalesRepository(Db_Context context)
        {
            this.context = context;
        }

        public async Task AddPXS(ProductsXSales pxs)
        {
            await context.ProductsXSales.AddAsync(pxs);
            await context.SaveChangesAsync();
        }

    }
}
