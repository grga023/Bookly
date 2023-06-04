namespace Bookly.Domain.Apstrakcije
{
    public interface IEmailServis
    {
        public Task PosaljiAsync(string to, string message, string subject);
    }
}
