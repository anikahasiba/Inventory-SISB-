using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IPurchaseOrderFacade
    {
        Task<List<PurchaseOrder>> GetPurchaseOrdersAsync();
        Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(int id);
        Task AddPurchaseOrderAsync(PurchaseOrder purchaseOrder);
        Task<bool> UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder);
        Task<bool> DeletePurchaseOrderAsync(int id);
    }
}
