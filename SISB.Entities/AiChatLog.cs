using System.ComponentModel.DataAnnotations;

namespace SISB.Entities
{
    public class AiChatLog
    {
        [Key]
        public int AiChatLogId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Question { get; set; } = string.Empty;

        public string? ToolsCalled { get; set; }

        [Required]
        public string Answer { get; set; } = string.Empty;

        public int Tokens { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
