using DataLayer.Interfaces;
using DataLayer.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public async Task<string> AddProduct(Product product)
        {
            // Verificar si el producto ya existe
            var existingProduct = await GetProduct(product.name);
            if (existingProduct != null)
            {
                return "El producto ya existe.";
            }
            else
            {
                _context.Product.Add(product);
                await _context.SaveChangesAsync();
                return "";
            }
            
        }

        public async Task DeleteProduct(Product product)
        {
            var result = await GetProduct(product.name);
            _context.Product.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(string name)
        {
            var result = await _context.Product.FirstOrDefaultAsync(p=>p.name == name);
            return result;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

       

        public async Task UpdateProduct(Product product)
        {
            var result = await _context.Product.FirstOrDefaultAsync(p => p.name == product.name);

            if (result != null)
            {
                // Asignar los valores del producto pasado como parámetro a 'result'
                result.price = product.price;
                result.stock = product.stock;
                result.idCategory = product.idCategory;  // Asegúrate de actualizar todos los campos relevantes

                // Marca la entidad como modificada
                _context.Entry(result).State = EntityState.Modified;
                await _context.SaveChangesAsync();  // Guardar los cambios en la base de datos
            }
            else
            {
                throw new Exception("Producto no encontrado.");
            }
        }
        public async Task<List<object>> GetAllProductsFilters(string name)
        {
            var objectList = await _context.Product
                .Include(p => p.Category)  // Asegúrate de incluir la categoría
                .Where(p => p.name.ToLower().Contains(name.ToLower())) // Filtrar por nombre
                .Select(p => new
                {
                    p.idProduct,                          // ID del producto
                    p.name,                               // Nombre del producto
                    p.price,                              // Precio del producto
                    p.stock,                              // Stock del producto
                    CategoryName = p.Category.name        // Nombre de la categoría
                })
                .ToListAsync();
            // Convertir la lista de tipos anónimos a una lista de objetos
            List<object> result = objectList.Cast<object>().ToList();
            return result;
        }

        public async Task<List<object>> GetDataGridView()
        {
            var objectList = await _context.Product
                .Include(p => p.Category)  // Asegúrate de incluir la categoría
                .Select(p => new
                {
                    p.idProduct,                          // ID del producto
                    p.name,                               // Nombre del producto
                    p.price,                              // Precio del producto
                    p.stock,                              // Stock del producto
                    CategoryName = p.Category.name        // Nombre de la categoría
                })
                .ToListAsync();
            // Convertir la lista de tipos anónimos a una lista de objetos
            List<object> result = objectList.Cast<object>().ToList();
            return result;
        }

        public async Task<List<string>> Autocomplete(string name)
        {
            return await _context.Product
                .Where(p => EF.Functions.Like(p.name, $"%{name}%"))
                .Select(p => p.name)
                .ToListAsync();
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await _context.Product
                 .FirstOrDefaultAsync(p => p.name.ToLower() == name.ToLower());
        }

    }

}
