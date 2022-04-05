using Microsoft.EntityFrameworkCore;

namespace BeerManager.Core.Data.Models;

public class CoreContext : DbContext, ICoreContext
{
    public DbSet<Order> Orders { get; internal set; }

    public DbSet<Contact> Contacts { get; internal set; }

    public DbSet<Customer> Customers { get; internal set; }

    public CoreContext(DbContextOptions options) : base(options)
    {

    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.GetProperties().ToList();
            var entityTypeBuilder = modelBuilder.Entity(entityType.ClrType);

            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                // Disable default Cascade Delete
                // TODO [EF] Verify it's best practice or we can accept cascade delete
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Setup decimal type
            // TODO [EF] Define best precision and scale for all decimal types
            foreach (var p in properties.Where(p => p.ClrType == typeof(decimal)))
            {
                entityTypeBuilder.Property<decimal>(p.Name).HasColumnType("decimal(18,5)");
            }

            foreach (var p in properties.Where(p => p.ClrType == typeof(decimal?)))
            {
                entityTypeBuilder.Property<decimal?>(p.Name).HasColumnType("decimal(18,5)");
            }

            // Setup enum type
            foreach (var p in properties.Where(p => p.ClrType.IsEnum))
            {
                entityTypeBuilder.Property(p.Name).HasConversion<string>();
            }
        }

        modelBuilder.HasDefaultSchema("beerManager");
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.OrderId);
            entity.HasOne(o => o.Customer)
            .WithMany(c => c.Orders);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.CustomerId);
            entity.HasOne(c => c.Contact)
            .WithMany(c => c.Customers);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(c => c.ContactId);
        });
    }
}