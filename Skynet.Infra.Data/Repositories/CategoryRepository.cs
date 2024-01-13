using Microsoft.EntityFrameworkCore;
using Skynet.Domain.Entities;
using Skynet.Domain.Interfaces;
using Skynet.Infra.Data.Context;

namespace Skynet.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext;

        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<IEnumerable<Category>> GetCategorysAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
