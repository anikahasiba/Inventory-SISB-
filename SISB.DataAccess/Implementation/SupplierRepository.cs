using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _dbContext.Suppliers
                .OrderByDescending(x => x.SupplierId)
                .ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _dbContext.Suppliers.FindAsync(id);
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _dbContext.Suppliers.Update(supplier);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _dbContext.Suppliers.FindAsync(id);

            if (supplier == null)
                return;

            _dbContext.Suppliers.Remove(supplier);
            await _dbContext.SaveChangesAsync();
        }
    }
}
