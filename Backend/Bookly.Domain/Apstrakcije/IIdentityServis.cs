namespace Bookly.Domain.Apstrakcije
{
    public interface IIdentityServis
    {
        public Task RegistrujKorisnikaAsync(Guid id, string email, string password);
        public Task UlogujKorisnikaAsync(string email, string password);
        public Task IzlogujKorisnikaAsync();
        public Task<string> PreuzmiTokenZaZaboravljenuSifruAsync(string email);
        public Task ResetujSifruAsync(string email, string token, string noviPassword);
    }
}
