using Microsoft.EntityFrameworkCore;

namespace Inz.Data
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=192.168.0.247;Username=tomasz;Database=temp;Port=5432;Password=tomasz;SSLMode=Prefer");
        }
        public DbSet<User> users { get; set; }
        public DbSet<Temperatures> temperatures { get; set; }
        public DbSet<Measures> measures { get; set; }
        public DbSet<Settings> settings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.id).IsUnique();
            modelBuilder.Entity<Settings>().HasData(new Settings { id = 1, name = "IPAdress", value = "192.168.0.247" });
            modelBuilder.Entity<Settings>().HasData(new Settings { id = 2, name = "PeriodInMinutes", value = "60" });
        }
    }
}
