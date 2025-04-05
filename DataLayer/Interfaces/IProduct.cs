using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string name);
        Task<List<object>> GetProductsFilter(string filter, string value);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string name);
    }
}
