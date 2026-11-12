using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class StockAdjustmentFacade : IStockAdjustmentFacade
    {
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;

        public StockAdjustmentFacade(IStockAdjustmentRepository stockAdjustmentRepository)
        {
            _stockAdjustmentRepository = stockAdjustmentRepository;
        }

        public async Task<List<StockAdjustment>> GetStockAdjustmentsAsync()
        {
            return await _stockAdjustmentRepository.GetAllAsync();
        }

        public async Task<StockAdjustment?> GetStockAdjustmentByIdAsync(int id)
        {
            return await _stockAdjustmentRepository.GetByIdAsync(id);
        }

        public async Task AddStockAdjustmentAsync(StockAdjustment stockAdjustment)
        {
            ArgumentNullException.ThrowIfNull(stockAdjustment);
            await _stockAdjustmentRepository.AddAsync(stockAdjustment);
        }

        public async Task<bool> UpdateStockAdjustmentAsync(StockAdjustment stockAdjustment)
        {
            ArgumentNullException.ThrowIfNull(stockAdjustment);

            var existing = await _stockAdjustmentRepository.GetByIdAsync(stockAdjustment.StockAdjustmentId);
            if (existing == null)
                return false;

            await _stockAdjustmentRepository.UpdateAsync(stockAdjustment);
            return true;
        }

        public async Task<bool> DeleteStockAdjustmentAsync(int id)
        {
            var existing = await _stockAdjustmentRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _stockAdjustmentRepository.DeleteAsync(id);
            return true;
        }
    }
}
