using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class ReorderSuggestion
    {
        [Key]
        public int ReorderSuggestionId { get; set; }

        public int ProductId { get; set; }
        public int? SupplierId { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal SuggestedQty { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal ROP { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DaysOfStockLeft { get; set; }

        public ReorderSuggestionStatus Status { get; set; } = ReorderSuggestionStatus.Open;
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier? Supplier { get; set; }
    }
}
