using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Domain.Entiteti.Bazni
{
    public class Slike : Entitet<Guid>
    {
        public string Url { get;  set; }
        public string Opis { get;  set; }
        public Guid ApartmanID { get; set; }
        public Slike(Guid id, string url, string opis) : base(id)
        {
            Url = url;
            Opis = opis;
            ApartmanID = id;
        }
        public Slike() { }
    }
}
