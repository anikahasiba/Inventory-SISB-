using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryFacade(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);
            await _categoryRepository.AddAsync(category);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);

            var existing = await _categoryRepository.GetByIdAsync(category.CategoryId);
            if (existing == null)
                return false;

            await _categoryRepository.UpdateAsync(category);
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var existing = await _categoryRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _categoryRepository.DeleteAsync(id);
            return true;
        }
    }
}
