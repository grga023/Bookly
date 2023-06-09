import { useParams } from "react-router-dom"
import { formatirajOcenu, brojKaoDinar } from "../funkcije";
import { useState, useEffect, useContext } from "react";
import { Link } from "react-router-dom";
import ulogujSe from "../slike/ulogujse.svg";
import { AuthContext } from "../App";

const izracunajBrojNocenja = (datumPrijave, datumOdjave) => {
  const prijava = new Date(datumPrijave);
  const odjava = new Date(datumOdjave);
  const razlika = Math.abs(odjava - prijava);
  const brojNocenja = Math.ceil(razlika / (1000 * 60 * 60 * 24));
  
  return brojNocenja;
}

export default function Smestaj() {
  const [datumPrijave, postaviDatumPrijave] = useState('');
  const [datumOdjave, postaviDatumOdjave] = useState('');
  const [datumError, postaviDatumError] = useState(false);
  const { id } = useParams();
  const [smestaj, setSmestaj] = useState(null);
  const ctx = useContext(AuthContext);
  
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(`http://localhost:4300/api/Smestaj/${id}`);
        const data = await response.json();
        setSmestaj(data);
      } catch (error) {
        console.error('Greska prilikom dobijanja podataka:', error);
      }
    };
    
    fetchData();
  }, [id]);
  
  const napraviRezervaciju = async (e) => {
    e.preventDefault();

    const url = `http://localhost:4300/api/Rezervacije?apartmanId=${id}&datumDolaska=${datumPrijave}&datumOdlaska=${datumOdjave}`;

    try {
      const odgovor = await fetch(url, {
        method: "POST",
        credentials: "include",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          apartmanId: id,
          datumDolaska: datumPrijave,
          datumOdlaska: datumOdjave
        })
      });


      alert("Uspesno ste izvrsili rezervaciju!")
      postaviDatumOdjave("");
      postaviDatumPrijave("");

    } catch (error) {
      postaviDatumError(true);
    }
  }

  const minDatumPrijave = new Date().toISOString().split('T')[0];
  const sutra = new Date();
  sutra.setDate(sutra.getDate() + 1);
  const minDatumOdjave = sutra.toISOString().split('T')[0];

  const odabraniBrojNocenja = izracunajBrojNocenja(datumPrijave, datumOdjave);
  const ispravniDatumi = datumPrijave !== '' && datumOdjave !== '' && odabraniBrojNocenja > 0;
  const cenaRezervacije = brojKaoDinar(odabraniBrojNocenja * smestaj?.cena);

  return (
    <section>
      <h1>{smestaj?.naziv}</h1>
      <div className="grid gap-12 grid-cols-5 mt-4">
        <div className="col-span-3 flex flex-col justify-between">
          <p className="text-justify">{smestaj?.opis}</p>
          <div className=" flex items-center justify-between">
            <div>
              <p className="font-medium">Mesto: <span className="font-normal text-primary">{smestaj?.mesto}, {smestaj?.drzava}</span></p>
              <p className="font-medium">Cena noćenja: <span className="font-normal text-primary">{brojKaoDinar(smestaj?.cena)}</span></p>
              <p className="font-medium">Ocena smeštaja: <span className="font-normal text-primary">{formatirajOcenu(smestaj?.ocena)}</span>/10</p>
            </div>
            <form className="mt-12 grid grid-cols-2 gap-3 w-1/2" onSubmit={napraviRezervaciju}>
              <div>
                <div className="flex items-center justify-between">
                  <label htmlFor="datumPrijave">Datum prijave</label>
                </div>
                <input type="date" name="datumPrijave" id="datumPrijave" className={`form-input ${datumError ? 'border-accent' : ''}`} value={datumPrijave} min={minDatumPrijave} onChange={(e) => postaviDatumPrijave(e.target.value)} />
              </div>
              <div>
                <div className="flex items-center justify-between">
                  <label htmlFor="datumOdjave">Datum odjave</label>
                </div>
                <input type="date" name="datumOdjave" id="datumOdjave" className={`form-input ${datumError ? 'border-accent' : ''}`} value={datumOdjave} min={minDatumOdjave} onChange={(e) => postaviDatumOdjave(e.target.value)} />
              </div>
              <div className="col-span-2 flex items-center gap-3">
                <button className="btn btn-primary w-1/2" disabled={!ispravniDatumi || !ctx.ulogovan} onClick={napraviRezervaciju}>Rezerviši</button>
                {ispravniDatumi && <div className="w-1/2">
                  <p className="font-medium">Broj noćenja: {odabraniBrojNocenja}</p>
                  <p className="font-medium">Cena: {cenaRezervacije}</p>
                </div>}
              </div>
            </form>
          </div>
        </div>
        <img className="col-span-2 rounded-2xl shadow-xl" src={smestaj?.slikeURL[0]} alt={smestaj?.naziv} />
      </div>
      {!ctx.ulogovan && <p className="mt-4 font-medium flex gap-2">*Da bi ste rezervisali smeštaj morate biti ulogovani. <Link className="text-primary flex items-center gap-2" to="/login">Uloguj se <img src={ulogujSe} alt="Uloguj se" className="w-[14px] h-[14px]" /></Link></p>}
    </section>
  )
}
