namespace IT_ELECTIVE_PREFINALS_PROJECT.ViewModels
{
    public class SystemReportViewModel
    {
        public string ReportTitle { get; set; } = "IT Operations Summary Report";
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
        public int TotalTicketsProcessed { get; set; }
        public int OpenTicketsCount { get; set; }
        public int ResolvedTicketsCount { get; set; }
        public int TotalAuditLogsRecorded { get; set; }
    }
}