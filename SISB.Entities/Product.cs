using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string SKU { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Barcode { get; set; }

        public int CategoryId { get; set; }
        public int? PreferredSupplierId { get; set; }

        [Required, StringLength(30)]
        public string Unit { get; set; } = "pcs";

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal WAC { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal ReorderLevel { get; set; }

        public bool IsExpiryTracked { get; set; } = false;
        public bool IsActive { get; set; } = true;

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        [ForeignKey(nameof(PreferredSupplierId))]
        public virtual Supplier? PreferredSupplier { get; set; }

        public virtual ICollection<ProductBatch> Batches { get; set; } = new List<ProductBatch>();
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
        public virtual ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
        public virtual ICollection<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();
        public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
        public virtual ICollection<ForecastResult> ForecastResults { get; set; } = new List<ForecastResult>();
        public virtual ICollection<ReorderSuggestion> ReorderSuggestions { get; set; } = new List<ReorderSuggestion>();
        public virtual ICollection<GoodsReceiptItem> GoodsReceiptItems { get; set; } = new List<GoodsReceiptItem>();
        public virtual ICollection<SaleReturnItem> SaleReturnItems { get; set; } = new List<SaleReturnItem>();
        public virtual ICollection<StockCountItem> StockCountItems { get; set; } = new List<StockCountItem>();
    }
}
