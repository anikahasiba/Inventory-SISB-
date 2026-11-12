using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? PaymentTerms { get; set; }

        public int LeadTimeDays { get; set; } = 0;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; } = 0.00m;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<Product> PreferredProducts { get; set; } = new List<Product>();
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
        public virtual ICollection<SupplierPayment> Payments { get; set; } = new List<SupplierPayment>();
        public virtual ICollection<ReorderSuggestion> ReorderSuggestions { get; set; } = new List<ReorderSuggestion>();
    }
}
