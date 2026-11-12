using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IStockAdjustmentRepository
    {
        Task<List<StockAdjustment>> GetAllAsync();
        Task<StockAdjustment?> GetByIdAsync(int id);
        Task AddAsync(StockAdjustment stockAdjustment);
        Task UpdateAsync(StockAdjustment stockAdjustment);
        Task DeleteAsync(int id);
    }
}
