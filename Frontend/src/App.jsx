import Header from "./komponente/Header";
import Footer from "./komponente/Footer";
import AppRoutes from "./komponente/AppRoutes";

function App() {
  return (
    <>
      <Header />
      <main className="my-20 container">
        <AppRoutes />
      </main>
      <Footer />
    </>
  )
}

export default App
