using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBook.Models
{
    public class Nutritious
    {
        [Key]
        [ForeignKey("Recipe")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Calories { get; }
        public int Carbohydrates { get; }
        public int Fat { get; }
        public int Proteins { get; }
        public Recipe Recipe { get; set; }
        public Nutritious(int calories = 0, int carbonhydrates = 0, int fat = 0, int proteins = 0)
        {
            Calories = calories;
            Carbohydrates = carbonhydrates;
            Fat = fat;
            Proteins = proteins;
        }
    }
}