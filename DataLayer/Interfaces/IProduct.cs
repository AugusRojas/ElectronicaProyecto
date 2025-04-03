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
        //Task<Product> GetProduct(int id);
        //Task AddProduct(Product product);
        //Task UpdateProduct(Product product);
        //Task DeleteProduct(int id);
    }
}
