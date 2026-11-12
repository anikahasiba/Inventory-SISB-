using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class SaleItemFacade : ISaleItemFacade
    {
        private readonly ISaleItemRepository _saleItemRepository;

        public SaleItemFacade(ISaleItemRepository saleItemRepository)
        {
            _saleItemRepository = saleItemRepository;
        }

        public async Task<List<SaleItem>> GetSaleItemsAsync()
        {
            return await _saleItemRepository.GetAllAsync();
        }

        public async Task<SaleItem?> GetSaleItemByIdAsync(int id)
        {
            return await _saleItemRepository.GetByIdAsync(id);
        }

        public async Task AddSaleItemAsync(SaleItem saleItem)
        {
            ArgumentNullException.ThrowIfNull(saleItem);
            await _saleItemRepository.AddAsync(saleItem);
        }

        public async Task<bool> UpdateSaleItemAsync(SaleItem saleItem)
        {
            ArgumentNullException.ThrowIfNull(saleItem);

            var existing = await _saleItemRepository.GetByIdAsync(saleItem.SaleItemId);
            if (existing == null)
                return false;

            await _saleItemRepository.UpdateAsync(saleItem);
            return true;
        }

        public async Task<bool> DeleteSaleItemAsync(int id)
        {
            var existing = await _saleItemRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _saleItemRepository.DeleteAsync(id);
            return true;
        }
    }
}
