using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class CustomerPaymentRepository : ICustomerPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerPaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CustomerPayment>> GetAllAsync()
        {
            return await _dbContext.CustomerPayments
                .OrderByDescending(x => x.CustomerPaymentId)
                .ToListAsync();
        }

        public async Task<CustomerPayment?> GetByIdAsync(int id)
        {
            return await _dbContext.CustomerPayments.FindAsync(id);
        }

        public async Task AddAsync(CustomerPayment customerPayment)
        {
            await _dbContext.CustomerPayments.AddAsync(customerPayment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerPayment customerPayment)
        {
            _dbContext.CustomerPayments.Update(customerPayment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customerPayment = await _dbContext.CustomerPayments.FindAsync(id);

            if (customerPayment == null)
                return;

            _dbContext.CustomerPayments.Remove(customerPayment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
