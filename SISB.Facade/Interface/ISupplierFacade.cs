using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ISupplierFacade
    {
        Task<List<Supplier>> GetSuppliersAsync();
        Task<Supplier?> GetSupplierByIdAsync(int id);
        Task AddSupplierAsync(Supplier supplier);
        Task<bool> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
