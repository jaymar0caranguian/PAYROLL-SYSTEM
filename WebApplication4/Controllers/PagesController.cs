using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Attendance()
        {
            return View();
        }
        public IActionResult Deductions()
        {
            return View();
        }
        public IActionResult Employees()
        {
            return View();
        }
        public IActionResult ManageUsers()
        {
            return View();
        }
        public IActionResult Payslip()
        {
            return View();
        }
        public IActionResult Positions()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }
    }
}
