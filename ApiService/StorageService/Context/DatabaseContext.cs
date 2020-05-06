using DataCore.Model;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace StorageService.Context
{
    //[DbConfigurationType]
    public class DatabaseContext : DbContext
    {
        //[Inject]
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            base.Database.SetCommandTimeout(180);
            Database.Migrate();
        }

        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Apii> Apiis { get; set; }
        public DbSet<Ambient> Ambients { get; set; }

    }
}
