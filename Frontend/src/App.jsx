import { createContext, useState, useEffect } from "react";

import Header from "./komponente/Header";
import Footer from "./komponente/Footer";
import AppRoutes from "./komponente/AppRoutes";

export const AuthContext = createContext({});

function App() {
  const [ulogovan, postaviUlogovan] = useState(false);

  const korisnikUlogovan = async () => {
    try {
      const odgovor = await fetch("http://localhost:4300/api/Korisnici/me", {
        method: "GET",
        credentials: "include"
      });

      if(odgovor.status === 401){
        postaviUlogovan(false);
      } else {
        postaviUlogovan(true);
      }

    } catch (error) {
      console.log(error);    
    }
  }

  useEffect(() => {
    korisnikUlogovan();
  }, [])

  return (
    <AuthContext.Provider value={{ulogovan, postaviUlogovan}}>
      <Header />
      <main className="my-20 container">
        <AppRoutes />
      </main>
      <Footer />
    </AuthContext.Provider>
  )
}

export default App
