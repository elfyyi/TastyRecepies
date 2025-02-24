using System.ComponentModel.DataAnnotations;

namespace TastyRecipes.Models.Recipes
{
    public class Meals
    {
       
        public int MealsId { get; set; }
        [Required(ErrorMessage = "Please enter Meal name")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string MealsName { get; set;}
        public virtual ICollection<Recipes>? Recipes { get; set; }

    }
}
