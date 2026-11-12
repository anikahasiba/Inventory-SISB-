using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class StockCountFacade : IStockCountFacade
    {
        private readonly IStockCountRepository _stockCountRepository;

        public StockCountFacade(IStockCountRepository stockCountRepository)
        {
            _stockCountRepository = stockCountRepository;
        }

        public async Task<List<StockCount>> GetStockCountsAsync()
        {
            return await _stockCountRepository.GetAllAsync();
        }

        public async Task<StockCount?> GetStockCountByIdAsync(int id)
        {
            return await _stockCountRepository.GetByIdAsync(id);
        }

        public async Task AddStockCountAsync(StockCount stockCount)
        {
            ArgumentNullException.ThrowIfNull(stockCount);
            await _stockCountRepository.AddAsync(stockCount);
        }

        public async Task<bool> UpdateStockCountAsync(StockCount stockCount)
        {
            ArgumentNullException.ThrowIfNull(stockCount);

            var existing = await _stockCountRepository.GetByIdAsync(stockCount.StockCountId);
            if (existing == null)
                return false;

            await _stockCountRepository.UpdateAsync(stockCount);
            return true;
        }

        public async Task<bool> DeleteStockCountAsync(int id)
        {
            var existing = await _stockCountRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _stockCountRepository.DeleteAsync(id);
            return true;
        }
    }
}
