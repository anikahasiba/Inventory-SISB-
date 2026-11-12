using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IGoodsReceiptRepository
    {
        Task<List<GoodsReceipt>> GetAllAsync();
        Task<GoodsReceipt?> GetByIdAsync(int id);
        Task AddAsync(GoodsReceipt goodsReceipt);
        Task UpdateAsync(GoodsReceipt goodsReceipt);
        Task DeleteAsync(int id);
    }
}
