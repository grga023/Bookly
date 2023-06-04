﻿using Bookly.Domain.Entiteti.Bazni;
using System.Runtime.InteropServices;

namespace Bookly.Domain.Entiteti
{
    public class Apartman : Entitet<Guid>
    {
        public string Naziv { get; private set; }
        public string Mesto { get; private set; }
        public string Drzava { get; private set; }
        public double Cena { get; private set; }
        public double Ocena { get; private set; }
        public string Opis { get; private set; }

        public Apartman(Guid id, string naziv, string mesto, string drzava, double cena, double ocena, string opis) : base(id)
        {
            Naziv = naziv;
            Mesto = mesto;
            Drzava = drzava;
            Cena = cena;
            Ocena = ocena;
            Opis = opis;
        }

        public Apartman() { }
    }
}



