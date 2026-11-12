using System.ComponentModel.DataAnnotations;

namespace SISB.Entities
{
    public class Alert
    {
        [Key]
        public int AlertId { get; set; }

        public AlertType Type { get; set; }
        public int? ProductId { get; set; }

        [Required, StringLength(500)]
        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;

        public virtual Product? Product { get; set; }
    }
}
