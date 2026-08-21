using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class TicketTag
    {
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket? Ticket { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag? Tag { get; set; }
    }
}
}