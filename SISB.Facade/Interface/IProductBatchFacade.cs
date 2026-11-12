using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IProductBatchFacade
    {
        Task<List<ProductBatch>> GetProductBatchsAsync();
        Task<ProductBatch?> GetProductBatchByIdAsync(int id);
        Task AddProductBatchAsync(ProductBatch productBatch);
        Task<bool> UpdateProductBatchAsync(ProductBatch productBatch);
        Task<bool> DeleteProductBatchAsync(int id);
    }
}
