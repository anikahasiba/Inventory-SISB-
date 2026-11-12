using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class SaleReturnRepository : ISaleReturnRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleReturnRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SaleReturn>> GetAllAsync()
        {
            return await _dbContext.SaleReturns
                .OrderByDescending(x => x.SaleReturnId)
                .ToListAsync();
        }

        public async Task<SaleReturn?> GetByIdAsync(int id)
        {
            return await _dbContext.SaleReturns.FindAsync(id);
        }

        public async Task AddAsync(SaleReturn saleReturn)
        {
            await _dbContext.SaleReturns.AddAsync(saleReturn);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SaleReturn saleReturn)
        {
            _dbContext.SaleReturns.Update(saleReturn);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var saleReturn = await _dbContext.SaleReturns.FindAsync(id);

            if (saleReturn == null)
                return;

            _dbContext.SaleReturns.Remove(saleReturn);
            await _dbContext.SaveChangesAsync();
        }
    }
}
