using Bookly.Infrastructure.Identity.Entiteti;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Infrastructure.Identity;

public class IdentityDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationRole>()
               .HasData(new ApplicationRole(Guid.Parse("5310feb4-a1e1-4439-b511-fd2293f33af0"), IdentityUloge.KORISNIK));
    }
}
