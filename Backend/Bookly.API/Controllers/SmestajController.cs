﻿using Bookly.Domain.Servisi.Korisnik.DTO;
using Bookly.Domain.Servisi.Korisnik;
using Bookly.Domain.Servisi.Smestaj;
using Microsoft.AspNetCore.Mvc;
using Bookly.Domain.Servisi.Smestaj.DTO;
using Bookly.Domain.Entiteti;

namespace Bookly.API.Controllers
{
    public class SmestajController 
    {
        private readonly SmestajServis _smestajServis;
        public SmestajController(SmestajServis smestajServis)
        {
            _smestajServis = smestajServis;
        }
        [HttpPost]
        public async Task DodavanjeSmestaja(NoviSmestajDTO noviSmestaj) =>
            await _smestajServis.DodavanjeSmestajaAsync(noviSmestaj);

        [HttpGet]
        public async Task<List<PrikazSmestajaDTO>> GetAllSmestajiAsync() =>
            await _smestajServis.PrikazSvihSmestaja();

        [HttpGet("{id}")]
        public async Task<PrikazSmestajaDTO> GetAllSmestajiPoIDAsync(Guid id) =>
            await _smestajServis.PrikazSvihSmestajaPoId(id);
    }
}
