import { useState, useMemo } from "react";
import Slider from "@mui/material/Slider";

import filterImg from "../slike/filter.svg";
import searchImg from "../slike/search.svg";
import ListaSmestaja from "../komponente/ListaSmestaja";

const smestajNiz = [
  {
    id: 1,
    naziv: 'Fruske Terme',
    mesto: 'Vrdnik',
    drzava: 'Srbija',
    cena: '2990',
    ocena: '7.3',
    opis: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.',
    slika: 'https://images.pexels.com/photos/2844474/pexels-photo-2844474.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
  },
  {
    id: 2,
    naziv: 'Ramonda',
    mesto: 'Rtanj',
    drzava: 'Srbija',
    cena: '5390',
    ocena: '9.5',
    opis: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.',
    slika: 'https://images.pexels.com/photos/2844474/pexels-photo-2844474.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
  },
  {
    id: 3,
    naziv: 'Hotel Mir',
    mesto: 'Lovcen',
    drzava: 'Crna Gora',
    cena: '3190',
    ocena: '6.6',
    opis: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.',
    slika: 'https://images.pexels.com/photos/2844474/pexels-photo-2844474.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
  },
  {
    id: 4,
    naziv: 'Fruske Terme',
    mesto: 'Vrdnik',
    drzava: 'Srbija',
    cena: '2990',
    ocena: '7.3',
    opis: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.',
    slika: 'https://images.pexels.com/photos/2844474/pexels-photo-2844474.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
  },
  {
    id: 5,
    naziv: 'Ohridska dolina',
    mesto: 'Ohrid',
    drzava: 'Makedonija',
    cena: '1990',
    ocena: '4.8',
    opis: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.',
    slika: 'https://images.pexels.com/photos/2844474/pexels-photo-2844474.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
  },
  {
    id: 6,
    naziv: 'Botev Peak Hotel',
    mesto: 'Stara planina',
    drzava: 'Srbija',
    cena: '9440',
    ocena: '8.8',
    opis: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.',
    slika: 'https://images.pexels.com/photos/2844474/pexels-photo-2844474.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
  },
  {
    id: 7,
    naziv: 'Zepter Hotel',
    mesto: 'Vrnjacka Banja',
    drzava: 'Srbija',
    cena: '1590',
    ocena: '10',
    opis: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.',
    slika: 'https://images.pexels.com/photos/2844474/pexels-photo-2844474.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
  },
  {
    id: 8,
    naziv: 'Oplenac',
    mesto: 'Gostiona Babin zub',
    drzava: 'Srbija',
    cena: '3000',
    ocena: '2.3',
    opis: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.',
    slika: 'https://images.pexels.com/photos/2844474/pexels-photo-2844474.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
  },
]

export default function Home(){
  const [pretraga, postaviPretragu] = useState("");

  const modifikovaniSmestajNiz = useMemo(() => {
    return smestajNiz.map(smestaj => {
      return {
        ...smestaj,
        mestoDrzava: `${smestaj.mesto}, ${smestaj.drzava}` 
      };
    });
  }, []);

  const cene = useMemo(() => {
    return smestajNiz.map(smestaj => smestaj.cena);
  }, [smestajNiz]);

  const [najmanjaCena, najvecaCena] = useMemo(() => {
    const min = cene.reduce((min, cena) => Math.min(min, cena));
    const max = cene.reduce((max, cena) => Math.max(max, cena));
    return [min, max];
  }, [cene]);

  const [filterCene, postaviFilterCene] = useState([najmanjaCena, najvecaCena]);

  const filtriraniSmestaj = useMemo(() => {
    return modifikovaniSmestajNiz.filter(smestaj =>
      (smestaj.mestoDrzava.toLowerCase().includes(pretraga.toLowerCase()) ||
      smestaj.naziv.toLowerCase().includes(pretraga.toLowerCase())) &&
      parseInt(smestaj.cena) >= filterCene[0] &&
      parseInt(smestaj.cena) <= filterCene[1]
    );
  }, [modifikovaniSmestajNiz, pretraga, filterCene]);

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
              <span>Odabrana cena je: {filterCene[0]} do {filterCene[1]}</span>
             </div>
          </div>
           <div className="w-full mb-12 relative px-4 py-2 border-2 rounded-xl focus-within:border-primary-200 transition-colors duration-300">
            <img src={searchImg} alt="pretraga" className="absolute w-[18px] h-[18px] top-[50%] -translate-y-[50%]" />
             <input type="text" placeholder="Pretraži smeštaj" className="pl-8 w-full" value={pretraga} onChange={(e) => postaviPretragu(e.target.value)} />
           </div>
        </div>
        {filtriraniSmestaj.length > 0 && <ul className="grid grid-cols-3 gap-6">
          {filtriraniSmestaj.map(smestaj => (
            <ListaSmestaja key={smestaj.id} id={smestaj.id} naziv={smestaj.naziv} cena={smestaj.cena} ocena={smestaj.ocena} slika={smestaj.slika} mesto={smestaj.mesto} drzava={smestaj.drzava} opis={smestaj.opis} />
          ))}
        </ul>}
        {filtriraniSmestaj.length === 0 && <p className="text-medium text-center pt-10 text-xl">Žao nam je, ali za odabrane kriterijume nema reultata.</p>}
      </section>
  )
}