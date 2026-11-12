using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class CustomerPayment
    {
        [Key]
        public int CustomerPaymentId { get; set; }

        public int CustomerId { get; set; }
        public int? SaleId { get; set; }
        [Required]
        public string ReceivedBy { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        public string? ReferenceNumber { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey(nameof(SaleId))]
        public virtual Sale? Sale { get; set; }
        [ForeignKey(nameof(ReceivedBy))]
        public virtual ApplicationUser ReceivedByUser { get; set; } = null!;
    }
}
