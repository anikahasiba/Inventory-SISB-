using Microsoft.EntityFrameworkCore;
using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class SupplierFacade : ISupplierFacade
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierFacade(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<Supplier>> GetSuppliersAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int id)
        {
            return await _supplierRepository.GetByIdAsync(id);
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            ArgumentNullException.ThrowIfNull(supplier);
            await _supplierRepository.AddAsync(supplier);
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            var existingSupplier = await _supplierRepository.GetByIdAsync(supplier.SupplierId);

            if (existingSupplier == null)
                return false;

            existingSupplier.Name = supplier.Name;
            existingSupplier.Phone = supplier.Phone;
            existingSupplier.Email = supplier.Email;
            existingSupplier.Address = supplier.Address;
            existingSupplier.PaymentTerms = supplier.PaymentTerms;
            existingSupplier.LeadTimeDays = supplier.LeadTimeDays;
            existingSupplier.IsActive = supplier.IsActive;

            await _supplierRepository.UpdateAsync(existingSupplier);

            return true;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var existing = await _supplierRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _supplierRepository.DeleteAsync(id);
            return true;
        }
    }
}
