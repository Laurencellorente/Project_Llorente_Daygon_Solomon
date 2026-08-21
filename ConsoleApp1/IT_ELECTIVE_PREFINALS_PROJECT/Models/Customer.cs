using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}