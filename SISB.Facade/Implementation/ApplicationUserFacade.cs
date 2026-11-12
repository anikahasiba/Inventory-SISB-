using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class ApplicationUserFacade : IApplicationUserFacade
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserFacade(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<List<ApplicationUser>> GetApplicationUsersAsync()
        {
            return await _applicationUserRepository.GetAllAsync();
        }

        public async Task<ApplicationUser?> GetApplicationUserByIdAsync(string id)
        {
            return await _applicationUserRepository.GetByIdAsync(id);
        }

        public async Task AddApplicationUserAsync(ApplicationUser applicationUser)
        {
            ArgumentNullException.ThrowIfNull(applicationUser);
            await _applicationUserRepository.AddAsync(applicationUser);
        }

        public async Task<bool> UpdateApplicationUserAsync(ApplicationUser applicationUser)
        {
            ArgumentNullException.ThrowIfNull(applicationUser);

            var existing = await _applicationUserRepository.GetByIdAsync(applicationUser.Id);
            if (existing == null)
                return false;

            await _applicationUserRepository.UpdateAsync(applicationUser);
            return true;
        }

        public async Task<bool> DeleteApplicationUserAsync(string id)
        {
            var existing = await _applicationUserRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _applicationUserRepository.DeleteAsync(id);
            return true;
        }
    }
}
