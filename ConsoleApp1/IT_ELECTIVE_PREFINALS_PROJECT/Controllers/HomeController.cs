using System.Diagnostics;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;
using IT_ELECTIVE_PREFINALS_PROJECT.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new DashboardMetricsViewModel();

            try
            {
               
                viewModel.TotalTickets = _context.Items != null ? _context.Items.Count() : 0;
                viewModel.OpenTickets = 0;
                viewModel.ResolvedTickets = 0;
                viewModel.TotalTeams = 0;
                viewModel.TotalCategories = _context.Categories != null ? _context.Categories.Count() : 0;
            }
            catch
            {
                
                viewModel.TotalTickets = 0;
                viewModel.OpenTickets = 0;
                viewModel.ResolvedTickets = 0;
                viewModel.TotalTeams = 0;
                viewModel.TotalCategories = 0;
            }

            return View("Dashboard", viewModel);
        }

        public IActionResult Dashboard()
        {
            return Index();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}