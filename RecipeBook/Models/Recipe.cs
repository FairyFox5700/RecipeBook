using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBook.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual IList<RecipeImage> ImagePathes { get; set; }
        public string VideoPath { get; set; }
        public string Notes { get; set; }
        public string Instruction { get; set; }
        public bool IsFavourite { get; set; }
        public string Source { get; set; }
        public virtual Nutritious Nutritious { get; set; }
        public int Rating { get; set; }
        public int NumberOfServings { get; set; }
        public Int64 CookTime { get; set; }
        [NotMapped]
        public TimeSpan CookTimeValid
        {
            get { return TimeSpan.FromTicks(CookTime); }
            set { CookTime = value.Ticks; }
        }
    }
}