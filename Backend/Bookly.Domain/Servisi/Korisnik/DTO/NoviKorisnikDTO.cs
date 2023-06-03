namespace Bookly.Domain.Servisi.Korisnik.DTO
{
    public class NoviKorisnikDTO
    {
        public NoviKorisnikDTO(string ime, string prezime, string email, string password, DateTime datumRodjenja, string adresa)
        {
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Password = password;
            DatumRodjenja = datumRodjenja;
            Adresa = adresa;
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
    }
}
