using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository _productRepository;

        public ProductFacade(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);
            await _productRepository.AddAsync(product);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            var existing = await _productRepository.GetByIdAsync(product.ProductId);
            if (existing == null)
                return false;

            await _productRepository.UpdateAsync(product);
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _productRepository.DeleteAsync(id);
            return true;
        }
    }
}
