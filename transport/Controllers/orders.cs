using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using transport.Data;
using transport.Models;

namespace transport.Controllers
{
    public class orders : Controller
    {
        private readonly ApplicationDbContext _context;

        public orders(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.teachers.Include(t => t.desire);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: orders/Details/5
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


        // GET: orders/Delete/5
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

        // POST: orders/Delete/5
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
