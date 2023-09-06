using Schronisko.Data;
using Microsoft.AspNetCore.Mvc;
using Schronisko.Models;
using System.Diagnostics;
using Schronisko.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Schronisko.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeDataVM homeData = new();
            homeData.DisplayAnnouncements = _context.Announcements?
                .Where(t => t.Status == "Aktywne");
            homeData.DisplayNews = _context.Newses?
                .Where(n => n.Status == "Aktywne");
            return View(homeData);
        }

        public IActionResult Contact()
        {
            return View();
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