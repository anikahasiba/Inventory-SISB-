using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class CustomerPaymentFacade : ICustomerPaymentFacade
    {
        private readonly ICustomerPaymentRepository _customerPaymentRepository;

        public CustomerPaymentFacade(ICustomerPaymentRepository customerPaymentRepository)
        {
            _customerPaymentRepository = customerPaymentRepository;
        }

        public async Task<List<CustomerPayment>> GetCustomerPaymentsAsync()
        {
            return await _customerPaymentRepository.GetAllAsync();
        }

        public async Task<CustomerPayment?> GetCustomerPaymentByIdAsync(int id)
        {
            return await _customerPaymentRepository.GetByIdAsync(id);
        }

        public async Task AddCustomerPaymentAsync(CustomerPayment customerPayment)
        {
            ArgumentNullException.ThrowIfNull(customerPayment);
            await _customerPaymentRepository.AddAsync(customerPayment);
        }

        public async Task<bool> UpdateCustomerPaymentAsync(CustomerPayment customerPayment)
        {
            ArgumentNullException.ThrowIfNull(customerPayment);

            var existing = await _customerPaymentRepository.GetByIdAsync(customerPayment.CustomerPaymentId);
            if (existing == null)
                return false;

            await _customerPaymentRepository.UpdateAsync(customerPayment);
            return true;
        }

        public async Task<bool> DeleteCustomerPaymentAsync(int id)
        {
            var existing = await _customerPaymentRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _customerPaymentRepository.DeleteAsync(id);
            return true;
        }
    }
}
