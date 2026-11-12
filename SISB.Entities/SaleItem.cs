using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class SaleItem
    {
        [Key]
        public int SaleItemId { get; set; }

        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int? ProductBatchId { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitCost { get; set; } // WAC snapshot at sale time

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        [ForeignKey(nameof(SaleId))]
        public virtual Sale Sale { get; set; } = null!;

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        [ForeignKey(nameof(ProductBatchId))]
        public virtual ProductBatch? ProductBatch { get; set; }

        public virtual ICollection<SaleReturnItem> ReturnItems { get; set; } = new List<SaleReturnItem>();
    }
}
