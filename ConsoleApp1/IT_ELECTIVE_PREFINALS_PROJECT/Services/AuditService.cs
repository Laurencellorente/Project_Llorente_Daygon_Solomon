using IT_ELECTIVE_PREFINALS_PROJECT.Data;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Services
{
    public interface IAuditService
    {
        Task LogActionAsync(string action, string details, string performedBy = "System Admin");
    }

    public class AuditService : IAuditService
    {
        private readonly AppDbContext _context;

        public AuditService(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogActionAsync(string action, string details, string performedBy = "System Admin")
        {
            var log = new AuditLog
            {
                Action = action,
                Details = details,
                PerformedBy = performedBy
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}