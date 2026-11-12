using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ISaleItemFacade
    {
        Task<List<SaleItem>> GetSaleItemsAsync();
        Task<SaleItem?> GetSaleItemByIdAsync(int id);
        Task AddSaleItemAsync(SaleItem saleItem);
        Task<bool> UpdateSaleItemAsync(SaleItem saleItem);
        Task<bool> DeleteSaleItemAsync(int id);
    }
}
