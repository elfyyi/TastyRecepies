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
    [Authorize(Roles = "Admin")]
    public class RecipesAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecipesAdmin
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recipes.Include(r => r.Meals);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RecipesAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipes = await _context.Recipes
                .Include(r => r.Meals)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipes == null)
            {
                return NotFound();
            }

            return View(recipes);
        }

        // GET: RecipesAdmin/Create
        public IActionResult Create()
        {
            ViewData["MealsId"] = new SelectList(_context.Meals, "MealsId", "MealsName");
            return View();
        }

        // POST: RecipesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Img,MealsId,Writer,Recipe,Ingradiance,Date")] Recipes recipes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MealsId"] = new SelectList(_context.Meals, "MealsId", "MealsName", recipes.MealsId);
            return View(recipes);
        }

        // GET: RecipesAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipes = await _context.Recipes.FindAsync(id);
            if (recipes == null)
            {
                return NotFound();
            }
            ViewData["MealsId"] = new SelectList(_context.Meals, "MealsId", "MealsName", recipes.MealsId);
            return View(recipes);
        }

        // POST: RecipesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Img,MealsId,Writer,Recipe,Ingradiance,Date")] Recipes recipes)
        {
            if (id != recipes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipesExists(recipes.Id))
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
            ViewData["MealsId"] = new SelectList(_context.Meals, "MealsId", "MealsName", recipes.MealsId);
            return View(recipes);
        }

        // GET: RecipesAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipes = await _context.Recipes
                .Include(r => r.Meals)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipes == null)
            {
                return NotFound();
            }

            return View(recipes);
        }

        // POST: RecipesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipes = await _context.Recipes.FindAsync(id);
            if (recipes != null)
            {
                _context.Recipes.Remove(recipes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipesExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
