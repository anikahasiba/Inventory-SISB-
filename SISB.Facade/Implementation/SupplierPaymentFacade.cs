using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class SupplierPaymentFacade : ISupplierPaymentFacade
    {
        private readonly ISupplierPaymentRepository _supplierPaymentRepository;

        public SupplierPaymentFacade(ISupplierPaymentRepository supplierPaymentRepository)
        {
            _supplierPaymentRepository = supplierPaymentRepository;
        }

        public async Task<List<SupplierPayment>> GetSupplierPaymentsAsync()
        {
            return await _supplierPaymentRepository.GetAllAsync();
        }

        public async Task<SupplierPayment?> GetSupplierPaymentByIdAsync(int id)
        {
            return await _supplierPaymentRepository.GetByIdAsync(id);
        }

        public async Task AddSupplierPaymentAsync(SupplierPayment supplierPayment)
        {
            ArgumentNullException.ThrowIfNull(supplierPayment);
            await _supplierPaymentRepository.AddAsync(supplierPayment);
        }

        public async Task<bool> UpdateSupplierPaymentAsync(SupplierPayment supplierPayment)
        {
            ArgumentNullException.ThrowIfNull(supplierPayment);

            var existing = await _supplierPaymentRepository.GetByIdAsync(supplierPayment.SupplierPaymentId);
            if (existing == null)
                return false;

            await _supplierPaymentRepository.UpdateAsync(supplierPayment);
            return true;
        }

        public async Task<bool> DeleteSupplierPaymentAsync(int id)
        {
            var existing = await _supplierPaymentRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _supplierPaymentRepository.DeleteAsync(id);
            return true;
        }
    }
}
