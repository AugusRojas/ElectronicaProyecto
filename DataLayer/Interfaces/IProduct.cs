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
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
        Task<List<object>> GetDataGridView();
        Task<List<object>> GetAllProductsFilters(string name);
    }
}
