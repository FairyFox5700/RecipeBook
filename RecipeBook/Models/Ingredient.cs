using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBook.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measure { get; set; }
        public int? RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient(string name = "", int quantity = 0, string measure = "")
        {
            Name = name;
            Quantity = quantity;
            Measure = measure;
        }
    }
}