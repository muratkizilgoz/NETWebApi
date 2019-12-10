using System.Data.Entity.Migrations;
using System.Linq;
using EntityFrameworkCFCrud.Models;

namespace EntityFrameworkCFCrud.Migrations
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

            #region Person

            if (!context.Persons.Any(x => x.Id == 1))
                context.Persons.AddOrUpdate(x => x.Id, new Person
                {
                    Id = 1,
                    Name = "Bruce",
                    Surname = "Wayne",
                    Salary = 1,
                    Gender = "Male"
                });

            if (!context.Persons.Any(x => x.Id == 2))
                context.Persons.AddOrUpdate(x => x.Id, new Person
                {
                    Id = 2,
                    Name = "Elon",
                    Surname = "Musk",
                    Salary = 2,
                    Gender = "Male"
                });

            if (!context.Persons.Any(x => x.Id == 3))
                context.Persons.AddOrUpdate(x => x.Id, new Person
                {
                    Id = 3,
                    Name = "Kibar",
                    Surname = "İye",
                    Salary = 3m,
                    Gender = "Female"
                });

            #endregion
        }
    }
}