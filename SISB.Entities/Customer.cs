using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CreditLimit { get; set; } = 0.00m;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DueBalance { get; set; } = 0.00m;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public virtual ICollection<CustomerPayment> Payments { get; set; } = new List<CustomerPayment>();
    }
}
