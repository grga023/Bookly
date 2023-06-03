namespace Bookly.Domain.Apstrakcije
{
    public interface IIdentityServis
    {
        public Task RegistrujKorisnikaAsync(Guid id, string email, string password);
        public Task UlogujKorisnikaAsync(string email, string password);
        public Task IzlogujKorisnikaAsync();
    }
}
