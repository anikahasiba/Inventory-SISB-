using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class PurchaseOrderFacade : IPurchaseOrderFacade
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderFacade(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<List<PurchaseOrder>> GetPurchaseOrdersAsync()
        {
            return await _purchaseOrderRepository.GetAllAsync();
        }

        public async Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(int id)
        {
            return await _purchaseOrderRepository.GetByIdAsync(id);
        }

        public async Task AddPurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrder);
            await _purchaseOrderRepository.AddAsync(purchaseOrder);
        }

        public async Task<bool> UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrder);

            var existing = await _purchaseOrderRepository.GetByIdAsync(purchaseOrder.PurchaseOrderId);
            if (existing == null)
                return false;

            await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
            return true;
        }

        public async Task<bool> DeletePurchaseOrderAsync(int id)
        {
            var existing = await _purchaseOrderRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _purchaseOrderRepository.DeleteAsync(id);
            return true;
        }
    }
}
