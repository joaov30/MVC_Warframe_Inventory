﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Warframe_Inventory.Entities;

namespace Warframe_Inventory.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options) 
        { }
        public DbSet<Warframe> Warframes { get; set; }


       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=localhost;Database=Warframe_Inventory;User=root;Password=yourpassword;");
        }
       */

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
