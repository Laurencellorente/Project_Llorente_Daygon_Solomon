using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketHistories")]
    public class TicketHistory
    {
        [Key]
        public int Id { get; set; }

        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public Ticket? Ticket { get; set; }

        [Required]
        public string Action { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ChangedAt { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
    }
}