using System.ComponentModel.DataAnnotations;

namespace TastyRecipes.Models.Recipes
{
    public class Recipes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Img { get; set; }
        [Required]
        public int MealsId { get; set; }
        public virtual Meals Meals { get; set; }
        [Required]
        public int Writer { get; set; }
        public virtual Writers Writers { get; set; }
        [Required]
        public string Recipe { get; set; }
        [Required]
        public string Ingradiance { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}
