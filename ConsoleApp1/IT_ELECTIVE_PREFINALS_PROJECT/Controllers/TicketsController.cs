using System.Text;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tickets/ExportCsv
        [HttpGet]
        public async Task<IActionResult> ExportCsv()
        {
            // Fetch tickets using available navigation properties
            var tickets = await _context.Tickets
                .ToListAsync();

            var builder = new StringBuilder();

            // 1. Header row
            builder.AppendLine("Ticket ID,Title,Description");

            // 2. Data rows matching your Ticket model
            foreach (var ticket in tickets)
            {
                string ticketId = ticket.Id.ToString();
                string title = EscapeCsv(ticket.Title);
                string description = EscapeCsv(ticket.Description);

                builder.AppendLine($"{ticketId},{title},{description}");
            }

            // 3. Output file
            byte[] buffer = Encoding.UTF8.GetBytes(builder.ToString());
            return File(buffer, "text/csv", $"tickets_export_{DateTime.UtcNow:yyyyMMdd_HHmmss}.csv");
        }

        private static string EscapeCsv(string field)
        {
            if (string.IsNullOrEmpty(field))
                return "\"\"";

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                field = field.Replace("\"", "\"\"");
                return $"\"{field}\"";
            }

            return field;
        }
    }
}