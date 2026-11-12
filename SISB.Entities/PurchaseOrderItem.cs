using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class PurchaseOrderItem
    {
        [Key]
        public int PurchaseOrderItemId { get; set; }

        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal QtyOrdered { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal QtyReceived { get; set; } = 0m;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitCost { get; set; }

        [ForeignKey(nameof(PurchaseOrderId))]
        public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        public virtual ICollection<GoodsReceiptItem> GoodsReceiptItems { get; set; } = new List<GoodsReceiptItem>();
    }
}
