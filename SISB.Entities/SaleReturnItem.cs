using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class SaleReturnItem
    {
        [Key]
        public int SaleReturnItemId { get; set; }

        public int SaleReturnId { get; set; }
        public int SaleItemId { get; set; }
        public int ProductId { get; set; }
        public int? ProductBatchId { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal RefundAmount { get; set; }

        [ForeignKey(nameof(SaleReturnId))]
        public virtual SaleReturn SaleReturn { get; set; } = null!;
        [ForeignKey(nameof(SaleItemId))]
        public virtual SaleItem SaleItem { get; set; } = null!;
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
        [ForeignKey(nameof(ProductBatchId))]
        public virtual ProductBatch? ProductBatch { get; set; }
    }
}
