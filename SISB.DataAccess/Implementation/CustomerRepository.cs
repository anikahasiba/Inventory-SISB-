using Microsoft.EntityFrameworkCore;
using SISB.DataAccess;
using SISB.DataAccess.Interface;
using SISB.Entities;

namespace SISB.DataAccess.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // READ ALL CUSTOMERS
        // =========================
        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        // =========================
        // READ CUSTOMER BY ID
        // =========================
        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        // =========================
        // ADD CUSTOMER
        // =========================
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);

            await _context.SaveChangesAsync();
        }

        // =========================
        // UPDATE CUSTOMER
        // =========================
        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId);

            if (existingCustomer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }

            existingCustomer.Name = customer.Name.Trim();
            existingCustomer.Phone = customer.Phone?.Trim();
            existingCustomer.Email = customer.Email?.Trim();
            existingCustomer.Address = customer.Address?.Trim();
            existingCustomer.CreditLimit = customer.CreditLimit;
            existingCustomer.IsActive = customer.IsActive;

            // DueBalance is intentionally not updated here.

            await _context.SaveChangesAsync();
        }

        // =========================
        // DELETE CUSTOMER
        // =========================
        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return;

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
        }
    }
}