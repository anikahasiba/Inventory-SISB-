using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAllAsync();
        Task<Sale?> GetByIdAsync(int id);
        Task AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(int id);
    }
}
