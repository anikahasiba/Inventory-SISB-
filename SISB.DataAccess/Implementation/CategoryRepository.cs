using Microsoft.EntityFrameworkCore;
using SISB.DataAccess.Interface;
using SISB.Entities;

namespace SISB.DataAccess.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ ALL
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Include(c => c.ParentCategory)
                .Include(c => c.SubCategories)
                .Include(c => c.Products)
                .OrderBy(c => c.CategoryId)
                .ToListAsync();
        }

        // READ SINGLE
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        // CHECK DUPLICATE NAME
        public async Task<bool> ExistsAsync(
            string name,
            int? excludeId = null)
        {
            name = name.Trim();

            return await _context.Categories.AnyAsync(c =>
                c.Name == name &&
                (!excludeId.HasValue ||
                 c.CategoryId != excludeId.Value));
        }

        // ADD
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        // EDIT
        public async Task UpdateAsync(Category category)
        {
            var existing = await _context.Categories
                .FirstOrDefaultAsync(c =>
                    c.CategoryId == category.CategoryId);

            if (existing == null)
                throw new KeyNotFoundException("Category not found.");

            existing.Name = category.Name.Trim();
            existing.ParentCategoryId = category.ParentCategoryId;

            await _context.SaveChangesAsync();
        }

        // CHECK CHILD CATEGORY
        public async Task<bool> HasSubCategoriesAsync(int id)
        {
            return await _context.Categories
                .AnyAsync(c => c.ParentCategoryId == id);
        }
    }
}