using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using transport.Data;
using transport.Models;

namespace transport.Controllers
{

    public class teachersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public teachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: teachers

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.teachers.Include(t => t.desire);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.teachers
                .Include(t => t.desire)
                .FirstOrDefaultAsync(m => m.teacherid == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: teachers/Create
        public IActionResult Create()
        {
            ViewBag.desires = _context.desires.OrderBy(x => x.desirename).ToList(); // to make list from desire table
            return View();
        }

        // POST: teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("teacherid,teacherName,city,birth,last,hire,desireid")] teacher teacher)
        {
            ModelState.Remove("desire");
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["desireid"] = new SelectList(_context.desires, "desireid", "desirename", teacher.desireid);
            return View(teacher);
        }

        // GET: teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            ViewData["desireid"] = new SelectList(_context.desires, "desireid", "desirename", teacher.desireid);
            return View(teacher);
        }

        // POST: teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("teacherid,teacherName,city,birth,last,hire,desireid")] teacher teacher)
        {
            if (id != teacher.teacherid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!teacherExists(teacher.teacherid))
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
            ViewData["desireid"] = new SelectList(_context.desires, "desireid", "desirename", teacher.desireid);
            return View(teacher);
        }

        // GET: teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.teachers
                .Include(t => t.desire)
                .FirstOrDefaultAsync(m => m.teacherid == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.teachers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.teachers'  is null.");
            }
            var teacher = await _context.teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.teachers.Remove(teacher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool teacherExists(int id)
        {
          return (_context.teachers?.Any(e => e.teacherid == id)).GetValueOrDefault();
        }
    }
}
