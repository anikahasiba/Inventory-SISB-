using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IGoodsReceiptFacade
    {
        Task<List<GoodsReceipt>> GetGoodsReceiptsAsync();
        Task<GoodsReceipt?> GetGoodsReceiptByIdAsync(int id);
        Task AddGoodsReceiptAsync(GoodsReceipt goodsReceipt);
        Task<bool> UpdateGoodsReceiptAsync(GoodsReceipt goodsReceipt);
        Task<bool> DeleteGoodsReceiptAsync(int id);
    }
}
