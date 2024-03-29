import { useState, useContext } from "react";
import { useNavigate } from "react-router-dom";

import { validirajSifru } from "../funkcije";
import { AuthContext } from "../App";

export default function Login() {
  const [email, postaviEmail] = useState("");
  const [sifra, postaviSifru] = useState("");
  const [novaSifra, postaviNovuSifru] = useState("");
  const [token, postaviToken] = useState('');
  const [tokenError, postaviTokenError] = useState('');
  const [emailError, postaviEmailError] = useState('');
  const [sifraError, postaviSifraError] = useState('');
  const [novaSifraError, postaviNovaSifraError] = useState('');
  const [zaboravljenaSifraOdabrano, postaviZaboravljenaSifraOdabrano] = useState(false)
  const [logovanjeKorisnika, postaviLogovanje] = useState(false);
  const ctx = useContext(AuthContext);
  const navigacija = useNavigate();

  const validirajFormu = () => {
    let validnaForma = true;

    if (email.trim() === '') {
      postaviEmailError('Polje "E-mail adresa" je obavezno');
      validnaForma = false;
    } else {
      postaviEmailError('');
    }

    if (sifra.trim() === '') {
      postaviSifraError('Polje "Šifra" je obavezno');
      validnaForma = false;
    } else {
      postaviSifraError('');
    }

    return validnaForma;
  }

  const validirajPromenuSifre = () => {
    let validnaForma = true;

    if (email.trim() === '') {
      postaviEmailError('Polje "E-mail adresa" je obavezno');
      validnaForma = false;
    } else {
      postaviEmailError('');
    }

    if (token.trim() === '') {
      postaviTokenError('Polje "Token" je obavezno');
      validnaForma = false;
    } else {
      postaviTokenError('');
    }

     if (novaSifra.trim() === '') {
      postaviNovaSifraError('Polje "Nova šifra" je obavezno');
      validnaForma = false;
    } else if (!validirajSifru(novaSifra)){
      postaviNovaSifraError('Šifra nije dovoljno jaka');
      validnaForma = false;
    } else {
      postaviNovaSifraError('');
    }

    return validnaForma;
  }

  async function ulogujKorisnika(korisnik){
    postaviLogovanje(true);

    try {
      const odgovor = await fetch("http://localhost:4300/api/Korisnici/login", {
        method: "POST",
        credentials: "include",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(korisnik)
      })

      postaviEmail("");
      postaviSifru("");
      ctx.postaviUlogovan(true);
      navigacija('/');
      
    } catch (error) {
      postaviEmailError("Uneti netačni podaci");
      postaviSifraError("Uneti netačni podaci");
    }
    
    postaviLogovanje(false);
  }

  const logovanje = (e) => {
    e.preventDefault();
    const validnaForma = validirajFormu();
    const korisnik = {
      email,
      password: sifra
    }
      
    validnaForma && ulogujKorisnika(korisnik);
  }

  const posaljiToken = async () => {
    try {
      const odgovor = await fetch(`http://localhost:4300/api/Korisnici/token-zaboravljena-sifra?email=${encodeURIComponent(email)}`);
    } catch (error) {
      console.log(error)
    }
  }

  const resetujSifru = async () => {
    try {
        const odgovor = await fetch(`http://localhost:4300/api/Korisnici/resetuj-sifru?email=${encodeURIComponent(email)}&token=${encodeURIComponent(token)}&novaLozinka=${novaSifra}`, {
        method: "POST"
      });

      if(odgovor.ok){
        navigacija("/");
        ulogujKorisnika({email, password: novaSifra})
        postaviZaboravljenaSifraOdabrano(false);
      }

    } catch (error) {
      console.log(error)
    }
  }

  const promenaSifre = (e) => {
    e.preventDefault();

    const validnaForma = validirajPromenuSifre();

    if(validnaForma){
      resetujSifru();
    } else return;
  }

  return (
    <section className="grid" aria-label="Napravi novi profil na aplikaciji">
      <h1 className="mb-12 text-center">{zaboravljenaSifraOdabrano ? "Promena šifre" : "Uloguj se"}</h1>
      {!zaboravljenaSifraOdabrano && <form className="container-form-mini mx-auto grid gap-4" onSubmit={logovanje} noValidate>
        <div>
          <div className="flex items-center justify-between">
            <label htmlFor="email">Email adresa</label>
            <span className={`${emailError ? 'error error--aktivan' : 'error'}`}>{emailError}</span>
          </div>
          <input type="email" id="email" name="email" placeholder="petar.petrovic@gmail.com" value={email} onChange={(e) => postaviEmail(e.target.value)} className={`form-input ${emailError ? 'border-accent' : ''}`} />
        </div>
        <div>
          <div className="flex items-center justify-between">
            <label htmlFor="sifra">Šifra</label>
            <span className={`${sifraError ? 'error error--aktivan' : 'error'}`}>{sifraError}</span>
          </div>
          <input type="password" id="sifra" name="sifra" placeholder="s91D0?s90._a" value={sifra} onChange={(e) => postaviSifru(e.target.value)} className={`form-input ${sifraError ? 'border-accent' : ''}`} />
        </div>
        <div className="flex items-center justify-between">
          <button type="submit" className="btn btn-primary px-12" disabled={logovanjeKorisnika}>{logovanjeKorisnika ? "Logovanje..." : "Uloguj se"}</button>
          <button type="button" className="cursor-pointer text-primary hover:underline" onClick={() => {
            postaviZaboravljenaSifraOdabrano(true);
            posaljiToken();
          }}>Zaboravljena šifra?</button>
        </div>
      </form>}
      {zaboravljenaSifraOdabrano && <form className="container-form-mini mx-auto grid gap-4" onSubmit={promenaSifre} noValidate>
           <div>
          <div className="flex items-center justify-between">
            <label htmlFor="email">Email adresa</label>
            <span className={`${emailError ? 'error error--aktivan' : 'error'}`}>{emailError}</span>
          </div>
          <input type="email" id="email" name="email" placeholder="petar.petrovic@gmail.com" value={email} onChange={(e) => postaviEmail(e.target.value)} className={`form-input ${emailError ? 'border-accent' : ''}`} />
        </div>
           <div>
          <div className="flex items-center justify-between">
            <label htmlFor="token">Token (unesi sa email-a)</label>
            <span className={`${tokenError ? 'error error--aktivan' : 'error'}`}>{tokenError}</span>
          </div>
          <input type="text" id="token" name="token" placeholder="aieojda8931mcad" value={token} onChange={(e) => postaviToken(e.target.value)} className={`form-input ${tokenError ? 'border-accent' : ''}`} />
        </div>
        <div>
          <div className="flex items-center justify-between">
            <label htmlFor="novaSifra">Nova šifra</label>
            <span className={`${novaSifraError ? 'error error--aktivan' : 'error'}`}>{novaSifraError}</span>
          </div>
          <input type="password" id="sifra" name="novaSifra" placeholder="s91D0?s90._a" value={novaSifra} onChange={(e) => postaviNovuSifru(e.target.value)} className={`form-input ${novaSifraError ? 'border-accent' : ''}`} />
        </div>
        <div className="flex items-center justify-between">
          <button type="submit" className="btn btn-primary px-12">Promeni šifru</button>
        </div>
        </form>}
    </section>
  )
}
