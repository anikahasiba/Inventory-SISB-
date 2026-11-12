using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IGoodsReceiptItemRepository
    {
        Task<List<GoodsReceiptItem>> GetAllAsync();
        Task<GoodsReceiptItem?> GetByIdAsync(int id);
        Task AddAsync(GoodsReceiptItem goodsReceiptItem);
        Task UpdateAsync(GoodsReceiptItem goodsReceiptItem);
        Task DeleteAsync(int id);
    }
}
