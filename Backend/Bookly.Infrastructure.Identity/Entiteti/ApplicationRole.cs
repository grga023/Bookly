using Microsoft.AspNetCore.Identity;

namespace Bookly.Infrastructure.Identity.Entiteti;

public class ApplicationRole : IdentityRole<Guid>
{

    public ApplicationRole(Guid id, string name)
    {
        Id = id;
        Name = name;
        NormalizedName = name;
    }
}
