using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface ISaleItemRepository
    {
        Task<List<SaleItem>> GetAllAsync();
        Task<SaleItem?> GetByIdAsync(int id);
        Task AddAsync(SaleItem saleItem);
        Task UpdateAsync(SaleItem saleItem);
        Task DeleteAsync(int id);
    }
}
