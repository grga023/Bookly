# Bookly

Bookly veb aplikacija predstavlja klon Airbnb aplikacije. Ona omogućava korisniku pregled različitih apartmana koji se nalaze u bazi. Kreiranje i ulogovanjem na svoj profil, korisnik ima mogućnost rezervacije smeštaja u određenom periodu. Na početnoj stranici aplikacije, nalaze se svi raspoloživi apartmani koje korisnik može da filtrira uspomoć slajdera za cenu i input polja koji filtrira po nazivu apartmana i lokaciji.

## Use Case-ovi

Ovde možete navesti nekoliko primera use case-ova kako bi bolje razumeli svrhu projekta i način na koji se koristi.

1. **Pregled apartmana:** Korisnik ima pregled svih apartmana koji se nalaze u bazi nezavisno od toga da li je ulogovan ili ne.
2. **Filtriranje apartmana:** Korisnik ima mogućnost filtriranja svih apartmana na dva načina: uz pomoć slajdera za filtriranje po ceni i uz pomoć search input polja za filtriranje po nazivu i lokaciji apartmana.
3. **Detaljan pregled svakog apartmana:** Korisnik može da vidi naziv, detaljniji opis, sliku, cenu i lokaciju apartmana na zasebnoj stranici koja se dinamički kreira za svaki od apartmana.
4. **Login:** Korisnik ima mogućnost da se uloguje uz pomoć email-a i šifre.
5. **Registracija:** Korisnik može da se registruje popunjavanjem forme na stranici Registracija.
5. **Kreiranje rezervacije:** Korisnik može da rezerviše smeštaj ukoliko je ulogovan.
6. **Reset šifre:** Ukoliko je korisnik zaboravio svoju šifru ima mogućnost da postavi novu tako što će upisati token koji mu stigne na upisani email i novu šifru. Nakon toga automatski će biti ulogovan ukoliko su svi podaci tačni. 

## Alati i tehnologije korišćene u projektu

**Backend:**
1. C#
2. ASP .NET Core Identity
3. Entity Framework Core 7.0
4. Visual Studio

**Frontend:**
1. JavaScript
2. React.js
3. Tailwind CSS
4. NPM
5. Visual Studio Code

## Pokretanje

1. cd .\Backend\
2. docker build -t bookly-api -f ./Bookly.API/Dockerfile .
3. cd ..
4. cd .\Frontend\
5. docker build -f .\Dockerfile.dev . -t bookly-client
6. Stopirati bookly-client u dockeru
7. cd ..
8. docker compose up
9. cd .\Frontend\
10. npm install
11. npm run dev

## Autori

- [Dušan Lukić SI 15/20](https://github.com/dusanlukic404)
- [Dušan Runjevac SI 18/20](https://github.com/runjevac)
- [Stefan Đurđević SI 17/20](https://github.com/djurdjevics)
- [Ognjen Grgur SI 10/20](https://github.com/grga023)
