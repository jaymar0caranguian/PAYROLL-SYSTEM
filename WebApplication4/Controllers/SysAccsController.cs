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
    public class SysAccsController : Controller
    {
        private readonly PmsDatabaseContext _context;

        public SysAccsController(PmsDatabaseContext context)
        {
            _context = context;
        }

        // GET: SysAccs
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 5; // Set your desired page size
            int pageNumber = page ?? 1;

            var sysAccs = await _context.SysAccs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)_context.SysAccs.Count() / pageSize);

            return View(sysAccs);
        }


        // GET: SysAccs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SysAccs == null)
            {
                return NotFound();
            }

            var sysAcc = await _context.SysAccs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sysAcc == null)
            {
                return NotFound();
            }

            return View(sysAcc);
        }

        // GET: SysAccs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SysAccs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Username,Pass")] SysAcc sysAcc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sysAcc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sysAcc);
        }

        // GET: SysAccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SysAccs == null)
            {
                return NotFound();
            }

            var sysAcc = await _context.SysAccs.FindAsync(id);
            if (sysAcc == null)
            {
                return NotFound();
            }
            return View(sysAcc);
        }

        // POST: SysAccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Username,Pass")] SysAcc sysAcc)
        {
            if (id != sysAcc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sysAcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SysAccExists(sysAcc.Id))
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
            return View(sysAcc);
        }

        // GET: SysAccs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SysAccs == null)
            {
                return NotFound();
            }

            var sysAcc = await _context.SysAccs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sysAcc == null)
            {
                return NotFound();
            }

            return View(sysAcc);
        }

        // POST: SysAccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SysAccs == null)
            {
                return Problem("Entity set 'PmsDatabaseContext.SysAccs'  is null.");
            }
            var sysAcc = await _context.SysAccs.FindAsync(id);
            if (sysAcc != null)
            {
                _context.SysAccs.Remove(sysAcc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SysAccExists(int id)
        {
          return (_context.SysAccs?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
