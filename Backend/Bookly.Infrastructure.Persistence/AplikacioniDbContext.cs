using Bookly.Domain.Apstrakcije.Baza;
using Bookly.Domain.Entiteti;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Infrastructure.Persistence;

public class AplikacioniDbContext : DbContext, IAplikacioniDbContext
{
    
    public AplikacioniDbContext(DbContextOptions<AplikacioniDbContext> opcije) : base(opcije)
    {
            
    }
    public DbSet<Apartman> Apartmani => Set<Apartman>();

    public DbSet<Korisnik> Kornisici => Set<Korisnik>();

    public DbSet<Rezervacija> Rezervacije => Set<Rezervacija>();
}
