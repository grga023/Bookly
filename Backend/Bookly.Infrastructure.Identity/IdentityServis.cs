using Bookly.Domain.Apstrakcije;
using Bookly.Infrastructure.Identity.Entiteti;
using Microsoft.AspNetCore.Identity;

namespace Bookly.Infrastructure.Identity;

public class IdentityServis : IIdentityServis
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public IdentityServis(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task RegistrujKorisnikaAsync(Guid id, string email, string password)
    {
        ApplicationUser noviKorisnik = new(id, email);
        IdentityResult rezultatRegistracije = await _userManager.CreateAsync(noviKorisnik, password);
        if (!rezultatRegistracije.Succeeded)
        {
            throw new ArgumentException(rezultatRegistracije.ToString());
        }
        await _userManager.AddToRoleAsync(noviKorisnik, IdentityUloge.KORISNIK);
    }

    public async Task UlogujKorisnikaAsync(string email, string password)
    {
        SignInResult rezultat = await _signInManager.PasswordSignInAsync(email,
                                                               password,
                                                               isPersistent: false,
                                                               lockoutOnFailure: false);

        if (!rezultat.Succeeded)
            throw new ArgumentException(rezultat.ToString());
    }

    public async Task IzlogujKorisnikaAsync() => 
        await _signInManager.SignOutAsync();
}
