using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(int id);
    }
}
