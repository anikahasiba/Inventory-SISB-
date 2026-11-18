using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerFacade(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // =========================
        // READ ALL CUSTOMERS
        // =========================
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        // =========================
        // READ CUSTOMER BY ID
        // =========================
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _customerRepository.GetByIdAsync(id);
        }

        // =========================
        // ADD CUSTOMER
        // =========================
        public async Task AddCustomerAsync(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                throw new ArgumentException(
                    "Customer name is required.");
            }

            if (customer.CreditLimit < 0)
            {
                throw new ArgumentException(
                    "Credit limit cannot be negative.");
            }

            customer.Name = customer.Name.Trim();
            customer.Phone = customer.Phone?.Trim();
            customer.Email = customer.Email?.Trim();
            customer.Address = customer.Address?.Trim();

            // New customer starts with zero due.
            customer.DueBalance = 0;

            await _customerRepository.AddAsync(customer);
        }

        // =========================
        // UPDATE CUSTOMER
        // =========================
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            if (customer.CustomerId <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(customer.Name))
                return false;

            if (customer.CreditLimit < 0)
                return false;

            var existingCustomer = await _customerRepository
                .GetByIdAsync(customer.CustomerId);

            if (existingCustomer == null)
                return false;

            customer.Name = customer.Name.Trim();
            customer.Phone = customer.Phone?.Trim();
            customer.Email = customer.Email?.Trim();
            customer.Address = customer.Address?.Trim();

            await _customerRepository.UpdateAsync(customer);

            return true;
        }

        // =========================
        // DELETE CUSTOMER
        // =========================
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            if (id <= 0)
                return false;

            var existingCustomer = await _customerRepository
                .GetByIdAsync(id);

            if (existingCustomer == null)
                return false;

            await _customerRepository.DeleteAsync(id);

            return true;
        }
    }
}