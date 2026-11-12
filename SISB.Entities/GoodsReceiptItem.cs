using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class GoodsReceiptItem
    {
        [Key]
        public int GoodsReceiptItemId { get; set; }

        public int GoodsReceiptId { get; set; }
        public int PurchaseOrderItemId { get; set; }
        public int ProductId { get; set; }
        public int? ProductBatchId { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal QuantityReceived { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitCost { get; set; }

        [ForeignKey(nameof(GoodsReceiptId))]
        public virtual GoodsReceipt GoodsReceipt { get; set; } = null!;
        [ForeignKey(nameof(PurchaseOrderItemId))]
        public virtual PurchaseOrderItem PurchaseOrderItem { get; set; } = null!;
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
        [ForeignKey(nameof(ProductBatchId))]
        public virtual ProductBatch? ProductBatch { get; set; }
    }
}
