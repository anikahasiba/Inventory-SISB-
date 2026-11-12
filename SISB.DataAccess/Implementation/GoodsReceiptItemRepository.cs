using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class GoodsReceiptItemRepository : IGoodsReceiptItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GoodsReceiptItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GoodsReceiptItem>> GetAllAsync()
        {
            return await _dbContext.GoodsReceiptItems
                .OrderByDescending(x => x.GoodsReceiptItemId)
                .ToListAsync();
        }

        public async Task<GoodsReceiptItem?> GetByIdAsync(int id)
        {
            return await _dbContext.GoodsReceiptItems.FindAsync(id);
        }

        public async Task AddAsync(GoodsReceiptItem goodsReceiptItem)
        {
            await _dbContext.GoodsReceiptItems.AddAsync(goodsReceiptItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(GoodsReceiptItem goodsReceiptItem)
        {
            _dbContext.GoodsReceiptItems.Update(goodsReceiptItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var goodsReceiptItem = await _dbContext.GoodsReceiptItems.FindAsync(id);

            if (goodsReceiptItem == null)
                return;

            _dbContext.GoodsReceiptItems.Remove(goodsReceiptItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
