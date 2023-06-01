using AcmeInsurance.Claims.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcmeInsurance.Claims.Repository
{
    public class AcmeDbContext : DbContext
    {
        public AcmeDbContext(DbContextOptions<AcmeDbContext> options) : base(options)
        {
        }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimType> ClaimTypes { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>().ToTable("Claim");
            modelBuilder.Entity<ClaimType>().ToTable("ClaimType");
            modelBuilder.Entity<Company>().ToTable("Company");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestDatabase");
        }
    }
}
