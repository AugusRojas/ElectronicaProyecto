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
            _context.Products.Add(product);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(string name)
        {
            var result = await GetProduct(name);
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
        }

        public Task<Product> GetProduct(string id)
        {
            var result = _context.Products.FirstAsync(p=>p.name == id);
            return result;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
            
        }
        public async Task UpdateProduct(Product product)
        {
            var result = _context.Products.FirstOrDefaultAsync(p => p.name == product.name);
            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
