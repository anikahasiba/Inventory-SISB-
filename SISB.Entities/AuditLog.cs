using System.ComponentModel.DataAnnotations;

namespace SISB.Entities
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string Entity { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Action { get; set; } = string.Empty;

        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
