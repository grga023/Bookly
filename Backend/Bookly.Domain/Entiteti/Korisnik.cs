using Bookly.Domain.Entiteti.Bazni;

namespace Bookly.Domain.Entiteti
{
    public class Korisnik : Entitet<Guid>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }

        public Korisnik(Guid id, string ime, string prezime, string email, DateTime datumRodjenja, string adresa) : base(id)
        {
            Ime = ime;
            Prezime = prezime;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Adresa = adresa;
        }

        private Korisnik() { } //EF Core
    }
}
