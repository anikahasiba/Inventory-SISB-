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

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);
            await _customerRepository.AddAsync(customer);
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            var existing = await _customerRepository.GetByIdAsync(customer.CustomerId);
            if (existing == null)
                return false;

            await _customerRepository.UpdateAsync(customer);
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var existing = await _customerRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _customerRepository.DeleteAsync(id);
            return true;
        }
    }
}
