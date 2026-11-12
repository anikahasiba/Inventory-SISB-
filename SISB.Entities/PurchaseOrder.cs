using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [Required, StringLength(50)]
        public string PoNumber { get; set; } = string.Empty;

        public int SupplierId { get; set; }
        public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Draft;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateOnly? ExpectedDate { get; set; }
        public DateTime? ReceivedDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; } = null!;

        [ForeignKey(nameof(CreatedBy))]
        public virtual ApplicationUser CreatedByUser { get; set; } = null!;

        public virtual ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; } = new List<GoodsReceipt>();
        public virtual ICollection<SupplierPayment> Payments { get; set; } = new List<SupplierPayment>();
    }
}
