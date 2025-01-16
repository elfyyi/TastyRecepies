using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TastyRecipes.Models.Recipes;

namespace TastyRecipes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Meals> Meals { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Writers> Writers { get; set; }

    }
}
