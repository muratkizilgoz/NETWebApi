using System.Data.Entity.Migrations;
using System.Linq;
using FiltersSample.Models;

namespace FiltersSample.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Products

            if (!context.Products.Any(x => x.Id == 1))
                context.Products.AddOrUpdate(x => x.Id, new Product
                {
                    Id = 1,
                    Name = "Mix",
                    Price = 300,
                    Quantity = 300
                });

            if (!context.Products.Any(x => x.Id == 2))
                context.Products.AddOrUpdate(x => x.Id, new Product
                {
                    Id = 2,
                    Name = "Note",
                    Price = 340,
                    Quantity = 300
                });

            if (!context.Products.Any(x => x.Id == 3))
                context.Products.AddOrUpdate(x => x.Id, new Product
                {
                    Id = 3,
                    Name = "Msi",
                    Price = 1500,
                    Quantity = 300
                });

            if (!context.Products.Any(x => x.Id == 4))
                context.Products.AddOrUpdate(x => x.Id, new Product
                {
                    Id = 4,
                    Name = "Asus",
                    Price = 1700,
                    Quantity = 300
                });

            #endregion
        }
    }
}