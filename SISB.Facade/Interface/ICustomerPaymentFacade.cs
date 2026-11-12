using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ICustomerPaymentFacade
    {
        Task<List<CustomerPayment>> GetCustomerPaymentsAsync();
        Task<CustomerPayment?> GetCustomerPaymentByIdAsync(int id);
        Task AddCustomerPaymentAsync(CustomerPayment customerPayment);
        Task<bool> UpdateCustomerPaymentAsync(CustomerPayment customerPayment);
        Task<bool> DeleteCustomerPaymentAsync(int id);
    }
}
