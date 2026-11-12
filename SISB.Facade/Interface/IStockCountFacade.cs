using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IStockCountFacade
    {
        Task<List<StockCount>> GetStockCountsAsync();
        Task<StockCount?> GetStockCountByIdAsync(int id);
        Task AddStockCountAsync(StockCount stockCount);
        Task<bool> UpdateStockCountAsync(StockCount stockCount);
        Task<bool> DeleteStockCountAsync(int id);
    }
}
