using Bookly.Domain.Entiteti.Bazni;

namespace Bookly.Domain.Entiteti;

public class Rezervacija : Entitet<Guid>
{
    public Rezervacija(Guid id, Apartman apartman, Korisnik korisnik, DateTime datumDolaska, DateTime datumOdlaska) : base(id)
    {
        if (datumDolaska < DateTime.UtcNow || datumOdlaska < DateTime.UtcNow)
            throw new ArgumentException("Uneti datumi moraju biti u buducnosti!");

        if (DateTime.Compare(datumDolaska.Date, datumOdlaska.Date) >= 0)
            throw new ArgumentException("Najam apartmana mora trajati barem jednu noc");

        if (apartman.ProveriDostupnostPoOpseguDatuma(datumDolaska, datumOdlaska) is true)
            throw new ArgumentException("Apartman nije dostupan u ovom opsegu datuma!");

        Apartman = apartman;
        Korisnik = korisnik;
        DatumDolaska = datumDolaska;
        DatumOdlaska = datumOdlaska;
    }
    private Rezervacija() { } // EF Core

    public Apartman Apartman { get; private set; }
    public Korisnik Korisnik { get; private set; }
    public DateTime DatumDolaska { get; private set; }
    public DateTime DatumOdlaska { get; private set; }
}
