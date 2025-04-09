using DataLayer.Interfaces;
using DataLayer.Models;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly Db_Context _context;

        public CategoryRepository(Db_Context context)
        {
            _context = context;
        }

        public async Task<string> AddCategory(Category category)
        {
            //verificar si existe primero 
            var existingCategory = await GetCategory(category.name);
            if (existingCategory == null)
            {
                return "Categoria ya existente.";
            }
            else
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                return "";
            }
           
        }

        public Task<List<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<string> GetCategory(string name)
        {
            var result = await _context.Category.FirstOrDefaultAsync(c => c.name.ToLower() == name.ToLower());
            if (result == null)
            {
                return "Error";
            }
            else
            {
                return result.name;
            }
        }
        public async Task<string> GetCategoryComboBox(int id)
        {
            var result = await _context.Category.FirstOrDefaultAsync(c => c.idCategory == id);
            if (result == null)
            {
                return "Categoria no encontrada";
            }
            return result.name;
        }

        public async Task UpdateCategory(Category category)
        {
            {
                var result = await _context.Category.FirstOrDefaultAsync(c => c.idCategory == category.idCategory);

                if (result != null)
                {
                    // Marca la entidad como modificada
                    _context.Entry(result).State = EntityState.Modified;
                    await _context.SaveChangesAsync();  // Guardar los cambios en la base de datos
                }
                else
                {
                    throw new Exception("Producto no encontrado.");
                }
            }
        }
        public async Task<Category> GetCategoryObjectCompleted(int id)
        {
            var result = await _context.Category.FirstOrDefaultAsync(c => c.idCategory == id);
            return result;
        }
        public async Task<string> DeleteCategory(int id)
        {
            var result = await GetCategoryObjectCompleted(id);
            if(result == null)
            {
                return "No se encontro la categoria";
            }
            else
            {
                _context.Category.Remove(result);
                await _context.SaveChangesAsync();
                return "";
            }

        }
    }
}
