using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
}
