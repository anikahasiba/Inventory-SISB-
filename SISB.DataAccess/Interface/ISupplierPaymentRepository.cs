using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface ISupplierPaymentRepository
    {
        Task<List<SupplierPayment>> GetAllAsync();
        Task<SupplierPayment?> GetByIdAsync(int id);
        Task AddAsync(SupplierPayment supplierPayment);
        Task UpdateAsync(SupplierPayment supplierPayment);
        Task DeleteAsync(int id);
    }
}
