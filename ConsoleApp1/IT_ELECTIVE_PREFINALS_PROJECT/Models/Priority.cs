using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("Priorities")]
    public class Priority
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}