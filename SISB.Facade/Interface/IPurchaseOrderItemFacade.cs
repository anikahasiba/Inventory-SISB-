using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IPurchaseOrderItemFacade
    {
        Task<List<PurchaseOrderItem>> GetPurchaseOrderItemsAsync();
        Task<PurchaseOrderItem?> GetPurchaseOrderItemByIdAsync(int id);
        Task AddPurchaseOrderItemAsync(PurchaseOrderItem purchaseOrderItem);
        Task<bool> UpdatePurchaseOrderItemAsync(PurchaseOrderItem purchaseOrderItem);
        Task<bool> DeletePurchaseOrderItemAsync(int id);
    }
}
