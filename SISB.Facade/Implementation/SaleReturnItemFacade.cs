using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class SaleReturnItemFacade : ISaleReturnItemFacade
    {
        private readonly ISaleReturnItemRepository _saleReturnItemRepository;

        public SaleReturnItemFacade(ISaleReturnItemRepository saleReturnItemRepository)
        {
            _saleReturnItemRepository = saleReturnItemRepository;
        }

        public async Task<List<SaleReturnItem>> GetSaleReturnItemsAsync()
        {
            return await _saleReturnItemRepository.GetAllAsync();
        }

        public async Task<SaleReturnItem?> GetSaleReturnItemByIdAsync(int id)
        {
            return await _saleReturnItemRepository.GetByIdAsync(id);
        }

        public async Task AddSaleReturnItemAsync(SaleReturnItem saleReturnItem)
        {
            ArgumentNullException.ThrowIfNull(saleReturnItem);
            await _saleReturnItemRepository.AddAsync(saleReturnItem);
        }

        public async Task<bool> UpdateSaleReturnItemAsync(SaleReturnItem saleReturnItem)
        {
            ArgumentNullException.ThrowIfNull(saleReturnItem);

            var existing = await _saleReturnItemRepository.GetByIdAsync(saleReturnItem.SaleReturnItemId);
            if (existing == null)
                return false;

            await _saleReturnItemRepository.UpdateAsync(saleReturnItem);
            return true;
        }

        public async Task<bool> DeleteSaleReturnItemAsync(int id)
        {
            var existing = await _saleReturnItemRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _saleReturnItemRepository.DeleteAsync(id);
            return true;
        }
    }
}
