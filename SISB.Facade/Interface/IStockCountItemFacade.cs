using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IStockCountItemFacade
    {
        Task<List<StockCountItem>> GetStockCountItemsAsync();
        Task<StockCountItem?> GetStockCountItemByIdAsync(int id);
        Task AddStockCountItemAsync(StockCountItem stockCountItem);
        Task<bool> UpdateStockCountItemAsync(StockCountItem stockCountItem);
        Task<bool> DeleteStockCountItemAsync(int id);
    }
}
