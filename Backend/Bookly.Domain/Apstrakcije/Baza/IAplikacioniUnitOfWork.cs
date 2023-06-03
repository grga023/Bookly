namespace Bookly.Domain.Apstrakcije.Baza;

public interface IAplikacioniUnitOfWork
{
    public Task KomitujTransakciju();
    public Task PokreniTransakciju();
    public Task SacuvajIzmene();
}
