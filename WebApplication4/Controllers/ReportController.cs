using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.DataDB;

namespace WebApplication4.Controllers
{
    public class ReportController : Controller
    {
        private readonly PmsDatabaseContext _context;

        public ReportController(PmsDatabaseContext context)
        {
            _context = context;
        }
        // GET: Report
        public async Task<IActionResult> Index(DateTime? selectedDate, int page = 1, int pageSize = 5)
        {
            ViewBag.DateSortParam = "Date";
            var data = _context.Attds.AsQueryable();

            // Apply date filter
            if (selectedDate.HasValue)
            {
                data = data.Where(d => d.Date.Date == selectedDate.Value.Date);
            }

            // Calculate the total number of records
            int totalRecords = await data.CountAsync();

            // Implement pagination
            data = data.OrderBy(d => d.Date).Skip((page - 1) * pageSize).Take(pageSize);

            var model = await data.ToListAsync();

            // Pass pagination information to the view
            ViewBag.TotalRecords = totalRecords;
            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = page;

            return View(model);
        }

        private bool AttdExists(int id)
        {
          return (_context.Attds?.Any(e => e.AttdId == id)).GetValueOrDefault();
        }
    }
}
