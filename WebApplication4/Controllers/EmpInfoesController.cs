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
    public class EmpInfoesController : Controller
    {
        private readonly PmsDatabaseContext _context;

        public EmpInfoesController(PmsDatabaseContext context)
        {
            _context = context;
        }

        // GET: EmpInfoes
        public async Task<IActionResult> Index()
        {
            var pmsDatabaseContext = _context.EmpInfos.Include(e => e.Dd).Include(e => e.Emp).Include(e => e.EmpNavigation).Include(e => e.PositionNavigation);
            return View(await pmsDatabaseContext.ToListAsync());
        }

        // GET: EmpInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmpInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.EmpInfos
                .Include(e => e.Dd)
                .Include(e => e.Emp)
                .Include(e => e.EmpNavigation)
                .Include(e => e.PositionNavigation)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return View(empInfo);
        }

        // GET: EmpInfoes/Create
        public IActionResult Create()
        {
            ViewData["DdId"] = new SelectList(_context.Dds, "DdId", "DdId");
            ViewData["EmpId"] = new SelectList(_context.Attds, "EmpId", "EmpId");
            ViewData["EmpId"] = new SelectList(_context.Ps, "EmpId", "EmpId");
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionId");
            return View();
        }

        // POST: EmpInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,Fname,Mname,Lname,Position,Rate,SssNo,PagibigNo,PositionId,DdId")] EmpInfo empInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DdId"] = new SelectList(_context.Dds, "DdId", "DdId", empInfo.DdId);
            ViewData["EmpId"] = new SelectList(_context.Attds, "EmpId", "EmpId", empInfo.EmpId);
            ViewData["EmpId"] = new SelectList(_context.Ps, "EmpId", "EmpId", empInfo.EmpId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionId", empInfo.PositionId);
            return View(empInfo);
        }

        // GET: EmpInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmpInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.EmpInfos.FindAsync(id);
            if (empInfo == null)
            {
                return NotFound();
            }
            ViewData["DdId"] = new SelectList(_context.Dds, "DdId", "DdId", empInfo.DdId);
            ViewData["EmpId"] = new SelectList(_context.Attds, "EmpId", "EmpId", empInfo.EmpId);
            ViewData["EmpId"] = new SelectList(_context.Ps, "EmpId", "EmpId", empInfo.EmpId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionId", empInfo.PositionId);
            return View(empInfo);
        }

        // POST: EmpInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,Fname,Mname,Lname,Position,Rate,SssNo,PagibigNo,PositionId,DdId")] EmpInfo empInfo)
        {
            if (id != empInfo.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpInfoExists(empInfo.EmpId))
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
            ViewData["DdId"] = new SelectList(_context.Dds, "DdId", "DdId", empInfo.DdId);
            ViewData["EmpId"] = new SelectList(_context.Attds, "EmpId", "EmpId", empInfo.EmpId);
            ViewData["EmpId"] = new SelectList(_context.Ps, "EmpId", "EmpId", empInfo.EmpId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionId", empInfo.PositionId);
            return View(empInfo);
        }
        // GET: EmpInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmpInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.EmpInfos
                .Include(e => e.Dd)
                .Include(e => e.Emp)
                .Include(e => e.EmpNavigation)
                .Include(e => e.PositionNavigation)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return View(empInfo);
        }

        // POST: EmpInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmpInfos == null)
            {
                return Problem("Entity set 'PmsDatabaseContext.EmpInfos'  is null.");
            }
            var empInfo = await _context.EmpInfos.FindAsync(id);
            if (empInfo != null)
            {
                _context.EmpInfos.Remove(empInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpInfoExists(int id)
        {
          return (_context.EmpInfos?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }
}
