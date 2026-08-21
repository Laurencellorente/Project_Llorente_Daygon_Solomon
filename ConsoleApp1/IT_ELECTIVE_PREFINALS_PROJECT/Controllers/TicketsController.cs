using IT_ELECTIVE_PREFINALS_PROJECT.Data;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: Tickets/UpdateStatus/5
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            if (id == null) return NotFound();

            var ticket = await _context.Tickets
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ticket == null) return NotFound();

            ViewBag.StatusId = new SelectList(_context.Statuses, "Id", "Name", ticket.StatusId);
            return View(ticket);
        }

        // POST: Tickets/UpdateStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, int statusId)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            ticket.StatusId = statusId;
            _context.Update(ticket);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Tickets/QuickStatusUpdate (Inline Quick Actions)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuickStatusUpdate(int id, int statusId)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                ticket.StatusId = statusId;
                _context.Update(ticket);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}