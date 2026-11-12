using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class StockCountRepository : IStockCountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockCountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StockCount>> GetAllAsync()
        {
            return await _dbContext.StockCounts
                .OrderByDescending(x => x.StockCountId)
                .ToListAsync();
        }

        public async Task<StockCount?> GetByIdAsync(int id)
        {
            return await _dbContext.StockCounts.FindAsync(id);
        }

        public async Task AddAsync(StockCount stockCount)
        {
            await _dbContext.StockCounts.AddAsync(stockCount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockCount stockCount)
        {
            _dbContext.StockCounts.Update(stockCount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stockCount = await _dbContext.StockCounts.FindAsync(id);

            if (stockCount == null)
                return;

            _dbContext.StockCounts.Remove(stockCount);
            await _dbContext.SaveChangesAsync();
        }
    }
}
