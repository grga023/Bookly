using Bookly.Domain.Apstrakcije.Baza;
using Bookly.Domain.Entiteti;
using Bookly.Domain.Servisi.Smestaj.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Domain.Servisi.Smestaj
{
    public class SmestajServis
    {
        private readonly IAplikacioniDbContext _aplikacioniDbContext;

        public SmestajServis(IAplikacioniDbContext aplikacioniDbContext)
        {
            _aplikacioniDbContext = aplikacioniDbContext;
        }
        
        public async Task DodavanjeSmestajaAsync(NoviSmestajDTO noviSmestaj)
        {
            Guid noviApartmanId = Guid.NewGuid();
            Entiteti.Apartman apartmanZaDodati = new(id: noviApartmanId,
                                                       naziv: noviSmestaj.Naziv,
                                                       mesto: noviSmestaj.Mesto,
                                                       drzava: noviSmestaj.Drzava,
                                                       cena: noviSmestaj.Cena,
                                                       ocena: noviSmestaj.Ocena,
                                                       opis: noviSmestaj.Opis);

            _aplikacioniDbContext.Apartmani.Add(apartmanZaDodati);
            await _aplikacioniDbContext.SaveChangesAsync();
        }

        public async Task<List<Apartman>> PrikazSvihSmestaja() =>
            await _aplikacioniDbContext.Apartmani.ToListAsync();

        public async Task<Apartman> PrikazSvihSmestajaPoId(Guid id) =>
            await _aplikacioniDbContext.Apartmani.FindAsync(id);
    }
}
