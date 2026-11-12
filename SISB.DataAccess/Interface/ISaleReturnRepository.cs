using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface ISaleReturnRepository
    {
        Task<List<SaleReturn>> GetAllAsync();
        Task<SaleReturn?> GetByIdAsync(int id);
        Task AddAsync(SaleReturn saleReturn);
        Task UpdateAsync(SaleReturn saleReturn);
        Task DeleteAsync(int id);
    }
}
