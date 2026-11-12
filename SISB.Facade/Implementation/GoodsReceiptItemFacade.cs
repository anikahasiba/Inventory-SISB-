using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class GoodsReceiptItemFacade : IGoodsReceiptItemFacade
    {
        private readonly IGoodsReceiptItemRepository _goodsReceiptItemRepository;

        public GoodsReceiptItemFacade(IGoodsReceiptItemRepository goodsReceiptItemRepository)
        {
            _goodsReceiptItemRepository = goodsReceiptItemRepository;
        }

        public async Task<List<GoodsReceiptItem>> GetGoodsReceiptItemsAsync()
        {
            return await _goodsReceiptItemRepository.GetAllAsync();
        }

        public async Task<GoodsReceiptItem?> GetGoodsReceiptItemByIdAsync(int id)
        {
            return await _goodsReceiptItemRepository.GetByIdAsync(id);
        }

        public async Task AddGoodsReceiptItemAsync(GoodsReceiptItem goodsReceiptItem)
        {
            ArgumentNullException.ThrowIfNull(goodsReceiptItem);
            await _goodsReceiptItemRepository.AddAsync(goodsReceiptItem);
        }

        public async Task<bool> UpdateGoodsReceiptItemAsync(GoodsReceiptItem goodsReceiptItem)
        {
            ArgumentNullException.ThrowIfNull(goodsReceiptItem);

            var existing = await _goodsReceiptItemRepository.GetByIdAsync(goodsReceiptItem.GoodsReceiptItemId);
            if (existing == null)
                return false;

            await _goodsReceiptItemRepository.UpdateAsync(goodsReceiptItem);
            return true;
        }

        public async Task<bool> DeleteGoodsReceiptItemAsync(int id)
        {
            var existing = await _goodsReceiptItemRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _goodsReceiptItemRepository.DeleteAsync(id);
            return true;
        }
    }
}
