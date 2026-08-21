using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.ViewModels
{
    public class TicketDetailsViewModel
    {
        public required Ticket Ticket { get; set; }
        public IEnumerable<TicketComment> Comments { get; set; } = new List<TicketComment>();

        
        public string NewCommentText { get; set; } = string.Empty;
        public bool IsInternal { get; set; } = false;
    }
}