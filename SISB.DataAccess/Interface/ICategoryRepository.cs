using SISB.Entities;

namespace SISB.DataAccess.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task<bool> ExistsAsync(string name, int? excludeId = null);

        Task AddAsync(Category category);

        Task UpdateAsync(Category category);

        Task<bool> HasSubCategoriesAsync(int id);
    }
}