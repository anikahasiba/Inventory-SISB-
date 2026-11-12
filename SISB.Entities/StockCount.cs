using System.ComponentModel.DataAnnotations;

namespace SISB.Entities
{
    public class StockCount
    {
        [Key]
        public int StockCountId { get; set; }

        [Required, StringLength(50)]
        public string CountNumber { get; set; } = string.Empty;

        [Required]
        public string StartedBy { get; set; } = string.Empty;
        public string? ApprovedBy { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; }
        public StockCountStatus Status { get; set; } = StockCountStatus.Draft;

        public virtual ApplicationUser StartedByUser { get; set; } = null!;
        public virtual ApplicationUser? ApprovedByUser { get; set; }
        public virtual ICollection<StockCountItem> Items { get; set; } = new List<StockCountItem>();
    }
}
