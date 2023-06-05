import { useState } from "react";

export default function Registracija() {
  const [izabraniDatum, postaviIzabraniDatum] = useState(new Date());

  return (
    <section className="grid h-full place-items-center" aria-label="Napravi novi profil na aplikaciji">
      <form className="container-form grid grid-cols-4 gap-3">
        <div className="grid col-span-2">
          <label htmlFor="ime">Ime</label>
          <input type="text" id="ime" name="ime" placeholder="Petar" className="form-input" />
        </div>
        <div className="grid col-span-2">
          <label htmlFor="prezime">Prezime</label>
          <input type="text" id="prezime" name="prezime" placeholder="Petrovic" className="form-input" />
        </div>
        <div className="grid col-span-4">
          <label htmlFor="email">E-mail adresa</label>
          <input type="email" id="email" name="email" placeholder="petar.petrovic@gmail.com" className="form-input" />
        </div>
        <div className="grid col-span-4">
          <label htmlFor="sifra">Šifra</label>
          <input type="password" id="sifra" name="sifra" placeholder="s91D0?s90._a" className="form-input" />
        </div>
        <div className="grid col-span-3">
          <label htmlFor="adresa">Adresa</label>
          <input type="text" id="adresa" name="adresa" placeholder="Bulevar Oslobođenja 22" className="form-input" />
        </div>
        <div className="grid col-span-1">
          <label htmlFor="datumRodjenja">Datum rođenja</label>
          <input type="date" name="datumRodjenja" id="datumRodjenja" value={izabraniDatum} onChange={(datum) => postaviIzabraniDatum(datum)} />
        </div>
      </form>
    </section>
  )
}
