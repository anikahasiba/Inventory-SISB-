using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class StockCountItemFacade : IStockCountItemFacade
    {
        private readonly IStockCountItemRepository _stockCountItemRepository;

        public StockCountItemFacade(IStockCountItemRepository stockCountItemRepository)
        {
            _stockCountItemRepository = stockCountItemRepository;
        }

        public async Task<List<StockCountItem>> GetStockCountItemsAsync()
        {
            return await _stockCountItemRepository.GetAllAsync();
        }

        public async Task<StockCountItem?> GetStockCountItemByIdAsync(int id)
        {
            return await _stockCountItemRepository.GetByIdAsync(id);
        }

        public async Task AddStockCountItemAsync(StockCountItem stockCountItem)
        {
            ArgumentNullException.ThrowIfNull(stockCountItem);
            await _stockCountItemRepository.AddAsync(stockCountItem);
        }

        public async Task<bool> UpdateStockCountItemAsync(StockCountItem stockCountItem)
        {
            ArgumentNullException.ThrowIfNull(stockCountItem);

            var existing = await _stockCountItemRepository.GetByIdAsync(stockCountItem.StockCountItemId);
            if (existing == null)
                return false;

            await _stockCountItemRepository.UpdateAsync(stockCountItem);
            return true;
        }

        public async Task<bool> DeleteStockCountItemAsync(int id)
        {
            var existing = await _stockCountItemRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _stockCountItemRepository.DeleteAsync(id);
            return true;
        }
    }
}
