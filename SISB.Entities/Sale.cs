using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [Required, StringLength(50)]
        public string InvoiceNo { get; set; } = string.Empty;

        public int? CustomerId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }

        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaidAmount { get; set; }

        public SaleStatus Status { get; set; } = SaleStatus.Confirmed;

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public virtual ApplicationUser CreatedByUser { get; set; } = null!;

        public virtual ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();
        public virtual ICollection<SaleReturn> Returns { get; set; } = new List<SaleReturn>();
        public virtual ICollection<CustomerPayment> Payments { get; set; } = new List<CustomerPayment>();
    }
}
