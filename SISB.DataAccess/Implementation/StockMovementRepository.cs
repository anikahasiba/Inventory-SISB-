using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockMovementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StockMovement>> GetAllAsync()
        {
            return await _dbContext.StockMovements
                .OrderByDescending(x => x.StockMovementId)
                .ToListAsync();
        }

        public async Task<StockMovement?> GetByIdAsync(int id)
        {
            return await _dbContext.StockMovements.FindAsync(id);
        }

        public async Task AddAsync(StockMovement stockMovement)
        {
            await _dbContext.StockMovements.AddAsync(stockMovement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockMovement stockMovement)
        {
            _dbContext.StockMovements.Update(stockMovement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stockMovement = await _dbContext.StockMovements.FindAsync(id);

            if (stockMovement == null)
                return;

            _dbContext.StockMovements.Remove(stockMovement);
            await _dbContext.SaveChangesAsync();
        }
    }
}
