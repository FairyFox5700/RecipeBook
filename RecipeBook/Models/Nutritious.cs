using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBook.Models
{
    public class Nutritious
    {
        [Key]
        [ForeignKey("Recipe")]
        public int Id { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Fat { get; set; }
        public int Proteins { get; set; }
        public Recipe Recipe { get; set; }
        public Nutritious()
        {
                
        }
        public Nutritious(int calories = 0, int carbonhydrates = 0, int fat = 0, int proteins = 0)
        {
            Calories = calories;
            Carbohydrates = carbonhydrates;
            Fat = fat;
            Proteins = proteins;
        }
    }
}