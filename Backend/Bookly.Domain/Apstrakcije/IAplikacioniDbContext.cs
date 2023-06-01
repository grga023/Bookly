using Bookly.Domain.Entiteti;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Domain.Contracts;

public interface IAplikacioniDbContext
{
    public DbSet<Apartman> Apartmani { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
