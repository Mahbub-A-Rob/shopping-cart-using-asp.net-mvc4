using Online_Shopping_Management.Models;

namespace Online_Shopping_Management.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Online_Shopping_Management.Models.ShoppingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Online_Shopping_Management.Models.ShoppingDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Categorys.AddOrUpdate(

            //    new Category { Name = "Book", Code = "C-001" },
            //    new Category { Name = "Food & Bevarage", Code = "C-002" },
            //    new Category { Name = "Clothes", Code = "C-003" },
            //    new Category { Name = "Computer & Electronics", Code = "C-004" }
            //    );

            //context.SubCategories.AddOrUpdate(

            //      new SubCategory { CategoryName = "Book", SubCategoryName = "Drama", Code = "B-001" },
            //      new SubCategory { CategoryName = "Book", SubCategoryName = "Horror", Code = "B-002" },
            //      new SubCategory { CategoryName = "Food & Bevarage", SubCategoryName = "Drinks", Code = "F&R-001" },
            //      new SubCategory { CategoryName = "Food & Bevarage", SubCategoryName = "Juice", Code = "F&R-002" }
            //    );
            //context.Models.AddOrUpdate(
                
            //    m => m.Name,
            //    new Category { Name = "Book"},
            //    new Category { Name = "Food & Bevarage" },
            //    new Category { Name = "Clothes" }
            //    );
        }
    }
}
