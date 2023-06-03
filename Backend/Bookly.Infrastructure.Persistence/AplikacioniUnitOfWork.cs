using Bookly.Domain.Apstrakcije.Baza;
using Microsoft.Identity.Client;

namespace Bookly.Infrastructure.Persistence
{
    public class AplikacioniUnitOfWork : IAplikacioniUnitOfWork
    {
        private readonly AplikacioniDbContext _context;

        public AplikacioniUnitOfWork(AplikacioniDbContext context)
        {
            _context = context;
        }

        public async Task KomitujTransakciju() => 
            await _context.Database.CommitTransactionAsync();

        public async Task PokreniTransakciju()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task SacuvajIzmene() => 
            await _context.SaveChangesAsync();
    }
}
