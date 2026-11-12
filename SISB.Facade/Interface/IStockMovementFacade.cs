using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IStockMovementFacade
    {
        Task<List<StockMovement>> GetStockMovementsAsync();
        Task<StockMovement?> GetStockMovementByIdAsync(int id);
        Task AddStockMovementAsync(StockMovement stockMovement);
        Task<bool> UpdateStockMovementAsync(StockMovement stockMovement);
        Task<bool> DeleteStockMovementAsync(int id);
    }
}
