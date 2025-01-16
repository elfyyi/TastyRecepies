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
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meals.ToListAsync());
        }

        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
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


        private bool MealsExists(int id)
        {
            return _context.Meals.Any(e => e.MealsId == id);
        }
    }
}
