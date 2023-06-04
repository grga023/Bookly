using Bookly.Domain.Servisi.Korisnik.DTO;
using Bookly.Domain.Servisi.Korisnik;
using Bookly.Domain.Servisi.Smestaj;
using Microsoft.AspNetCore.Mvc;
using Bookly.Domain.Servisi.Smestaj.DTO;

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
        public async Task RegistrujKorisnika(NoviSmestajDTO noviSmestaj) =>
            await _smestajServis.DodavanjeSmestajaAsync(noviSmestaj);
    }
}
