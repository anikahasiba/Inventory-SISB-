using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class StockAdjustment
    {
        [Key]
        public int StockAdjustmentId { get; set; }

        public int ProductId { get; set; }
        public int? ProductBatchId { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        [Required, StringLength(500)]
        public string Reason { get; set; } = string.Empty;

        public StockAdjustmentStatus Status { get; set; } = StockAdjustmentStatus.Pending;

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        public string? ApprovedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        [ForeignKey(nameof(ProductBatchId))]
        public virtual ProductBatch? ProductBatch { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public virtual ApplicationUser CreatedByUser { get; set; } = null!;

        [ForeignKey(nameof(ApprovedBy))]
        public virtual ApplicationUser? ApprovedByUser { get; set; }
    }
}
