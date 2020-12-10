using BlazorServerShoppingCart.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Category> AddCategory(Category newCategory)
        {
            var category = await _appDbContext.AddAsync(newCategory);
            await _appDbContext.SaveChangesAsync();
            return category.Entity;
        }

        public async Task<Category> DeleteCategory(string categoryId)
        {
            //Find the category to delete
            var category =  await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if(category != null)
            {
                _appDbContext.Categories.Remove(category);
                await _appDbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(string categoryId)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task<Category> UpdateCategory(Category updatedCategory)
        {
            var category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == updatedCategory.CategoryId);
            if (category != null)
            {
                //Update category with the incoming updatedCategory object
                category.ShortName = updatedCategory.ShortName;
                category.LongName = updatedCategory.LongName;
                await _appDbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
