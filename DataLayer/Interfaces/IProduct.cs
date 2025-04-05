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
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(string name);
<<<<<<< HEAD
        Task<List<object>> GetProductsFilter(string filter, string value);
=======
>>>>>>> f8647f7fce283195b8606c0230feec1a8ab6b961
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
        Task<List<object>> GetDataGridView();
        Task<List<object>> GetAllProductsFilters(string name);
    }
}
