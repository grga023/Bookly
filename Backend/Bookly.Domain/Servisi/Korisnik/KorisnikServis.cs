using Bookly.Domain.Apstrakcije;
using Bookly.Domain.Apstrakcije.Baza;
using Bookly.Domain.Servisi.Korisnik.DTO;
using Entiteti = Bookly.Domain.Entiteti; 

namespace Bookly.Domain.Servisi.Korisnik;

public class KorisnikServis
{
    private readonly IIdentityServis _identityServis;
    private readonly IAplikacioniDbContext _aplikacioniDbContext;
    private readonly IAplikacioniUnitOfWork _aplikacioniUnitOfWork;

    public KorisnikServis(IIdentityServis identityServis, IAplikacioniDbContext aplikacioniDbContext, IAplikacioniUnitOfWork aplikacioniUnitOfWork)
    {
        _identityServis = identityServis;
        _aplikacioniUnitOfWork = aplikacioniUnitOfWork;
        _aplikacioniDbContext = aplikacioniDbContext;
    }

    public async Task DodajKorisnikaAsync(NoviKorisnikDTO noviKorisnik)
    {
        Guid noviKorisnikId = Guid.NewGuid();
        Entiteti.Korisnik korisnikZaDodati = new(id: noviKorisnikId, 
                                                 ime: noviKorisnik.Ime,
                                                 prezime: noviKorisnik.Prezime,
                                                 email: noviKorisnik.Email,
                                                 datumRodjenja: noviKorisnik.DatumRodjenja,
                                                 adresa: noviKorisnik.Adresa);
        await _aplikacioniUnitOfWork.PokreniTransakciju();
        _aplikacioniDbContext.Kornisici.Add(korisnikZaDodati);
        await _aplikacioniUnitOfWork.SacuvajIzmene();
        await _identityServis.RegistrujKorisnikaAsync(noviKorisnikId, noviKorisnik.Email, noviKorisnik.Password);
        await _aplikacioniUnitOfWork.KomitujTransakciju();
    }

    public async Task UlogujKorisnikAsync(string email, string password) =>
        await _identityServis.UlogujKorisnikaAsync(email, password);

    public async Task IzlogujKorisnikaAsync() => 
        await _identityServis.IzlogujKorisnikaAsync();
}
