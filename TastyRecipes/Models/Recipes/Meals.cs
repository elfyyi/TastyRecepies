using System.ComponentModel.DataAnnotations;

namespace TastyRecipes.Models.Recipes
{
    public class Meals
    {
       
        public int MealsId { get; set; }
        [Required]
        [MaxLength(50)]
        public string MealsName { get; set;}
        public virtual ICollection<Recipes> Recipes { get; set; }

    }
}
