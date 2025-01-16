using System.ComponentModel.DataAnnotations;

namespace TastyRecipes.Models.Recipes
{
    public class Writers
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Recipes> Recipes { get; set; }

    }
}
