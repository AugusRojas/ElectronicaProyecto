using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly Db_Context context;

        public CategoryRepository(Db_Context context)
        {
            this.context = context;
        }

        public async Task AddCategory(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
        }


        public async Task<List<Category>> GetCategories()
        {
            return await context.Category.ToListAsync();
        }
    }
}
