using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ICategoryFacade
    {
        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task<bool> AddAsync(Category category);

        Task<bool> UpdateAsync(Category category);
    }
}