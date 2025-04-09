using DataLayer.Interfaces;
using DataLayer.Models;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<Sale> GeneratePdf(int idSale)
        {
            return await context.Sale
                .Include(s => s.PaymentMethod)
                .Include(s => s.ProductsXSales)
                    .ThenInclude(pxs => pxs.product)
                .FirstOrDefaultAsync(s => s.idSale == idSale);
        }

        public async Task StockDiscount(List<Product> products)
        {
             foreach(var pr in products)
             {
                var product = await context.Product.FirstOrDefaultAsync(p => p.idProduct == pr.idProduct);

                product.stock = pr.stock;
             }

            await context.SaveChangesAsync();
        }
    }
}
