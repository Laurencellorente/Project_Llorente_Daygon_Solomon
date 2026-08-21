using IT_ELECTIVE_PREFINALS_PROJECT.Data;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;
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

        // GET: Tickets/Audit/5
        public async Task<IActionResult> Audit(int? id)
        {
            if (id == null) return NotFound();

            var history = await _context.TicketHistories
                .Include(h => h.Ticket)
                .Where(h => h.TicketId == id)
                .OrderByDescending(h => h.ChangedAt)
                .ToListAsync();

            ViewBag.TicketId = id;
            return View(history);
        }

        // Helper method to log audit events
        private async Task LogAuditAsync(int ticketId, string action, string description)
        {
            var history = new TicketHistory
            {
                TicketId = ticketId,
                Action = action,
                Description = description,
                ChangedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };

            _context.TicketHistories.Add(history);
            await _context.SaveChangesAsync();
        }
    }
}