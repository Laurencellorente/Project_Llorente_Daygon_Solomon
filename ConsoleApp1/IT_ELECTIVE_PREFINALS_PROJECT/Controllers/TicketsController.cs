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

        // GET: Tickets/Create
        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,StatusId,PriorityId,CategoryId,CustomerId,DueAt")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            PopulateDropdowns(ticket);
            return View(ticket);
        }

        private void PopulateDropdowns(Ticket? ticket = null)
        {
            ViewBag.StatusId = new SelectList(_context.Statuses, "Id", "Name", ticket?.StatusId);
            ViewBag.PriorityId = new SelectList(_context.Priorities, "Id", "Name", ticket?.PriorityId);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", ticket?.CategoryId);
            ViewBag.CustomerId = new SelectList(_context.Customers, "Id", "CompanyName", ticket?.CustomerId);
        }
    }
}