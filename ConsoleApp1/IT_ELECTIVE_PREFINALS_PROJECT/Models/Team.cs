using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}