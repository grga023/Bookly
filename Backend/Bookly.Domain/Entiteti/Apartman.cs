using Bookly.Domain.Entiteti.Bazni;

namespace Bookly.Domain.Entiteti;

public class Apartman : Entitet<Guid>
{
    public string Naziv { get; private set; }
}
