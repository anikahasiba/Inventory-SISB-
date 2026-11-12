using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IPurchaseOrderItemRepository
    {
        Task<List<PurchaseOrderItem>> GetAllAsync();
        Task<PurchaseOrderItem?> GetByIdAsync(int id);
        Task AddAsync(PurchaseOrderItem purchaseOrderItem);
        Task UpdateAsync(PurchaseOrderItem purchaseOrderItem);
        Task DeleteAsync(int id);
    }
}
