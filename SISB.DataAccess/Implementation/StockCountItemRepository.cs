using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class StockCountItemRepository : IStockCountItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockCountItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StockCountItem>> GetAllAsync()
        {
            return await _dbContext.StockCountItems
                .OrderByDescending(x => x.StockCountItemId)
                .ToListAsync();
        }

        public async Task<StockCountItem?> GetByIdAsync(int id)
        {
            return await _dbContext.StockCountItems.FindAsync(id);
        }

        public async Task AddAsync(StockCountItem stockCountItem)
        {
            await _dbContext.StockCountItems.AddAsync(stockCountItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockCountItem stockCountItem)
        {
            _dbContext.StockCountItems.Update(stockCountItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stockCountItem = await _dbContext.StockCountItems.FindAsync(id);

            if (stockCountItem == null)
                return;

            _dbContext.StockCountItems.Remove(stockCountItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
