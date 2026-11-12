using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class ProductBatchFacade : IProductBatchFacade
    {
        private readonly IProductBatchRepository _productBatchRepository;

        public ProductBatchFacade(IProductBatchRepository productBatchRepository)
        {
            _productBatchRepository = productBatchRepository;
        }

        public async Task<List<ProductBatch>> GetProductBatchsAsync()
        {
            return await _productBatchRepository.GetAllAsync();
        }

        public async Task<ProductBatch?> GetProductBatchByIdAsync(int id)
        {
            return await _productBatchRepository.GetByIdAsync(id);
        }

        public async Task AddProductBatchAsync(ProductBatch productBatch)
        {
            ArgumentNullException.ThrowIfNull(productBatch);
            await _productBatchRepository.AddAsync(productBatch);
        }

        public async Task<bool> UpdateProductBatchAsync(ProductBatch productBatch)
        {
            ArgumentNullException.ThrowIfNull(productBatch);

            var existing = await _productBatchRepository.GetByIdAsync(productBatch.ProductBatchId);
            if (existing == null)
                return false;

            await _productBatchRepository.UpdateAsync(productBatch);
            return true;
        }

        public async Task<bool> DeleteProductBatchAsync(int id)
        {
            var existing = await _productBatchRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _productBatchRepository.DeleteAsync(id);
            return true;
        }
    }
}
