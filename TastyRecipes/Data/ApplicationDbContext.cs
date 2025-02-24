using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TastyRecipes.Models;
using TastyRecipes.Models.Recipes;
using TastyRecipes.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace TastyRecipes.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserIdName>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Meals> Meals { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Writers> Writers { get; set; }
        public DbSet<UserIdName> User_Names { get; set; }
        
    }
}