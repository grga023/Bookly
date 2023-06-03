import { Routes, Route } from "react-router-dom"
import Pocetna from "../stranice/Pocetna";
import Smestaj from "../stranice/Smestaj";
import NotFound from "../stranice/NotFound";
import Login from "../stranice/Login";
import Registracija from "../stranice/Registracija";

export default function AppRoutes() {
  return (
    <Routes>
      <Route index element={<Pocetna />} />
      <Route path="/smestaj/:id" element={<Smestaj />} />
      <Route path="/login" element={<Login />} />
      <Route path="/registracija" element={<Registracija />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  )
}
