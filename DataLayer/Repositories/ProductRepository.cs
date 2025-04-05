﻿using DataLayer.Interfaces;
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
        public Task AddProduct(Product product)
        {
            _context.Product.Add(product);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
<<<<<<< HEAD
            var result = await GetProduct(name);
            _context.Product.Remove(result);
=======
            var result = await GetProduct(product.name);
            _context.Products.Remove(result);
>>>>>>> f8647f7fce283195b8606c0230feec1a8ab6b961
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(string name)
        {
<<<<<<< HEAD
            var result = _context.Product.FirstAsync(p=>p.name == id);
=======
            var result = await _context.Products.FirstOrDefaultAsync(p=>p.name == name);
>>>>>>> f8647f7fce283195b8606c0230feec1a8ab6b961
            return result;
        }
        public async Task<List<Product>> GetProducts()
        {
<<<<<<< HEAD
            return await _context.Product.ToListAsync();
            
=======
            return await _context.Products.ToListAsync();
>>>>>>> f8647f7fce283195b8606c0230feec1a8ab6b961
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
<<<<<<< HEAD
            var result = _context.Product.FirstOrDefaultAsync(p => p.name == product.name);
            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();
=======
            var result = await _context.Products.FirstOrDefaultAsync(p => p.name == product.name);

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
            var objectList = await _context.Products
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
            var objectList = await _context.Products
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
>>>>>>> f8647f7fce283195b8606c0230feec1a8ab6b961
        }
    }
}
