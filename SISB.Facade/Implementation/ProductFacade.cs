using Microsoft.EntityFrameworkCore;
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

            var existingProduct = product;

            if (existingProduct == null)
                return false;

            existingProduct.Name = product.Name;
            existingProduct.SKU = product.SKU;
            existingProduct.Barcode = product.Barcode;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.PreferredSupplierId = product.PreferredSupplierId;
            existingProduct.Unit = product.Unit;
            existingProduct.PurchasePrice = product.PurchasePrice;
            existingProduct.SellingPrice = product.SellingPrice;
            existingProduct.ReorderLevel = product.ReorderLevel;
            existingProduct.IsExpiryTracked = product.IsExpiryTracked;
            existingProduct.IsActive = product.IsActive;
            existingProduct.ImageUrl = product.ImageUrl;
            await _productRepository.UpdateAsync(existingProduct);
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
        public async Task<bool> IsSkuExistsAsync(string sku)
        {
            bool flag = await _productRepository.IsSkuExistsAsync(sku);
            if (!flag)
                return false;

            return await _productRepository.IsSkuExistsAsync(sku.Trim());
        }
    }
}
