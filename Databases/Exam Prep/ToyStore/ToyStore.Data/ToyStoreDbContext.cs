using System.Data.Entity;
using ToyStore.Data.Migrations;
using ToyStore.Models;

namespace ToyStore.Data
{
    public class ToyStoreDbContext : DbContext
    {
        public ToyStoreDbContext()
            : base("ToyStoreLocalSqlConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ToyStoreDbContext, Configuration>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AgeRange> AgeRanges { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ToyType> ToyTypes { get; set; }
        public DbSet<Toy> Toys { get; set; }
    }
}
