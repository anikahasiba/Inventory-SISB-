using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IStockCountItemRepository
    {
        Task<List<StockCountItem>> GetAllAsync();
        Task<StockCountItem?> GetByIdAsync(int id);
        Task AddAsync(StockCountItem stockCountItem);
        Task UpdateAsync(StockCountItem stockCountItem);
        Task DeleteAsync(int id);
    }
}
