import { useState } from "react";

export default function Login() {
  const [email, postaviEmail] = useState("");
  const [sifra, postaviSifru] = useState("");
  const [emailError, postaviEmailError] = useState('');
  const [sifraError, postaviSifraError] = useState('');
  const [formaValidna, postaviFormaValidna] = useState(false);

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

  const submitovanjeForme = (e) => {
    e.preventDefault();
    postaviFormaValidna(validirajFormu());

    if(formaValidna){
      console.log('logged in')
    } else return;
  }

  return (
    <section className="grid" aria-label="Napravi novi profil na aplikaciji">
      <h1 className="mb-12 text-center">Uloguj se</h1>
      <form className="container-form-mini mx-auto grid gap-4" onSubmit={submitovanjeForme} noValidate>
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
          <button type="submit" className="btn btn-primary px-12">Uloguj se</button>
          <button type="button" className="cursor-pointer text-primary hover:underline">Zaboravljena šifra?</button>
        </div>
      </form>
    </section>
  )
}
