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

        // GET: Tickets
        public async Task<IActionResult> Index(string? searchString, int? statusId, int? priorityId, int? categoryId)
        {
            var tickets = _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.Category)
                .AsQueryable();

            // Apply Text Search (Title or Description)
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                tickets = tickets.Where(t => t.Title.Contains(searchString) || t.Description.Contains(searchString));
            }

            // Apply Status Filter
            if (statusId.HasValue)
            {
                tickets = tickets.Where(t => t.StatusId == statusId.Value);
            }

            // Apply Priority Filter
            if (priorityId.HasValue)
            {
                tickets = tickets.Where(t => t.PriorityId == priorityId.Value);
            }

            // Apply Category Filter
            if (categoryId.HasValue)
            {
                tickets = tickets.Where(t => t.CategoryId == categoryId.Value);
            }

            // Populate Filter Dropdowns
            ViewBag.StatusId = new SelectList(_context.Statuses, "Id", "Name", statusId);
            ViewBag.PriorityId = new SelectList(_context.Priorities, "Id", "Name", priorityId);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", categoryId);
            ViewBag.CurrentSearch = searchString;

            return View(await tickets.ToListAsync());
        }
    }
}