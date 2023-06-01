namespace Bookly.Domain.Entiteti.Bazni;

public class Entitet<TId>
{
    public TId ID { get; private set; }

    protected Entitet(TId id)
    {
        ID = id;
    }
    protected Entitet()
    {
    }
}
