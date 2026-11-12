using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class SaleReturn
    {
        [Key]
        public int SaleReturnId { get; set; }

        [Required, StringLength(50)]
        public string ReturnNo { get; set; } = string.Empty;

        public int SaleId { get; set; }
        [Required]
        public string ProcessedBy { get; set; } = string.Empty;
        public DateTime ReturnDate { get; set; } = DateTime.UtcNow;

        [StringLength(500)]
        public string? Reason { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(SaleId))]
        public virtual Sale Sale { get; set; } = null!;
        [ForeignKey(nameof(ProcessedBy))]
        public virtual ApplicationUser ProcessedByUser { get; set; } = null!;
        public virtual ICollection<SaleReturnItem> Items { get; set; } = new List<SaleReturnItem>();
    }
}
