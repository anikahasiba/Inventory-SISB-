using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IAlertRepository
    {
        Task<List<Alert>> GetAllAsync();
        Task<Alert?> GetByIdAsync(int id);
        Task AddAsync(Alert alert);
        Task UpdateAsync(Alert alert);
        Task DeleteAsync(int id);
    }
}
