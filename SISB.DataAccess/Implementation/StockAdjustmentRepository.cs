using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class StockAdjustmentRepository : IStockAdjustmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockAdjustmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StockAdjustment>> GetAllAsync()
        {
            return await _dbContext.StockAdjustments
                .OrderByDescending(x => x.StockAdjustmentId)
                .ToListAsync();
        }

        public async Task<StockAdjustment?> GetByIdAsync(int id)
        {
            return await _dbContext.StockAdjustments.FindAsync(id);
        }

        public async Task AddAsync(StockAdjustment stockAdjustment)
        {
            await _dbContext.StockAdjustments.AddAsync(stockAdjustment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockAdjustment stockAdjustment)
        {
            _dbContext.StockAdjustments.Update(stockAdjustment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stockAdjustment = await _dbContext.StockAdjustments.FindAsync(id);

            if (stockAdjustment == null)
                return;

            _dbContext.StockAdjustments.Remove(stockAdjustment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
