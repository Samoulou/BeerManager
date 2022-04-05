using Microsoft.EntityFrameworkCore;

namespace BeerManager.Core.Data.Models;

public interface ICoreContext : IDisposable, IAsyncDisposable
{
    DbSet<Order> Orders { get; }
    DbSet<Contact> Contacts { get; }
    DbSet<Customer> Customers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}