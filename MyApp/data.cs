using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp
{
    public class Data : DbContext
    {
        // properties that map to the database tables
        public DbSet<Bus> Bus { get; set; }
        public DbSet<BusStop> BusStop { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "data.db3");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasNoKey();
        }
    }
}
