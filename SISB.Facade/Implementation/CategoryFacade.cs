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

        // READ ALL
        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        // READ SINGLE
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        // ADD
        public async Task<bool> AddAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                return false;

            category.Name = category.Name.Trim();

            // Duplicate check
            if (await _categoryRepository.ExistsAsync(category.Name))
                return false;

            // Validate parent category
            if (category.ParentCategoryId.HasValue)
            {
                var parent = await _categoryRepository.GetByIdAsync(
                    category.ParentCategoryId.Value);

                if (parent == null)
                    return false;

                // Only one subcategory level allowed
                if (parent.ParentCategoryId.HasValue)
                    return false;
            }

            await _categoryRepository.AddAsync(category);

            return true;
        }

        // EDIT
        public async Task<bool> UpdateAsync(Category category)
        {
            if (category.CategoryId <= 0 ||
                string.IsNullOrWhiteSpace(category.Name))
                return false;

            var existing = await _categoryRepository.GetByIdAsync(
                category.CategoryId);

            if (existing == null)
                return false;

            category.Name = category.Name.Trim();

            // Duplicate check excluding current category
            if (await _categoryRepository.ExistsAsync(
                category.Name,
                category.CategoryId))
                return false;

            if (category.ParentCategoryId.HasValue)
            {
                // Cannot select itself as parent
                if (category.ParentCategoryId.Value == category.CategoryId)
                    return false;

                var parent = await _categoryRepository.GetByIdAsync(
                    category.ParentCategoryId.Value);

                if (parent == null)
                    return false;

                // Parent must be a main category
                if (parent.ParentCategoryId.HasValue)
                    return false;

                // Category with children cannot become a subcategory
                if (await _categoryRepository.HasSubCategoriesAsync(
                    category.CategoryId))
                    return false;
            }

            await _categoryRepository.UpdateAsync(category);

            return true;
        }
    }
}