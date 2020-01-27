namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NutritionsTable : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.Nutritious",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Calories = c.Int(nullable: false),
                        Carbohydrates = c.Int(nullable: false),
                        Fat = c.Int(nullable: false),
                        Proteins = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nutritious", "Id", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeImages", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Nutritious", new[] { "Id" });
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            DropIndex("dbo.RecipeImages", new[] { "RecipeId" });
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropTable("dbo.Nutritious");
            DropTable("dbo.Ingredients");
            DropTable("dbo.RecipeImages");
            DropTable("dbo.Recipes");
            DropTable("dbo.Categories");
        }
    }
}
