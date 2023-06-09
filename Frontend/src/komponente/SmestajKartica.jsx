import { Link } from "react-router-dom";
import { brojKaoDinar, formatirajOcenu } from "../funkcije";

export default function SmestajKartica({ id, slike, naziv, opis, mesto, drzava, cena, ocena }) {
  const mestoDrzava = `${mesto}, ${drzava}`;
  const kratakOpis = opis.slice(0, 50) + '...';
  const formatiranaOcena = formatirajOcenu(ocena);
  const cenaNocenja = brojKaoDinar(cena);

  return (
      <Link to={`/smestaj/${id}`} key={id} className="h-96 group rounded-2xl shadow-md overflow-hidden cursor-pointer">
        <div className="h-1/2 w-full overflow-hidden">
          <img src={slike[0]} alt={naziv} className="object-cover group-hover:scale-[1.05] transition-all duration-500" />
        </div>
        <div className="p-4 h-1/2">
          <div className="flex justify-between items-centar">
            <h2 className="text-xl">{naziv}</h2>
            <span className="text-primary">{formatiranaOcena}/5</span>
          </div>
          <div>
            <p className="my-3">{kratakOpis}</p>
            <div>
              <p className="font-medium">Mesto: <span className="font-normal text-primary">{mestoDrzava}</span></p>
              <p className="font-medium">Cena noćenja: <span className="font-normal text-primary">{cenaNocenja}</span></p>
            </div>
          </div>
        </div>
      </Link>
  )
}