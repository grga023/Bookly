import filterImg from "../slike/filter.svg";

export default function Home(){
  return (
    <div className="grid grid-cols-[auto,1fr] gap-20">
      <aside className="border-2 rounded-xl px-6 flex gap-2 items-center">
        <img src={filterImg} alt="filteri" className="w-[15px] h-[15px]" />
        <span>Filteri</span>
      </aside>
      <section aria-label="Pocetna sekcija, filtriranje smestaja">
        <div>
          search
        </div>
        <div>smestajne jedinice</div>
      </section>
    </div>
  )
}