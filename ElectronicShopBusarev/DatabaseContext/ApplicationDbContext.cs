using Microsoft.EntityFrameworkCore;
using ElectronicShopBusarev.Entities;

namespace ElectronicShopBusarev.DatabaseContext;
public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<ProductEntity> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(usersConfigurating =>
        {
            usersConfigurating.HasKey(u => u.Id);
        });

        modelBuilder.Entity<ProductEntity>(productsConfigurating =>
        {
            productsConfigurating.HasKey(p => p.Id);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connString = "server=localhost;user=root;password=123456789;database=EshopDbIbragimov;";
        optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
    }
}
