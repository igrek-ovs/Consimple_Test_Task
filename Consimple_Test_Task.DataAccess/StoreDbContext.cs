using Consimple_Test_Task.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consimple_Test_Task.DataAccess;

public class StoreDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }

    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasKey(c => c.Id);
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Purchase>().HasKey(p => p.Id);

        modelBuilder.Entity<PurchaseProduct>().HasKey(pp => new { pp.PurchaseId, pp.ProductId });

        modelBuilder.Entity<PurchaseProduct>()
            .HasOne(pp => pp.Purchase)
            .WithMany(p => p.PurchaseProducts)
            .HasForeignKey(pp => pp.PurchaseId);

        modelBuilder.Entity<PurchaseProduct>()
            .HasOne(pp => pp.Product)
            .WithMany(p => p.PurchaseProducts)
            .HasForeignKey(pp => pp.ProductId);
    }
}