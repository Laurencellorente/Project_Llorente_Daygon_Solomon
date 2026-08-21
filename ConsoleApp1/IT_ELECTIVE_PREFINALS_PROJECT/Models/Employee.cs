using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        
        public int DepartmentId { get; set; }

        
        public Department? Department { get; set; }
        public ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    }
}