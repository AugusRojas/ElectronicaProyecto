using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ProductRepository : IProduct
    {
        public readonly Db_Context context;
        public ProductRepository(Db_Context context)
        {
            this.context = context;
        }

        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await context.Products.Get
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
