using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TastyRecipes.Data;
using TastyRecipes.Models.Recipes;

namespace TastyRecipes.Controllers
{
    public class WritersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WritersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Writers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Writers.ToListAsync());
        }

        // GET: Writers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writers = await _context.Writers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (writers == null)
            {
                return NotFound();
            }

            return View(writers);
        }

        // GET: Writers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Writers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Writers writers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(writers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(writers);
        }

        // GET: Writers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writers = await _context.Writers.FindAsync(id);
            if (writers == null)
            {
                return NotFound();
            }
            return View(writers);
        }

        // POST: Writers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Writers writers)
        {
            if (id != writers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(writers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WritersExists(writers.Id))
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
            return View(writers);
        }

        // GET: Writers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writers = await _context.Writers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (writers == null)
            {
                return NotFound();
            }

            return View(writers);
        }

        // POST: Writers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var writers = await _context.Writers.FindAsync(id);
            if (writers != null)
            {
                _context.Writers.Remove(writers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WritersExists(int id)
        {
            return _context.Writers.Any(e => e.Id == id);
        }
    }
}
