using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IProductBatchRepository
    {
        Task<List<ProductBatch>> GetAllAsync();
        Task<ProductBatch?> GetByIdAsync(int id);
        Task AddAsync(ProductBatch productBatch);
        Task UpdateAsync(ProductBatch productBatch);
        Task DeleteAsync(int id);
    }
}
