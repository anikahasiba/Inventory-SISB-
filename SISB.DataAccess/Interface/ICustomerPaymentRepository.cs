using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface ICustomerPaymentRepository
    {
        Task<List<CustomerPayment>> GetAllAsync();
        Task<CustomerPayment?> GetByIdAsync(int id);
        Task AddAsync(CustomerPayment customerPayment);
        Task UpdateAsync(CustomerPayment customerPayment);
        Task DeleteAsync(int id);
    }
}
