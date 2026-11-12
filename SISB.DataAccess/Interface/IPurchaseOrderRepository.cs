using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IPurchaseOrderRepository
    {
        Task<List<PurchaseOrder>> GetAllAsync();
        Task<PurchaseOrder?> GetByIdAsync(int id);
        Task AddAsync(PurchaseOrder purchaseOrder);
        Task UpdateAsync(PurchaseOrder purchaseOrder);
        Task DeleteAsync(int id);
    }
}
