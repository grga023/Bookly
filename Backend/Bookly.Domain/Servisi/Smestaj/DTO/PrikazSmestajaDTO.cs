using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Domain.Servisi.Smestaj.DTO
{
    public class PrikazSmestajaDTO
    {
        public string Naziv { get; set; }
        public string Mesto { get; set; }
        public string Drzava { get; set; }
        public double Ocena { get; set; }
        public string Opis { get; set; }
        public List<string> SlikeURL { get; set; }
    }
}
