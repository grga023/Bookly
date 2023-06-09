import { useContext } from "react";
import logo from "../slike/logo.svg";
import { NavLink, Link, useNavigate } from "react-router-dom";

import { AuthContext } from "../App";

export default function Header(){
  const ctx = useContext(AuthContext);
  const navigacija = useNavigate();

  const izlogujSe = async () => {
    try {
      const odgovor = await fetch("http://localhost:4300/api/Korisnici/logout", {
        method: "POST",
        credentials: "include"
      })

      if(odgovor.ok){
        ctx.postaviUlogovan(false);
        navigacija("/")
      }

    } catch (error) {
      console.log(error);
    }
  }

  return (
    <header className="flex sticky bg-neutral-100 top-0 left-0 right-0 items-center justify-between px-20 border-b-2 z-[999]">
      <Link to="/">
        <img className="w-[95px] h-[95px]" src={logo} alt="Bookly logo" />
      </Link>
      <nav>
        <ul className="flex items-center gap-4">
          <li>
            <NavLink to="/" className={({ isActive }) => (isActive ? 'link active' : 'link')}>Početna</NavLink>
          </li>
          <li>
            <NavLink to="/o-nama" className={({ isActive }) => (isActive ? 'link active' : 'link')}>O nama</NavLink>
          </li>
          {!ctx.ulogovan && <>
            <li>
              <Link to="/login" className="btn btn-outline">Uloguj se</Link>
            </li>
            <li>
              <Link to="/registracija" className="btn btn-primary">Registruj se</Link>
            </li>
          </>}
          {ctx.ulogovan && <>
            <li>
              <Link to="/" className="btn btn-primary" onClick={izlogujSe}>Izloguj se</Link>
            </li>
          </>}
        </ul>
      </nav>
    </header>
  )
}