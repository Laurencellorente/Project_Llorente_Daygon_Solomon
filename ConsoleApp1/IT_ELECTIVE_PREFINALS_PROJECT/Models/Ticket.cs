using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public int StatusId { get; set; }

        public int PriorityId { get; set; }

        public int CategoryId { get; set; }

        public int CustomerId { get; set; }

        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

        public string? DueAt { get; set; }

        
        [ForeignKey("StatusId")]
        public Status? Status { get; set; }

        [ForeignKey("PriorityId")]
        public Priority? Priority { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}