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
                // Authentication successful, redirect to the Dashboard Razor Page
                return RedirectToAction("Dashboard", "Pages");
            }

            // Authentication failed, return to the login page with an error message
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");

            // Return to the Index view with the model to display entered username
            return RedirectToAction("Index", "Home", model);
        }


    }
}
