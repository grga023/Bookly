using Bookly.Domain.Entiteti;
using Bookly.Domain.Entiteti.Bazni;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Domain.Apstrakcije.Baza;

public interface IAplikacioniDbContext
{
    public DbSet<Apartman> Apartmani { get; }
    public DbSet<Korisnik> Kornisici { get; }
    public DbSet<Rezervacija> Rezervacije { get; }
    public DbSet<Slike> Slike { get;  }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
