using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SaleItem>> GetAllAsync()
        {
            return await _dbContext.SaleItems
                .OrderByDescending(x => x.SaleItemId)
                .ToListAsync();
        }

        public async Task<SaleItem?> GetByIdAsync(int id)
        {
            return await _dbContext.SaleItems.FindAsync(id);
        }

        public async Task AddAsync(SaleItem saleItem)
        {
            await _dbContext.SaleItems.AddAsync(saleItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SaleItem saleItem)
        {
            _dbContext.SaleItems.Update(saleItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var saleItem = await _dbContext.SaleItems.FindAsync(id);

            if (saleItem == null)
                return;

            _dbContext.SaleItems.Remove(saleItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
