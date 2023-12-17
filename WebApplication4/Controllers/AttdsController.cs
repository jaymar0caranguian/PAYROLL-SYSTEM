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
    public class AttdsController : Controller
    {
        private readonly PmsDatabaseContext _context;

        public AttdsController(PmsDatabaseContext context)
        {
            _context = context;
        }

        // GET: Attds
        public ActionResult Index(int? page)
        {
            int pageSize = 5; // Set your desired page size
            int pageNumber = (page ?? 1);

            var attds = _context.Attds.OrderBy(a => a.Date)
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)_context.Attds.Count() / pageSize);

            return View(attds);
        }


        // GET: Attds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attds == null)
            {
                return NotFound();
            }

            var attd = await _context.Attds
                .FirstOrDefaultAsync(m => m.AttdId == id);
            if (attd == null)
            {
                return NotFound();
            }

            return View(attd);
        }

        // GET: Attds/Create
        public IActionResult Create()
        {
            return PartialView("_Create", new Attd());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttdId,Date,EmpId,Holiday,St,Tr,nd")] Attd attd)
        {
            if (ModelState.IsValid)
            {
                int initialCount = _context.Attds.Count();
                if (_context.Attds.Any(a => a.EmpId == attd.EmpId && a.Date == attd.Date))
                {
                    ModelState.AddModelError("Date", "Employee already has attendance for this date.");
                    return PartialView("_Create", attd);
                }

                if (!_context.Employee.Any(e => e.EmpId == attd.EmpId))
                {
                    ModelState.AddModelError("EmpId", "Employee ID does not exist.");
                    return PartialView("_Create", attd);
                }

                _context.Add(attd);
                await _context.SaveChangesAsync();
                int finalCount = _context.Attds.Count();
                int countChange = finalCount - initialCount;
                return Json(new { success = true, countChange });
            }
            return PartialView("_Create", attd);
        }


        // GET: Attds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attds == null)
            {
                return NotFound();
            }

            var attd = await _context.Attds.FindAsync(id);
            if (attd == null)
            {
                return NotFound();
            }
            return View(attd);
        }

        // POST: Attds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttdId,Date,EmpId,Holiday,St,Tr,nd")] Attd attd)
        {
            if (id != attd.AttdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttdExists(attd.AttdId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(attd);
        }

        // GET: Attds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attds == null)
            {
                return NotFound();
            }

            var attd = await _context.Attds
                .FirstOrDefaultAsync(m => m.AttdId == id);
            if (attd == null)
            {
                return NotFound();
            }

            return View(attd);
        }

        // POST: Attds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attds == null)
            {
                return Problem("Entity set 'PmsDatabaseContext.Attds'  is null.");
            }
            var attd = await _context.Attds.FindAsync(id);
            if (attd != null)
            {
                _context.Attds.Remove(attd);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttdExists(int id)
        {
          return (_context.Attds?.Any(e => e.AttdId == id)).GetValueOrDefault();
        }
        // GET: Attds/Report
        public IActionResult report()
        {
            // Add logic to generate and return the report view
            // You can use a dedicated view for reporting or reuse the existing one
            return View();
        }
    }
}
