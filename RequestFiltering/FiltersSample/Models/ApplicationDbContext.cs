using System;
using System.Data.Entity;
using System.Linq;

namespace FiltersSample.Models
{
    public class ApplicationDbContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FiltersSample.Models.ApplicationDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationDbContext' 
        // connection string in the application configuration file.
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<ExceptionModel> ExceptionModels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ActionModel> ActionModels { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(x =>
                x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((Base)entry.Entity).UpdatedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                    ((Base)entry.Entity).CreatedDate = DateTime.Now;
            }

            return base.SaveChanges();
        }


        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker.Entries().Where(x =>
        //        x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));

        //    foreach (var entry in entries)
        //    {
        //        ((Base) entry.Entity).UpdatedDate = DateTime.Now;

        //        if (entry.State == EntityState.Added)
        //            ((Base) entry.Entity).CreatedDate = DateTime.Now;
        //    }

        //    return base.SaveChanges();
        //}
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}