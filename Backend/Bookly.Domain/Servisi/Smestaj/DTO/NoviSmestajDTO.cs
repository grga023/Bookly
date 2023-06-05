using Bookly.Domain.Entiteti.Bazni;

namespace Bookly.Domain.Servisi.Smestaj.DTO
{
    public class NoviSmestajDTO
    {
        public string Naziv { get; set; }
        public string Mesto { get; set; }
        public string Drzava { get; set; }
        public double Ocena { get; set; }
        public string Opis { get; set; }
        public List<Slike> Slike { get; set; } = new();
    }
}
