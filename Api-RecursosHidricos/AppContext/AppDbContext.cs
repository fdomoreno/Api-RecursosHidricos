using Api_RecursosHidricos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_RecursosHidricos.AppContext{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RecursosHidricos> RecursosHidricos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecursosHidricos>().ToTable("RecursosHidricos");
        }
    }
}
