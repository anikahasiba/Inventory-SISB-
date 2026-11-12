using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class StockMovementFacade : IStockMovementFacade
    {
        private readonly IStockMovementRepository _stockMovementRepository;

        public StockMovementFacade(IStockMovementRepository stockMovementRepository)
        {
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task<List<StockMovement>> GetStockMovementsAsync()
        {
            return await _stockMovementRepository.GetAllAsync();
        }

        public async Task<StockMovement?> GetStockMovementByIdAsync(int id)
        {
            return await _stockMovementRepository.GetByIdAsync(id);
        }

        public async Task AddStockMovementAsync(StockMovement stockMovement)
        {
            ArgumentNullException.ThrowIfNull(stockMovement);
            await _stockMovementRepository.AddAsync(stockMovement);
        }

        public async Task<bool> UpdateStockMovementAsync(StockMovement stockMovement)
        {
            ArgumentNullException.ThrowIfNull(stockMovement);

            var existing = await _stockMovementRepository.GetByIdAsync(stockMovement.StockMovementId);
            if (existing == null)
                return false;

            await _stockMovementRepository.UpdateAsync(stockMovement);
            return true;
        }

        public async Task<bool> DeleteStockMovementAsync(int id)
        {
            var existing = await _stockMovementRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _stockMovementRepository.DeleteAsync(id);
            return true;
        }
    }
}
