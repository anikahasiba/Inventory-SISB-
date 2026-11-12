using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IStockCountRepository
    {
        Task<List<StockCount>> GetAllAsync();
        Task<StockCount?> GetByIdAsync(int id);
        Task AddAsync(StockCount stockCount);
        Task UpdateAsync(StockCount stockCount);
        Task DeleteAsync(int id);
    }
}
