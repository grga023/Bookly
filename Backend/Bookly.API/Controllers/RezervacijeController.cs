using Bookly.API.Utils;
using Bookly.Domain.Servisi.Rezervacija;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Controllers
{
    public class RezervacijeController : BaseController
    {
        public RezervacijaServis _rezervacijaServis;

        public RezervacijeController(RezervacijaServis rezervacijaServis)
        {
            _rezervacijaServis = rezervacijaServis;
        }

        [Authorize]
        [HttpPost]
        public async Task NapraviRezervaciju(Guid apartmanId, DateTime datumDolaska, DateTime datumOdlaska) => 
            await _rezervacijaServis.NapraviRezervacijuAsync(ID, apartmanId, datumDolaska, datumOdlaska);

        [HttpGet("zauzeti-datumi")]
        public async Task<List<DateOnly>> DobaviListuZauzetihDatuma(Guid apartmanId) => 
            await _rezervacijaServis.DobaviSveZauzeteDatumeAsync(apartmanId);

        [HttpPut("odobri-rezervaciju/{id}")]
        public async Task OdobriRezervacijuAsync(Guid id) =>
            await _rezervacijaServis.PromeniStatusRezervacijeAsync(id, Domain.Entiteti.StatusRezervacije.Odobrena);

        [HttpPut("odbij-rezervaciju/{id}")]
        public async Task OdbijRezervacijuAsync(Guid id) =>
            await _rezervacijaServis.PromeniStatusRezervacijeAsync(id, Domain.Entiteti.StatusRezervacije.Odbijena);
    }
}
