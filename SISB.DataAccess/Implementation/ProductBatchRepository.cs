using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class ProductBatchRepository : IProductBatchRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductBatchRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductBatch>> GetAllAsync()
        {
            return await _dbContext.ProductBatches
                .OrderByDescending(x => x.ProductBatchId)
                .ToListAsync();
        }

        public async Task<ProductBatch?> GetByIdAsync(int id)
        {
            return await _dbContext.ProductBatches.FindAsync(id);
        }

        public async Task AddAsync(ProductBatch productBatch)
        {
            await _dbContext.ProductBatches.AddAsync(productBatch);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductBatch productBatch)
        {
            _dbContext.ProductBatches.Update(productBatch);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productBatch = await _dbContext.ProductBatches.FindAsync(id);

            if (productBatch == null)
                return;

            _dbContext.ProductBatches.Remove(productBatch);
            await _dbContext.SaveChangesAsync();
        }
    }
}
