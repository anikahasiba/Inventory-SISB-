using System.ComponentModel.DataAnnotations;

namespace SISB.Entities
{
    public class GoodsReceipt
    {
        [Key]
        public int GoodsReceiptId { get; set; }

        [Required, StringLength(50)]
        public string GrnNumber { get; set; } = string.Empty;

        public int PurchaseOrderId { get; set; }
        [Required]
        public string ReceivedBy { get; set; } = string.Empty;
        public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;

        [StringLength(500)]
        public string? Notes { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
        public virtual ApplicationUser ReceivedByUser { get; set; } = null!;
        public virtual ICollection<GoodsReceiptItem> Items { get; set; } = new List<GoodsReceiptItem>();
    }
}
