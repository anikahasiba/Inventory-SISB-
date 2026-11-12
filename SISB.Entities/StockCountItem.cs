using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class StockCountItem
    {
        [Key]
        public int StockCountItemId { get; set; }

        public int StockCountId { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal SystemQuantity { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal CountedQuantity { get; set; }

        // SQL Server calculates this value using a persisted computed column.
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Variance { get; private set; }

        [ForeignKey(nameof(StockCountId))]
        public virtual StockCount StockCount { get; set; } = null!;
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
    }
}
