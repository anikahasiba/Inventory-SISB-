using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class PurchaseOrderItemFacade : IPurchaseOrderItemFacade
    {
        private readonly IPurchaseOrderItemRepository _purchaseOrderItemRepository;

        public PurchaseOrderItemFacade(IPurchaseOrderItemRepository purchaseOrderItemRepository)
        {
            _purchaseOrderItemRepository = purchaseOrderItemRepository;
        }

        public async Task<List<PurchaseOrderItem>> GetPurchaseOrderItemsAsync()
        {
            return await _purchaseOrderItemRepository.GetAllAsync();
        }

        public async Task<PurchaseOrderItem?> GetPurchaseOrderItemByIdAsync(int id)
        {
            return await _purchaseOrderItemRepository.GetByIdAsync(id);
        }

        public async Task AddPurchaseOrderItemAsync(PurchaseOrderItem purchaseOrderItem)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrderItem);
            await _purchaseOrderItemRepository.AddAsync(purchaseOrderItem);
        }

        public async Task<bool> UpdatePurchaseOrderItemAsync(PurchaseOrderItem purchaseOrderItem)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrderItem);

            var existing = await _purchaseOrderItemRepository.GetByIdAsync(purchaseOrderItem.PurchaseOrderItemId);
            if (existing == null)
                return false;

            await _purchaseOrderItemRepository.UpdateAsync(purchaseOrderItem);
            return true;
        }

        public async Task<bool> DeletePurchaseOrderItemAsync(int id)
        {
            var existing = await _purchaseOrderItemRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _purchaseOrderItemRepository.DeleteAsync(id);
            return true;
        }
    }
}
