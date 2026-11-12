using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class SupplierPayment
    {
        [Key]
        public int SupplierPaymentId { get; set; }

        public int SupplierId { get; set; }
        public int? PurchaseOrderId { get; set; }
        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        public string? ReferenceNumber { get; set; }

        [StringLength(50)]
        public string PaymentStatus { get; set; } = "Completed";

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; } = null!;
        [ForeignKey(nameof(PurchaseOrderId))]
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        public virtual ApplicationUser CreatedByUser { get; set; } = null!;
    }
}
