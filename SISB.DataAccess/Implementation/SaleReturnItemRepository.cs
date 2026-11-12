using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class SaleReturnItemRepository : ISaleReturnItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleReturnItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SaleReturnItem>> GetAllAsync()
        {
            return await _dbContext.SaleReturnItems
                .OrderByDescending(x => x.SaleReturnItemId)
                .ToListAsync();
        }

        public async Task<SaleReturnItem?> GetByIdAsync(int id)
        {
            return await _dbContext.SaleReturnItems.FindAsync(id);
        }

        public async Task AddAsync(SaleReturnItem saleReturnItem)
        {
            await _dbContext.SaleReturnItems.AddAsync(saleReturnItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SaleReturnItem saleReturnItem)
        {
            _dbContext.SaleReturnItems.Update(saleReturnItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var saleReturnItem = await _dbContext.SaleReturnItems.FindAsync(id);

            if (saleReturnItem == null)
                return;

            _dbContext.SaleReturnItems.Remove(saleReturnItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
