using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IGoodsReceiptItemFacade
    {
        Task<List<GoodsReceiptItem>> GetGoodsReceiptItemsAsync();
        Task<GoodsReceiptItem?> GetGoodsReceiptItemByIdAsync(int id);
        Task AddGoodsReceiptItemAsync(GoodsReceiptItem goodsReceiptItem);
        Task<bool> UpdateGoodsReceiptItemAsync(GoodsReceiptItem goodsReceiptItem);
        Task<bool> DeleteGoodsReceiptItemAsync(int id);
    }
}
