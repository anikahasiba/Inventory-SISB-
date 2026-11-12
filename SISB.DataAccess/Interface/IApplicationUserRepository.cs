using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IApplicationUserRepository
    {
        Task<List<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser?> GetByIdAsync(string id);
        Task AddAsync(ApplicationUser applicationUser);
        Task UpdateAsync(ApplicationUser applicationUser);
        Task DeleteAsync(string id);
    }
}
