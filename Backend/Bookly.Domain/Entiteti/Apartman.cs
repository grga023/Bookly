﻿using Bookly.Domain.Ekstenzije;
using Bookly.Domain.Entiteti.Bazni;
using System.Text;

namespace Bookly.Domain.Entiteti
{
    public class Apartman : Entitet<Guid>
    {
        public string Naziv { get; private set; }
        public string Mesto { get; private set; }
        public string Drzava { get; private set; }
        public double Ocena { get; private set; }
        public decimal Cena { get; set; }
        public string Opis { get; private set; }
        public List<Slike> Slike { get; set; } = new();
        public List<Rezervacija> Rezervacije { get; set; } = new();

        public Apartman(Guid id, string naziv, string mesto, string drzava, decimal cena, double ocena, string opis, List<Slike> slike) : base(id)
        {
            Naziv = naziv;
            Mesto = mesto;
            Drzava = drzava;
            Cena = cena;
            Ocena = ocena;
            Opis = opis;
            Slike = slike;
        }

        private Apartman() { }

        public bool ProveriDostupnostPoOpseguDatuma(DateTime pocetniDatum, DateTime kranjiDatum)
        {
            return Rezervacije.Where(
                                rezervacija =>
                                pocetniDatum.DatumUOpsegu(rezervacija.DatumDolaska, rezervacija.DatumDolaska) &&
                                kranjiDatum.DatumUOpsegu(rezervacija.DatumDolaska, rezervacija.DatumDolaska))
                              .Any();
        }

        public void PromeniOcenuApartmana(uint ocena)
        {
            Ocena = (Ocena + ocena)/2;
        }
    }
}



