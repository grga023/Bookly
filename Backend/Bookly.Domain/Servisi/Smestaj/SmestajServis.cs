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
                                                       ocena: noviSmestaj.Ocena,
                                                       opis: noviSmestaj.Opis,
                                                       slike: noviSmestaj.Slike);

            _aplikacioniDbContext.Apartmani.Add(apartmanZaDodati);
            await _aplikacioniDbContext.SaveChangesAsync();
        }

        public async Task<List<PrikazSmestajaDTO>> PrikazSvihSmestaja()
        {
            var apartmani = await _aplikacioniDbContext.Apartmani.ToListAsync();


            List<PrikazSmestajaDTO> lista = new();

            foreach(var apartman in apartmani)
            {
                if (apartman != null)
                {
                    apartman.Slike = await _aplikacioniDbContext.Slike
                        .Where(s => s.ApartmanID == apartman.ID).ToListAsync();
                }

                PrikazSmestajaDTO prikazDTO = new()
                {
                    Naziv = apartman.Naziv,
                    Mesto = apartman.Mesto,
                    Drzava = apartman.Drzava,
                    Ocena = apartman.Ocena,
                    Opis = apartman.Opis,
                    SlikeURL = apartman.Slike.Select(s => s.Url).ToList()
                };

                lista.Add(prikazDTO);
            }

            return lista;

        }

        public async Task<PrikazSmestajaDTO> PrikazSvihSmestajaPoId(Guid id)
        {
            Apartman apartman = await _aplikacioniDbContext.Apartmani.FindAsync(id);

            if (apartman != null)
            {
                apartman.Slike = await _aplikacioniDbContext.Slike
                    .Where(s => s.ApartmanID == id).ToListAsync();
            }

            PrikazSmestajaDTO prikazDTO = new()
            {
                Naziv = apartman.Naziv,
                Mesto = apartman.Mesto,
                Drzava = apartman.Drzava,
                Ocena = apartman.Ocena,
                Opis = apartman.Opis,
                SlikeURL = apartman.Slike.Select(s => s.Url).ToList()
            };

            return prikazDTO;
        }
    }
}
