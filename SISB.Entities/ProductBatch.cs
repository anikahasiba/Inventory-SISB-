using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class ProductBatch
    {
        [Key]
        public int ProductBatchId { get; set; }

        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string BatchNo { get; set; } = string.Empty;

        public DateOnly? ExpiryDate { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        public virtual ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
        public virtual ICollection<GoodsReceiptItem> GoodsReceiptItems { get; set; } = new List<GoodsReceiptItem>();
        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
        public virtual ICollection<SaleReturnItem> SaleReturnItems { get; set; } = new List<SaleReturnItem>();
    }
}
