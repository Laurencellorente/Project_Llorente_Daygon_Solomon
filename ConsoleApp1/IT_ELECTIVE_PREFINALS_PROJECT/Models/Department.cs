using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}