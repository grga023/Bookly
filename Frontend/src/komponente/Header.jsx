import logo from "../slike/logo.svg";
import { NavLink, Link } from "react-router-dom";

export default function Header(){
  return (
    <header className="flex sticky bg-neutral-100 top-0 left-0 right-0 items-center justify-between px-20 border-b-2">
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
          <li>
            <Link to="/login" className="btn btn-outline">Uloguj se</Link>
          </li>
          <li>
            <Link to="/registracija" className="btn btn-primary">Registruj se</Link>
          </li>
        </ul>
      </nav>
    </header>
  )
}