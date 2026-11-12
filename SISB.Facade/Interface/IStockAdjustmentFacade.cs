using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IStockAdjustmentFacade
    {
        Task<List<StockAdjustment>> GetStockAdjustmentsAsync();
        Task<StockAdjustment?> GetStockAdjustmentByIdAsync(int id);
        Task AddStockAdjustmentAsync(StockAdjustment stockAdjustment);
        Task<bool> UpdateStockAdjustmentAsync(StockAdjustment stockAdjustment);
        Task<bool> DeleteStockAdjustmentAsync(int id);
    }
}
