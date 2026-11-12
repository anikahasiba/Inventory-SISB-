using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class GoodsReceiptFacade : IGoodsReceiptFacade
    {
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public GoodsReceiptFacade(IGoodsReceiptRepository goodsReceiptRepository)
        {
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<List<GoodsReceipt>> GetGoodsReceiptsAsync()
        {
            return await _goodsReceiptRepository.GetAllAsync();
        }

        public async Task<GoodsReceipt?> GetGoodsReceiptByIdAsync(int id)
        {
            return await _goodsReceiptRepository.GetByIdAsync(id);
        }

        public async Task AddGoodsReceiptAsync(GoodsReceipt goodsReceipt)
        {
            ArgumentNullException.ThrowIfNull(goodsReceipt);
            await _goodsReceiptRepository.AddAsync(goodsReceipt);
        }

        public async Task<bool> UpdateGoodsReceiptAsync(GoodsReceipt goodsReceipt)
        {
            ArgumentNullException.ThrowIfNull(goodsReceipt);

            var existing = await _goodsReceiptRepository.GetByIdAsync(goodsReceipt.GoodsReceiptId);
            if (existing == null)
                return false;

            await _goodsReceiptRepository.UpdateAsync(goodsReceipt);
            return true;
        }

        public async Task<bool> DeleteGoodsReceiptAsync(int id)
        {
            var existing = await _goodsReceiptRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _goodsReceiptRepository.DeleteAsync(id);
            return true;
        }
    }
}
