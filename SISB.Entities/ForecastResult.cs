using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class ForecastResult
    {
        [Key]
        public int ForecastResultId { get; set; }

        public int ProductId { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public int Horizon { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal PredictedQty { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal? LowerBound { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal? UpperBound { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Mae { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Mape { get; set; }

        public ForecastMethod Method { get; set; }
        public ConfidenceLevel Confidence { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
    }
}
