using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreEmplDapper.Data;
using CoreEmplDapper.Models;

namespace CoreEmplDapper.Controllers
{
    public class EmplsController : Controller
    {
        private readonly NorthwindContext _context;

        public EmplsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: Empls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empl.ToListAsync());
        }

        // GET: Empls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empl = await _context.Empl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empl == null)
            {
                return NotFound();
            }

            return View(empl);
        }

        // GET: Empls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Title,BirthDate,City")] Empl empl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empl);
        }

        // GET: Empls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empl = await _context.Empl.FindAsync(id);
            if (empl == null)
            {
                return NotFound();
            }
            return View(empl);
        }

        // POST: Empls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Title,BirthDate,City")] Empl empl)
        {
            if (id != empl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmplExists(empl.Id))
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
            return View(empl);
        }

        // GET: Empls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empl = await _context.Empl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empl == null)
            {
                return NotFound();
            }

            return View(empl);
        }

        // POST: Empls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empl = await _context.Empl.FindAsync(id);
            _context.Empl.Remove(empl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmplExists(int id)
        {
            return _context.Empl.Any(e => e.Id == id);
        }
    }
}
