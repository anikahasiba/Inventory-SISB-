using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ISaleReturnItemFacade
    {
        Task<List<SaleReturnItem>> GetSaleReturnItemsAsync();
        Task<SaleReturnItem?> GetSaleReturnItemByIdAsync(int id);
        Task AddSaleReturnItemAsync(SaleReturnItem saleReturnItem);
        Task<bool> UpdateSaleReturnItemAsync(SaleReturnItem saleReturnItem);
        Task<bool> DeleteSaleReturnItemAsync(int id);
    }
}
