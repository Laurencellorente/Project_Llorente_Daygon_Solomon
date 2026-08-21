using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        
        public ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
    }
}