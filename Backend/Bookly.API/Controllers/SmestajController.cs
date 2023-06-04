using Bookly.Domain.Servisi.Korisnik.DTO;
using Bookly.Domain.Servisi.Korisnik;
using Bookly.Domain.Servisi.Smestaj;
using Microsoft.AspNetCore.Mvc;
using Bookly.Domain.Servisi.Smestaj.DTO;
using Bookly.Domain.Entiteti;

namespace Bookly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmestajController : ControllerBase
    {
        private readonly SmestajServis _smestajServis;
        public SmestajController(SmestajServis smestajServis)
        {
            _smestajServis = smestajServis;
        }
        [HttpPost("dodavanje-smesaja")]
        public async Task DodavanjeSmestaja(NoviSmestajDTO noviSmestaj) =>
            await _smestajServis.DodavanjeSmestajaAsync(noviSmestaj);

        [HttpGet("prikaz-svih-smestaja")]
        public async Task<List<Apartman>> GetAllSmestajiAsync() =>
            await _smestajServis.PrikazSvihSmestaja();

        [HttpGet("prikaz-smestaja-po-id")]
        public async Task<Apartman> GetAllSmestajiPoIDAsync(Guid id) =>
            await _smestajServis.PrikazSvihSmestajaPoId(id);
    }
}
