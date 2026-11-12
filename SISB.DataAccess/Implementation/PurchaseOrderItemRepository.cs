using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class PurchaseOrderItemRepository : IPurchaseOrderItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseOrderItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurchaseOrderItem>> GetAllAsync()
        {
            return await _dbContext.PurchaseOrderItems
                .OrderByDescending(x => x.PurchaseOrderItemId)
                .ToListAsync();
        }

        public async Task<PurchaseOrderItem?> GetByIdAsync(int id)
        {
            return await _dbContext.PurchaseOrderItems.FindAsync(id);
        }

        public async Task AddAsync(PurchaseOrderItem purchaseOrderItem)
        {
            await _dbContext.PurchaseOrderItems.AddAsync(purchaseOrderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseOrderItem purchaseOrderItem)
        {
            _dbContext.PurchaseOrderItems.Update(purchaseOrderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var purchaseOrderItem = await _dbContext.PurchaseOrderItems.FindAsync(id);

            if (purchaseOrderItem == null)
                return;

            _dbContext.PurchaseOrderItems.Remove(purchaseOrderItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
