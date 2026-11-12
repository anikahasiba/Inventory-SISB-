using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class SupplierPaymentRepository : ISupplierPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierPaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SupplierPayment>> GetAllAsync()
        {
            return await _dbContext.SupplierPayments
                .OrderByDescending(x => x.SupplierPaymentId)
                .ToListAsync();
        }

        public async Task<SupplierPayment?> GetByIdAsync(int id)
        {
            return await _dbContext.SupplierPayments.FindAsync(id);
        }

        public async Task AddAsync(SupplierPayment supplierPayment)
        {
            await _dbContext.SupplierPayments.AddAsync(supplierPayment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupplierPayment supplierPayment)
        {
            _dbContext.SupplierPayments.Update(supplierPayment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplierPayment = await _dbContext.SupplierPayments.FindAsync(id);

            if (supplierPayment == null)
                return;

            _dbContext.SupplierPayments.Remove(supplierPayment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
