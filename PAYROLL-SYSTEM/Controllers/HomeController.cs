using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAYROLL_SYSTEM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Attendance()
        {
            return View("Attendance");
        }
        public ActionResult EmployeeList()
        {
            return View("EmployeeList");
        }
        public ActionResult Payslip()
        {
            return View("Payslip");
        }
        public ActionResult Position()
        {
            return View("Position");
        }
        public ActionResult Deduction()
        {
            return View("Deduction");
        }
        public ActionResult Reports()
        {
            return View("Reports");
        }
        public ActionResult ManageUser()
        {
            return View("ManageUser");
        }

    }
}