using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ISupplierPaymentFacade
    {
        Task<List<SupplierPayment>> GetSupplierPaymentsAsync();
        Task<SupplierPayment?> GetSupplierPaymentByIdAsync(int id);
        Task AddSupplierPaymentAsync(SupplierPayment supplierPayment);
        Task<bool> UpdateSupplierPaymentAsync(SupplierPayment supplierPayment);
        Task<bool> DeleteSupplierPaymentAsync(int id);
    }
}
