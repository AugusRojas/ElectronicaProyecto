using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly Db_Context _context;
        public ProductRepository(Db_Context context)
        {
            _context = context;
        }
        public Task AddProduct(Product product)
        {
            _context.Product.Add(product);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(string name)
        {
            var result = await GetProduct(name);
            _context.Product.Remove(result);
            await _context.SaveChangesAsync();
        }

        public Task<Product> GetProduct(string id)
        {
            var result = _context.Product.FirstAsync(p=>p.name == id);
            return result;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
            
        }

        public async Task<List<Object>> GetProductsFilter(string filter, string value)
        {
            string query = $@"SELECT Product.idProduct, Product.name AS ProductName, Product.price, Product.stock, Category.name AS CategoryName, Category.idCategory 
                              FROM Product 
                              JOIN Category ON Product.idCategory = Category.idCategory 
                              WHERE {filter} LIKE '%{value}%'";
            return await _context.Product.FromSqlRaw(query).ToListAsync<object>();
        }

        public async Task UpdateProduct(Product product)
        {
            var result = _context.Product.FirstOrDefaultAsync(p => p.name == product.name);
            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
