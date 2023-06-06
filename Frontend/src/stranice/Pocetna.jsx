import { useState, useMemo, Suspense, useEffect } from "react";
import Slider from "@mui/material/Slider";

import filterImg from "../slike/filter.svg";
import searchImg from "../slike/search.svg";
import SmestajKartica from "../komponente/SmestajKartica";
import { brojKaoDinar } from "../funkcije";

export default function Home(){
  const [pretraga, postaviPretragu] = useState("");
  const [smestajNiz, postaviSmestajNiz] = useState([]);

  useEffect(() => {
    const dobijanjeSmestaja = async () => {
      try {
        const odgovor = await fetch("http://localhost:4300/api/Smestaj");
        const podaci = await odgovor.json();
        postaviSmestajNiz(podaci);
      } catch (error) {
        console.error("Greska prilikom dobijanja podataka:", error);
      }
    };

    dobijanjeSmestaja();
  }, []);

  const modifikovaniSmestajNiz = useMemo(() => {
    if (smestajNiz.length === 0) return [];

    return smestajNiz.map(smestaj => {
      return {
        ...smestaj,
        mestoDrzava: `${smestaj.mesto}, ${smestaj.drzava}`
      };
    });
  }, [smestajNiz]);

   const cene = useMemo(() => {
    if (smestajNiz.length === 0) return [];

    return smestajNiz.map((smestaj) => smestaj.cena);
  }, [smestajNiz]);

  const [najmanjaCena, najvecaCena] = useMemo(() => {
    if (cene.length === 0) return [0, 0];

    const min = cene.reduce((min, cena) => Math.min(min, cena));
    const max = cene.reduce((max, cena) => Math.max(max, cena));
    return [min, max];
  }, [cene]);


  const [filterCene, postaviFilterCene] = useState([]);
  useEffect(() => {
    postaviFilterCene([najmanjaCena, najvecaCena]);
  }, [najmanjaCena, najvecaCena]);

  const filtriraniSmestaj = useMemo(() => {
    if (modifikovaniSmestajNiz.length === 0) return [];

    return modifikovaniSmestajNiz.filter((smestaj) => {
      const cena = parseInt(smestaj.cena);
      return (
        (smestaj.mestoDrzava.toLowerCase().includes(pretraga.toLowerCase()) ||
          smestaj.naziv.toLowerCase().includes(pretraga.toLowerCase())) &&
        cena >= filterCene[0] &&
        cena <= filterCene[1]
      );
    });
}, [modifikovaniSmestajNiz, pretraga, filterCene]);

  const najmanjaOdabranaCena = brojKaoDinar(filterCene[0]);
  const najvecaOdabranaCena = brojKaoDinar(filterCene[1]);

  return (
      <section aria-label="Pocetna sekcija, filtriranje smestaja">
        <div className="flex gap-6 items-center justify-between mb-4">
          <div className="w-[32%]">
            <div className="flex gap-3 items-center">
              <img src={filterImg} alt="filteri" className="w-[15px] h-[15px]" />
              <span>Filtriraj po ceni</span>
            </div>
            <div className="my-2">
              <Slider value={filterCene} onChange={(_, novaVrednost) => postaviFilterCene(novaVrednost) } min={najmanjaCena} max={najvecaCena} valueLabelDisplay="auto" className="relative z-30"/>
              <span>{najmanjaOdabranaCena} do {najvecaOdabranaCena}</span>
             </div>
          </div>
           <div className="w-full mb-12 relative px-4 py-2 border-2 rounded-xl focus-within:border-primary-200 transition-colors duration-300">
            <img src={searchImg} alt="pretraga" className="absolute w-[18px] h-[18px] top-[50%] -translate-y-[50%]" />
             <input type="text" placeholder="Pretraži smeštaj" className="pl-8 w-full" value={pretraga} onChange={(e) => postaviPretragu(e.target.value)} />
           </div>
        </div>
        {filtriraniSmestaj.length > 0 && <Suspense fallback={<div>loading</div>}>
          <ul className="grid grid-cols-3 gap-6">
            {filtriraniSmestaj.map(smestaj => (
                <SmestajKartica key={smestaj.id} id={smestaj.id} naziv={smestaj.naziv} cena={smestaj.cena} ocena={smestaj.ocena} slike={smestaj.slikeURL} mesto={smestaj.mesto} drzava={smestaj.drzava} opis={smestaj.opis} />
            ))}
          </ul>
        </Suspense>}
        {filtriraniSmestaj.length === 0 && <p className="text-medium text-center pt-10 text-xl">Žao nam je, ali za odabrane kriterijume nema reultata.</p>}
      </section>
  )
}