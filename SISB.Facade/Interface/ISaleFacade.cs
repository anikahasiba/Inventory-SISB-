using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface ISaleFacade
    {
        Task<List<Sale>> GetSalesAsync();
        Task<Sale?> GetSaleByIdAsync(int id);
        Task AddSaleAsync(Sale sale);
        Task<bool> UpdateSaleAsync(Sale sale);
        Task<bool> DeleteSaleAsync(int id);
    }
}
