using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _dbContext.Sales
                .OrderByDescending(x => x.SaleId)
                .ToListAsync();
        }

        public async Task<Sale?> GetByIdAsync(int id)
        {
            return await _dbContext.Sales.FindAsync(id);
        }

        public async Task AddAsync(Sale sale)
        {
            await _dbContext.Sales.AddAsync(sale);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _dbContext.Sales.Update(sale);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sale = await _dbContext.Sales.FindAsync(id);

            if (sale == null)
                return;

            _dbContext.Sales.Remove(sale);
            await _dbContext.SaveChangesAsync();
        }
    }
}
