using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IStockMovementRepository
    {
        Task<List<StockMovement>> GetAllAsync();
        Task<StockMovement?> GetByIdAsync(int id);
        Task AddAsync(StockMovement stockMovement);
        Task UpdateAsync(StockMovement stockMovement);
        Task DeleteAsync(int id);
    }
}
