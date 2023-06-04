using Bookly.API.Modeli.Request;
using Bookly.API.Utils;
using Bookly.Domain.Servisi.Korisnik;
using Bookly.Domain.Servisi.Korisnik.DTO;
using Bookly.Infrastructure.Identity;
using Bookly.Infrastructure.Identity.Entiteti;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bookly.API.Controllers
{
    public class KorisniciController : BaseController
    {
        private readonly KorisnikServis _korisnikServis;
        public KorisniciController(KorisnikServis korisnikServis)
        {
            _korisnikServis = korisnikServis;
        }

        [HttpPost("registracija")]
        public async Task RegistrujKorisnika(NoviKorisnikDTO noviKorisnik) => 
            await _korisnikServis.DodajKorisnikaAsync(noviKorisnik);

        [HttpPost("login")]
        public async Task UlogujKorisnika(LoginRequestModel loginRequest) => 
            await _korisnikServis.UlogujKorisnikAsync(loginRequest.Email, loginRequest.Password);

        [HttpPost("logout")]
        public async Task IzlogujKorisnika() => await _korisnikServis.IzlogujKorisnikaAsync();

        [HttpGet("token-zaboravljena-sifra")]
        public async Task GenerisiTokenZaboravljeneSifre(string email) => 
            await _korisnikServis.GenerisiTokenZaResetovanjeSifreAsync(email);

        [HttpPost("resetuj-sifru")]
        public async Task ResetujSifru(string email, string token, string novaLozinka) =>
            await _korisnikServis.ResetujSifruAsync(email, token, novaLozinka);

        [HttpPut]
        [Authorize(Roles = IdentityUloge.KORISNIK)]
        public async Task ModifikujKorisnika(NoviKorisnikDTO izmenjeniKorisnikDto) =>
            await _korisnikServis.ModifikujKorisnikaAsync(ID, izmenjeniKorisnikDto);
    }
}
