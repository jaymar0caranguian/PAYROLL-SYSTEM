using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication4.DataDB;

namespace WebApplication4.Controllers
{
    public class AccountController : Controller
    {
        private readonly PmsDatabaseContext _context;

        public AccountController(PmsDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SysAcc model)
        {
            // Check username and password against the database
            var user = _context.SysAccs.SingleOrDefault(u => u.Username == model.Username && u.Pass == model.Pass);

            if (user != null)
            {
                // Authentication successful, set user's name in TempData
                TempData["UserName"] = user.Name;

                // Authentication successful, redirect to the Dashboard Razor Page
                return RedirectToAction("Dashboard", "Pages");
            }

            // Return to the Index action of the Home controller with the model to display entered username and the error message
            return RedirectToAction("Index", "Home", new { model = model, error = "Invalid username or password." });
        }

    }
}
