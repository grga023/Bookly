using Bookly.Domain.Entiteti.Bazni;

namespace Bookly.Domain.Entiteti;

public class Apartman : Entitet<Guid>
{
    public string Naziv { get; private set; }
    public string Mesto { get; private set; }
    public string Drzava { get; private set; }
    public double Cena { get; private set; }
    public double Ocena { get; private set; }
    public string Opis { get; private set; }
}
