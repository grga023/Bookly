import { useParams } from "react-router-dom"
import { formatirajOcenu, brojKaoDinar, formatirajDatum, minMaxDatum } from "../funkcije";
import { useState, useEffect, useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import ulogujSe from "../slike/ulogujse.svg";
import { AuthContext } from "../App";

import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const izracunajBrojNocenja = (datumPrijave, datumOdjave) => {
  const prijava = new Date(datumPrijave);
  const odjava = new Date(datumOdjave);
  const razlika = Math.abs(odjava - prijava);
  const brojNocenja = Math.ceil(razlika / (1000 * 60 * 60 * 24));
  
  return brojNocenja;
}

export default function Smestaj() {
  const [datumError, postaviDatumError] = useState(false);
  const { id } = useParams();
  const [smestaj, setSmestaj] = useState(null);
  const [postavljanjeRezervacije, postaviPostavljanjeRezervacije] = useState(false);
  const [zauzetiDatumi, postaviZauzeteDatume] = useState([]);
  const navigacija = useNavigate();

  const [minDatumPrijave, minDatumOdjave] = minMaxDatum();

  const [startDate, setStartDate] = useState(Date.parse(minDatumPrijave));
  const [endDate, setEndDate] = useState(Date.parse(minDatumOdjave));

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

  useEffect(() => {
    const dobiZauzeteDatume = async () => {
      try {
        const odgovor = await fetch(`http://localhost:4300/api/Rezervacije/zauzeti-datumi?apartmanId=${id}`);
        const datumi = await odgovor.json();
        postaviZauzeteDatume(datumi.map(datum => new Date(datum)));
      } catch (error) {
        console.error('Greska prilikom dobijanja podataka:', error);
      }
    };
    
    dobiZauzeteDatume();
  }, [id])
  
  const napraviRezervaciju = async (e) => {
    e.preventDefault();
    postaviPostavljanjeRezervacije(true);

    const url = `http://localhost:4300/api/Rezervacije?apartmanId=${id}&datumDolaska=${formatirajDatum(startDate)}&datumOdlaska=${formatirajDatum(endDate)}`;
    
    try {
      const odgovor = await fetch(url, {
        method: "POST",
        credentials: "include",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
      
      alert("Uspesno ste izvrsili rezervaciju!")
      setStartDate(new Date());
      setEndDate(Date.parse(minDatumOdjave));
      navigacija("/")
      
    } catch (error) {
      postaviDatumError(true);
    }

    postaviPostavljanjeRezervacije(false);
  }

  const odabraniBrojNocenja = izracunajBrojNocenja(startDate, endDate);
  const ispravniDatumi = startDate !== '' && endDate !== '' && startDate < endDate && odabraniBrojNocenja > 0;
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
              <p className="font-medium">Ocena smeštaja: <span className="font-normal text-primary">{formatirajOcenu(smestaj?.ocena)}</span>/5</p>
            </div>
            <form className="mt-12 grid grid-cols-2 gap-3 w-1/2" onSubmit={napraviRezervaciju}>
              <div>
                <div className="flex items-center justify-between">
                  <label htmlFor="datumPrijave">Datum prijave</label>
                </div>
                <DatePicker excludeDates={zauzetiDatumi} className={`form-input ${datumError ? 'border-accent' : ''}`} minDate={Date.parse(minDatumPrijave)} selected={startDate} onChange={(date) => setStartDate(date)} showTimeSelect={false} />
              </div>
              <div>
                <div className="flex items-center justify-between">
                  <label htmlFor="datumOdjave">Datum odjave</label>
                </div>
                <DatePicker excludeDates={zauzetiDatumi} className={`form-input ${datumError ? 'border-accent' : ''}`} minDate={Date.parse(minDatumOdjave)} selected={endDate} onChange={(date) => setEndDate(date)} showTimeSelect={false} />
              </div>
              <div className="col-span-2 flex items-center gap-3">
                <button className="btn btn-primary w-1/2" disabled={!ispravniDatumi || !ctx.ulogovan || postavljanjeRezervacije} onClick={napraviRezervaciju}>{postavljanjeRezervacije ? 'Pravimo rezervaciju...' : 'Rezerviši'}</button>
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
