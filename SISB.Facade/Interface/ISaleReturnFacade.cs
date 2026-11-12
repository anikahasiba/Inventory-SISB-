using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ISaleReturnFacade
    {
        Task<List<SaleReturn>> GetSaleReturnsAsync();
        Task<SaleReturn?> GetSaleReturnByIdAsync(int id);
        Task AddSaleReturnAsync(SaleReturn saleReturn);
        Task<bool> UpdateSaleReturnAsync(SaleReturn saleReturn);
        Task<bool> DeleteSaleReturnAsync(int id);
    }
}
