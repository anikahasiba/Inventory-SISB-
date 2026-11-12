using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface ISaleReturnItemRepository
    {
        Task<List<SaleReturnItem>> GetAllAsync();
        Task<SaleReturnItem?> GetByIdAsync(int id);
        Task AddAsync(SaleReturnItem saleReturnItem);
        Task UpdateAsync(SaleReturnItem saleReturnItem);
        Task DeleteAsync(int id);
    }
}
