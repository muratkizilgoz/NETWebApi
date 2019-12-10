using MediaTypeFormatter.Models;

namespace MediaTypeFormatter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MediaTypeFormatter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MediaTypeFormatter.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

                       
            #region Categories

            if (!context.Categories.Any(x => x.Id == 1))
                context.Categories.AddOrUpdate(x => x.Id, new Category
                {
                    Id = 1,
                    Name = "Bilgisayar"
                });

            if (!context.Categories.Any(x => x.Id == 2))
                context.Categories.AddOrUpdate(x => x.Id, new Category
                {
                    Id = 2,
                    Name = "Telefon"
                });

            #endregion

            #region Products

            if (!context.Products.Any(x => x.Id == 1))
                context.Products.AddOrUpdate(x => x.Id, new Product
                {
                    Id = 1,
                    Name = "Mix",
                    CategoryId = 2,
                    Price = 300,
                    Quantity = 300
                });

            if (!context.Products.Any(x => x.Id == 2))
                context.Products.AddOrUpdate(x => x.Id, new Product
                {
                    Id = 2,
                    Name = "Note",
                    CategoryId = 2,
                    Price = 340,
                    Quantity = 300
                });

            if (!context.Products.Any(x => x.Id == 3))
                context.Products.AddOrUpdate(x => x.Id, new Product
                {
                    Id = 3,
                    Name = "Msi",
                    CategoryId = 1,
                    Price = 1500,
                    Quantity = 300
                });

            if (!context.Products.Any(x => x.Id == 4))
                context.Products.AddOrUpdate(x => x.Id, new Product
                {
                    Id = 4,
                    Name = "Asus",
                    CategoryId = 1,
                    Price = 1700,
                    Quantity = 300
                });

            #endregion
        }
    }
}
