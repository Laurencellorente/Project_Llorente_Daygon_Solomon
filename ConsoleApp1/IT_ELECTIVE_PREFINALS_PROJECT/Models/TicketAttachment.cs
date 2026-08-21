using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class TicketAttachment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket? Ticket { get; set; }

        [Required]
        [StringLength(255)]
        public required string FileName { get; set; }

        [Required]
        [StringLength(500)]
        public required string FilePath { get; set; }

        [Required]
        public string UploadedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}