using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ICustomerFacade
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
