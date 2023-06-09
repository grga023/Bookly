using Bookly.Domain.Apstrakcije;
using Bookly.Domain.Apstrakcije.Baza;
using Bookly.Domain.Entiteti;
using Microsoft.EntityFrameworkCore;
using Entiteti = Bookly.Domain.Entiteti;

namespace Bookly.Domain.Servisi.Rezervacija;

public class RezervacijaServis
{
    private readonly IAplikacioniDbContext _aplikacioniDbContext;
    private readonly IEmailServis _emailServis;
    public RezervacijaServis(IAplikacioniDbContext aplikacioniDbContext, IEmailServis emailServis)
    {
        _aplikacioniDbContext = aplikacioniDbContext;
        _emailServis = emailServis;
    }

    public async Task NapraviRezervacijuAsync(Guid korisnikid, Guid apartmanId, DateTime datumDolaska, DateTime datumOdlaska)
    {
        Entiteti.Apartman? apartman = await _aplikacioniDbContext.Apartmani.Where(x => x.ID == apartmanId)
                                                                           .Include(y => y.Rezervacije)
                                                                           .FirstOrDefaultAsync() ?? 
                                                                           throw new KeyNotFoundException("Uneti apartman ne postoji!");

        Entiteti.Korisnik? korisnik = await _aplikacioniDbContext.Kornisici.FindAsync(korisnikid) 
            ?? throw new KeyNotFoundException("Uneti korisnik ne postoji!");

        Entiteti.Rezervacija novaRezervacija = new(Guid.NewGuid(), apartman, korisnik, datumDolaska, datumOdlaska);

        _aplikacioniDbContext.Rezervacije.Add(novaRezervacija);
        await _aplikacioniDbContext.SaveChangesAsync();

        await _emailServis.PosaljiAsync(to: korisnik.Email, 
                                        message: $"Uspesno ste kreirali zahtev za rezervaciju apartmana: {apartman.Naziv} u periodu od {datumDolaska.Date} do {datumOdlaska.Date}.", 
                                        subject: "Zahtev za rezervaciju apartmana");
    }

    public async Task<List<DateOnly>> DobaviSveZauzeteDatumeAsync(Guid apartmanId)
    {
        Entiteti.Apartman? apartman = await _aplikacioniDbContext.Apartmani.Where(x => x.ID == apartmanId)
                                                                   .Include(y => y.Rezervacije.Where(x=>x.DatumDolaska > DateTime.Now && x.DatumOdlaska > DateTime.Now))
                                                                   .FirstOrDefaultAsync() ??
                                                                   throw new KeyNotFoundException("Uneti apartman ne postoji!");
        List<DateOnly> zauzetiDatumi = new();
        foreach(Entiteti.Rezervacija rezervacija in apartman.Rezervacije)
        {
            for(DateOnly pocetniDatum = DateOnly.FromDateTime(rezervacija.DatumDolaska); pocetniDatum.Day <= DateOnly.FromDateTime(rezervacija.DatumOdlaska).Day; pocetniDatum = pocetniDatum.AddDays(1))
            {
                zauzetiDatumi.Add(pocetniDatum);
            }
        }

        return zauzetiDatumi;
    }

    public async Task PromeniStatusRezervacijeAsync(Guid rezervacijaId, StatusRezervacije noviStatusRezervacije)
    {
        Entiteti.Rezervacija rezervacijaZaIzmeniti = await _aplikacioniDbContext.Rezervacije.Include(x=>x.Korisnik).FirstOrDefaultAsync(x=>x.ID == rezervacijaId) ?? 
            throw new KeyNotFoundException("Uneta rezervacija ne postoji!");

        rezervacijaZaIzmeniti.PromeniStatusRezervacije(noviStatusRezervacije);
        await _aplikacioniDbContext.SaveChangesAsync();

        string statusRezervacijePoruka = noviStatusRezervacije switch
        {
            StatusRezervacije.Odbijena => "odbijena",
            StatusRezervacije.Odobrena => "odobrena",
            _ => throw new ArgumentOutOfRangeException("Status ne postoji")
        };

        await _emailServis.PosaljiAsync(
            rezervacijaZaIzmeniti.Korisnik.Email, 
            $"Vasa rezervacija sa brojem: {rezervacijaId} je {statusRezervacijePoruka}", 
            "Promenjen status rezervacije");
    }
}
