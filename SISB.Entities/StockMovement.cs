using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class StockMovement
    {
        [Key]
        public int StockMovementId { get; set; }

        public int ProductId { get; set; }
        public int? ProductBatchId { get; set; }
        public StockMovementType Type { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; } // Positive adds stock; negative removes stock.

        [StringLength(50)]
        public string? ReferenceType { get; set; }

        public int? ReferenceId { get; set; }

        [StringLength(500)]
        public string? Reason { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        [ForeignKey(nameof(ProductBatchId))]
        public virtual ProductBatch? ProductBatch { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public virtual ApplicationUser CreatedByUser { get; set; } = null!;
    }
}
