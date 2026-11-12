using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IApplicationUserFacade
    {
        Task<List<ApplicationUser>> GetApplicationUsersAsync();
        Task<ApplicationUser?> GetApplicationUserByIdAsync(string id);
        Task AddApplicationUserAsync(ApplicationUser applicationUser);
        Task<bool> UpdateApplicationUserAsync(ApplicationUser applicationUser);
        Task<bool> DeleteApplicationUserAsync(string id);
    }
}
