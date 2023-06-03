using Microsoft.AspNetCore.Identity;

namespace Bookly.Infrastructure.Identity.Entiteti
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser(Guid id, string email)
        {
            Id = id;
            Email = email;
            UserName = email;
        }
    }
}
