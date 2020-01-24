using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.DataAccess
{
    public class CookDbContext:DbContext
    {
        public CookDbContext() : base("CookBookDbConnection")
        {
            //Database.SetInitializer<CookDbContext>(new CookDbInitializator());

        }

        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Nutritious> Nutritious { get; set; }
        public virtual DbSet<RecipeImage> RecipeImages { get; set; }
    }
}
