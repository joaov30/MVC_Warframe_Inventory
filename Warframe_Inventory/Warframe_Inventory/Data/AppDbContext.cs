using Microsoft.EntityFrameworkCore;
using Warframe_Inventory.Entities;

namespace Warframe_Inventory.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options) 
        { }
        public DbSet<Warframe> Warframes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Warframe_Inventory.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Warframe>().HasData(
                new Warframe
                {
                    WarframeId = 1,
                    Name = "Excalibur",
                    Blueprints = 1,
                    Neuroptics = 1,
                    Chassis = 1,
                    Systems = 1
                });
        }
    }
}
