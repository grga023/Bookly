using Bookly.Domain.Servisi.Korisnik.DTO;
using Bookly.Domain.Servisi.Korisnik;
using Bookly.Domain.Servisi.Smestaj;
using Microsoft.AspNetCore.Mvc;
using Bookly.Domain.Servisi.Smestaj.DTO;
using Bookly.Domain.Entiteti;
using Bookly.API.Utils;
using Microsoft.AspNetCore.Authorization;

namespace Bookly.API.Controllers
{
    public class SmestajController : BaseController
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
        public async Task<List<Apartman>> GetAllSmestajiAsync() =>
            await _smestajServis.PrikazSvihSmestaja();

        [HttpGet("{id}")]
        public async Task<Apartman> GetAllSmestajiPoIDAsync(Guid id) =>
            await _smestajServis.PrikazSvihSmestajaPoId(id);

        [HttpPut("ocena-smestaja/{apartmanId}")]
        [Authorize]
        public async Task OceniSmestajAsync(Guid apartmanId, uint ocena)
        {
            if(ocena < 1 && ocena > 5)
                throw new ArgumentOutOfRangeException(nameof(ocena),"Ocena nije validna. Molimo vas unesite vrednost od 1 do 5");

            await _smestajServis.OceniSmestajAsync(ID, apartmanId, ocena);
        }
    }
}
