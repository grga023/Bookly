using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Domain.Servisi.Smestaj.DTO
{
    public class NoviSmestajDTO
    {
        public string Naziv { get; private set; }
        public string Mesto { get; private set; }
        public string Drzava { get; private set; }
        public double Cena { get; private set; }
        public double Ocena { get; private set; }
        public string Opis { get; private set; }

        public NoviSmestajDTO(string naziv, string mesto, string drzava, double cena, double ocena, string opis) 
        {
            Naziv = naziv;
            Mesto = mesto;
            Drzava = drzava;
            Cena = cena;
            Ocena = ocena;
            Opis = opis;
        }
    }
}
