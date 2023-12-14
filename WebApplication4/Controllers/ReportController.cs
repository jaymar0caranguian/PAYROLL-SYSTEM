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
        public async Task<IActionResult> Index(DateTime? selectedDate)
        {
            ViewBag.DateSortParam = "Date";
            var data = _context.Attds.AsQueryable();
            if (selectedDate.HasValue)
            {
                data = data.Where(d => d.Date.Date == selectedDate.Value.Date);
            }

            data = data.OrderBy(d => d.Date);
            var model = await data.ToListAsync();

            return View(model);
        }
        private bool AttdExists(int id)
        {
          return (_context.Attds?.Any(e => e.AttdId == id)).GetValueOrDefault();
        }
    }
}
