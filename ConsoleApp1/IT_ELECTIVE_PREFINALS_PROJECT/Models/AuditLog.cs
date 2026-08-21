using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Action { get; set; }

        [Required]
        [StringLength(500)]
        public required string Details { get; set; }

        [Required]
        public string Timestamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        [StringLength(100)]
        public string? PerformedBy { get; set; }
    }
}