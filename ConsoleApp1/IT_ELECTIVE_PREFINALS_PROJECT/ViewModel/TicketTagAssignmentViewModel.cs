namespace IT_ELECTIVE_PREFINALS_PROJECT.ViewModels
{
    public class TicketTagAssignmentViewModel
    {
        public int TicketId { get; set; }
        public string TicketSubject { get; set; } = string.Empty;

       
        public List<TagSelectionItem> AvailableTags { get; set; } = new List<TagSelectionItem>();
    }

    public class TagSelectionItem
    {
        public int TagId { get; set; }
        public string TagName { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }
}