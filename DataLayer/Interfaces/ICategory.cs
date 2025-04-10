using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetCategories();
        Task<string> GetCategory(string name);
        Task<string> GetCategoryComboBox(int id);
        Task<string> DeleteCategory(int id);
        Task<Category> GetCategoryObjectCompleted(int id);
        Task<string> AddCategory(Category category);
    }
}
