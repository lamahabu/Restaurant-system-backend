using Domain;
using Microsoft.EntityFrameworkCore;
namespace EFramework.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Food> Food { get; set; } = null!;
        public DbSet<Drink> Drinks { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-A4ULI8SL\\SQLEXPRESS ; Database = Restaurant ; Integrated Security = SSPI ; TrustServerCertificate = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
