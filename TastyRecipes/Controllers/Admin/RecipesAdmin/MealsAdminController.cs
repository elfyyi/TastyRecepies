using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TastyRecipes.Data;
using TastyRecipes.Models.Recipes;

namespace TastyRecipes.Controllers.Admin.RecipesAdmin
{
    [Authorize(Roles ="Admin")]
    public class MealsAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealsAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MealsAdmin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meals.ToListAsync());
        }

        

        // GET: MealsAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealsId,MealsName")] Meals meals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meals);
        }

        // GET: MealsAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meals = await _context.Meals.FindAsync(id);
            if (meals == null)
            {
                return NotFound();
            }
            return View(meals);
        }

        // POST: MealsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealsId,MealsName")] Meals meals)
        {
            if (id != meals.MealsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealsExists(meals.MealsId))
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
            return View(meals);
        }

        // GET: MealsAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meals = await _context.Meals
                .FirstOrDefaultAsync(m => m.MealsId == id);
            if (meals == null)
            {
                return NotFound();
            }

            return View(meals);
        }

        // POST: MealsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meals = await _context.Meals.FindAsync(id);
            if (meals != null)
            {
                _context.Meals.Remove(meals);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealsExists(int id)
        {
            return _context.Meals.Any(e => e.MealsId == id);
        }
    }
}
