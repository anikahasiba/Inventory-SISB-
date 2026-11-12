using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class GoodsReceiptRepository : IGoodsReceiptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GoodsReceiptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GoodsReceipt>> GetAllAsync()
        {
            return await _dbContext.GoodsReceipts
                .OrderByDescending(x => x.GoodsReceiptId)
                .ToListAsync();
        }

        public async Task<GoodsReceipt?> GetByIdAsync(int id)
        {
            return await _dbContext.GoodsReceipts.FindAsync(id);
        }

        public async Task AddAsync(GoodsReceipt goodsReceipt)
        {
            await _dbContext.GoodsReceipts.AddAsync(goodsReceipt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(GoodsReceipt goodsReceipt)
        {
            _dbContext.GoodsReceipts.Update(goodsReceipt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var goodsReceipt = await _dbContext.GoodsReceipts.FindAsync(id);

            if (goodsReceipt == null)
                return;

            _dbContext.GoodsReceipts.Remove(goodsReceipt);
            await _dbContext.SaveChangesAsync();
        }
    }
}
