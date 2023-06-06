import { useState } from "react";

export default function Registracija() {
  const [izabraniDatum, postaviIzabraniDatum] = useState(new Date());
  const [ime, postaviIme] = useState("");
  const [prezime, postaviPrezime] = useState("");
  const [email, postaviEmail] = useState("");
  const [adresa, postaviAdresu] = useState("");
  const [sifra, postaviSifru] = useState("");
  const [formaValidna, postaviFormaValidna] = useState(false);

  const [imeError, postaviImeError] = useState('');
  const [prezimeError, postaviPrezimeError] = useState('');
  const [emailError, postaviEmailError] = useState('');
  const [sifraError, postaviSifraError] = useState('');
  const [adresaError, postaviAdresaError] = useState('');
  const [datumError, postaviDatumError] = useState('');

  const validirajDatum = (datum) => {
    const izabraniDatum = new Date(datum);
    const danasnjiDatum = new Date();
    const razlika = danasnjiDatum.getFullYear() - izabraniDatum.getFullYear();

    return razlika >= 18;
  }

  const validirajSifru = (sifra) => {
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+{};:,<.>])[a-zA-Z\d!@#$%^&*()\-_=+{};:,<.>]{8,}$/;

    return regex.test(sifra);
  }

  const validirajMejl = (mejl) => {
    const regex = /\S+@\S+\.\S+/;

    return regex.test(mejl);
  }

  const validirajFormu = () => {
    let validnaForma = true;

    if (ime.trim() === '') {
      postaviImeError('Polje "Ime" je obavezno');
      validnaForma = false;
    } else {
      postaviImeError('');
    }

    if (prezime.trim() === '') {
      postaviPrezimeError('Polje "Prezime" je obavezno');
      validnaForma = false;
    } else {
      postaviPrezimeError('');
    }

    if (email.trim() === '') {
      postaviEmailError('Polje "E-mail adresa" je obavezno');
      validnaForma = false;
    } else if (!validirajMejl(email)) {
      postaviEmailError('Unesite ispravan e-mail format');
      validnaForma = false;
    } else {
      postaviEmailError('');
    }

    if (sifra.trim() === '') {
      postaviSifraError('Polje "Šifra" je obavezno');
      validnaForma = false;
    } else if (!validirajSifru(sifra)){
      postaviSifraError('Šifra nije dovoljno jaka');
      validnaForma = false;
    } else {
      postaviSifraError('');
    }

    if (adresa.trim() === '') {
      postaviAdresaError('Polje "Adresa" je obavezno');
      validnaForma = false;
    } else {
      postaviAdresaError('');
    }

    const validanDatum = validirajDatum(izabraniDatum);
    if(!validanDatum){
      postaviDatumError('Nemate 18 godina');
      validnaForma = false;
    } else {
      postaviDatumError('');
    }

    return validnaForma;
  }

  const submitovanjeForme = (e) => {
    e.preventDefault();
    postaviFormaValidna(validirajFormu());

    if(formaValidna){
      console.log('validna')
    } else return;
  }

  return (
    <section className="grid h-full place-items-center" aria-label="Napravi novi profil na aplikaciji">
      <h1>Registracija</h1>
      <form className="container-form grid grid-cols-6 gap-4" onSubmit={submitovanjeForme} noValidate>
        <div className="grid col-span-3">
          <div className="flex items-center justify-between">
            <label htmlFor="ime">Ime</label>
            <span className={`${imeError ? 'error error--aktivan' : 'error'}`}>{imeError}</span>
          </div>
          <input type="text" id="ime" name="ime" placeholder="Petar" value={ime} onChange={(e) => postaviIme(e.target.value)} className={`form-input ${imeError ? 'border-accent' : ''}`} />
        </div>
        <div className="grid col-start-4 col-span-3">
          <div className="flex items-center justify-between">
            <label htmlFor="prezime">Prezime</label>
            <span className={`${prezimeError ? 'error error--aktivan' : 'error'}`}>{prezimeError}</span>
          </div>
          <input type="text" id="prezime" name="prezime" placeholder="Petrovic" value={prezime} onChange={(e) => postaviPrezime(e.target.value)} className={`form-input ${prezimeError ? 'border-accent' : ''}`} />
        </div>
        <div className="grid col-span-6">
          <div className="flex items-center justify-between">
            <label htmlFor="email">Email adresa</label>
            <span className={`${emailError ? 'error error--aktivan' : 'error'}`}>{emailError}</span>
          </div>
          <input type="email" id="email" name="email" placeholder="petar.petrovic@gmail.com" value={email} onChange={(e) => postaviEmail(e.target.value)} className={`form-input ${emailError ? 'border-accent' : ''}`} />
        </div>
        <div className="grid col-span-6">
          <div className="flex items-center justify-between">
            <label htmlFor="sifra">Šifra</label>
            <span className={`${sifraError ? 'error error--aktivan' : 'error'}`}>{sifraError}</span>
          </div>
          <input type="password" id="sifra" name="sifra" placeholder="s91D0?s90._a" value={sifra} onChange={(e) => postaviSifru(e.target.value)} className={`form-input ${sifraError ? 'border-accent' : ''}`} />
        </div>
        <div className="grid col-span-3">
          <div className="flex items-center justify-between">
            <label htmlFor="adresa">Adresa</label>
            <span className={`${adresaError ? 'error error--aktivan' : 'error'}`}>{adresaError}</span>
          </div>
          <input type="text" id="adresa" name="adresa" placeholder="Bulevar Oslobođenja 22" value={adresa} onChange={(e) => postaviAdresu(e.target.value)} className={`form-input ${adresaError ? 'border-accent' : ''}`} />
        </div>
        <div className="grid col-span-3">
          <div className="flex items-center justify-between">
            <label htmlFor="datumRodjenja">Datum rođenja</label>
            <span className={`${datumError ? 'error error--aktivan' : 'error'}`}>{datumError}</span>
          </div>
          <input type="date" name="datumRodjenja" id="datumRodjenja" value={izabraniDatum} onChange={(e) => postaviIzabraniDatum(e.target.value)} className={`form-input ${datumError ? 'border-accent' : ''}`} />
        </div>
        <button type="submit" className="btn btn-primary col-span-2">Registruj se</button>
      </form>
    </section>
  )
}
