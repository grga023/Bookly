import { Link } from 'react-router-dom';

export default function NotFound() {
  return (
    <section className="grid place-items-center">
      <h1 className="font-medium text-2xl">Ništa nije pronađeno.</h1>
      <Link to="/" className="btn btn-primary inline-block mt-2">POČETNA</Link>
    </section>
  )
}
