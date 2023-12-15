using Microsoft.AspNetCore.Mvc;
using WebApplication4.DataDB;

namespace WebApplication4.Controllers
{
    public class PagesController : Controller
    {
		private readonly PmsDatabaseContext _context;

		public PagesController(PmsDatabaseContext context)
		{
			_context = context;
		}
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
            var random = new Random();

            var groupedQuery = from employee in _context.Employee
                               join attendance in _context.Attds on employee.EmpId equals attendance.EmpId
                               group new { employee, attendance } by employee.EmpId into grouped
                               select new
                               {
                                   EmployeeId = grouped.Key,
                                   Attendances = grouped.Select(a => new
                                   {
                                       Employee = a.employee,
                                       Attendance = a.attendance
                                   })
                               };

            var result = groupedQuery.AsEnumerable()
                .Select(grouped => new
                {
                    EmployeeId = grouped.EmployeeId,
                    EmployeeName = $"{grouped.Attendances.First().Employee.Fname} {grouped.Attendances.First().Employee.Mname} {grouped.Attendances.First().Employee.Lname}",
                    FirstAttendanceDate = grouped.Attendances.OrderBy(a => a.Attendance.Date).FirstOrDefault()?.Attendance.Date,
                    LatestAttendanceDate = grouped.Attendances.OrderByDescending(a => a.Attendance.Date).FirstOrDefault()?.Attendance.Date,
                    TotalNdValue = grouped.Attendances.Sum(a => a.Attendance.nd),
                    Rate = grouped.Attendances.First().Employee.Rate,
                    TotalSalary = grouped.Attendances.Sum(a => a.Attendance.nd) * grouped.Attendances.First().Employee.Rate,

                    RandomNumber = random.Next(1000, 9999)
                })
                .FirstOrDefault();

            return View(result);
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
