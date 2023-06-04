﻿using Bookly.Domain.Apstrakcije;
using Bookly.Domain.Apstrakcije.Baza;
using Bookly.Domain.Servisi.Korisnik.DTO;
using Entiteti = Bookly.Domain.Entiteti; 

namespace Bookly.Domain.Servisi.Korisnik;

public class KorisnikServis
{
    private readonly IIdentityServis _identityServis;
    private readonly IAplikacioniDbContext _aplikacioniDbContext;
    private readonly IAplikacioniUnitOfWork _aplikacioniUnitOfWork;
    private readonly IEmailServis _emailServis;

    public KorisnikServis(IIdentityServis identityServis, IAplikacioniDbContext aplikacioniDbContext, IAplikacioniUnitOfWork aplikacioniUnitOfWork, IEmailServis emailServis)
    {
        _identityServis = identityServis;
        _aplikacioniUnitOfWork = aplikacioniUnitOfWork;
        _aplikacioniDbContext = aplikacioniDbContext;
        _emailServis = emailServis;
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

    public async Task GenerisiTokenZaResetovanjeSifreAsync(string email)
    {
        string token = await _identityServis.PreuzmiTokenZaZaboravljenuSifruAsync(email);
        await _emailServis.PosaljiAsync(email, $"Vas token za resetovanje lozinke je: {token}", "Resetovanje lozinke");
    }

    public async Task ResetujSifruAsync(string email, string token, string noviPassword) => 
        await _identityServis.ResetujSifruAsync(email, token, noviPassword);
}