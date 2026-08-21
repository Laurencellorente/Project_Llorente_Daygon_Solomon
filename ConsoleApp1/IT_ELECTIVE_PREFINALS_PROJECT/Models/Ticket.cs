using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Open"; 

        [Required]
        public string Priority { get; set; } = "Normal"; 

        
        public int CustomerId { get; set; }
        public int? AssignedEmployeeId { get; set; }

        
        public Customer? Customer { get; set; }
        public Employee? AssignedEmployee { get; set; }
    }
}