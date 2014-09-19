namespace Cars.Data
{
    using System.Data.Entity;

    using Cars.Data.Migrations;
    using Cars.Models;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("Name=CarsLocalSqlConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        public DbSet<Manufaturer> Manufacturers { get; set; }
    }
}
