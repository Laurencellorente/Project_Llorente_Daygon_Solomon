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

        // GET: Tickets/Assign/5
        public async Task<IActionResult> Assign(int? id)
        {
            if (id == null) return NotFound();

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ticket == null) return NotFound();

            PopulateEmployeeDropdown();
            return View(ticket);
        }

        // POST: Tickets/Assign/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(int id, int? assignedEmployeeId)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            // Note: Add an AssignedEmployeeId property to your Ticket model if tracked in DB
            _context.Update(ticket);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private void PopulateEmployeeDropdown(object? selectedEmployee = null)
        {
            var employees = _context.Employees
                .Select(e => new { Id = e.Id, FullName = e.FirstName + " " + e.LastName })
                .ToList();

            ViewBag.AssignedEmployeeId = new SelectList(employees, "Id", "FullName", selectedEmployee);
        }
    }
}