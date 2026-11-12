using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurchaseOrder>> GetAllAsync()
        {
            return await _dbContext.PurchaseOrders
                .OrderByDescending(x => x.PurchaseOrderId)
                .ToListAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id)
        {
            return await _dbContext.PurchaseOrders.FindAsync(id);
        }

        public async Task AddAsync(PurchaseOrder purchaseOrder)
        {
            await _dbContext.PurchaseOrders.AddAsync(purchaseOrder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseOrder purchaseOrder)
        {
            _dbContext.PurchaseOrders.Update(purchaseOrder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var purchaseOrder = await _dbContext.PurchaseOrders.FindAsync(id);

            if (purchaseOrder == null)
                return;

            _dbContext.PurchaseOrders.Remove(purchaseOrder);
            await _dbContext.SaveChangesAsync();
        }
    }
}
