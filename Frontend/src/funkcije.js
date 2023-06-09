export const formatirajOcenu = (ocena) => {
  const parsedOcena = Number.parseFloat(ocena);
  const ceoBroj = Number.isInteger(parsedOcena);

  return ceoBroj ? parsedOcena.toString() : parsedOcena.toFixed(1);
}

export const cekanje = (sekunde) => {
  return new Promise(resolve => setTimeout(resolve, sekunde));
}

export const brojKaoDinar = (broj) => {
  return Number(broj).toLocaleString('sr-RS', { style: 'currency', currency: 'RSD' });
};

export const validirajDatum = (datum) => {
  const izabraniDatum = new Date(datum);
  const danasnjiDatum = new Date();
  const razlika = danasnjiDatum.getFullYear() - izabraniDatum.getFullYear();

  return razlika >= 18;
}

export const validirajSifru = (sifra) => {
  const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+{};:,<.>])[a-zA-Z\d!@#$%^&*()\-_=+{};:,<.>]{8,}$/;

  return regex.test(sifra);
}

export const validirajMejl = (mejl) => {
  const regex = /\S+@\S+\.\S+/;

  return regex.test(mejl);
}

export const formatirajDatum = (datum) => {
  const decodedString = decodeURIComponent(datum);
  const dateObject = new Date(decodedString);
  const year = dateObject.getFullYear();
  const month = (dateObject.getMonth() + 1).toString().padStart(2, '0');
  const day = dateObject.getDate().toString().padStart(2, '0');

  return `${year}-${month}-${day}`;
}

export const minMaxDatum = () => {
  const tomorrow = new Date();
  tomorrow.setDate(tomorrow.getDate() + 1);
  const tomorrowFormatted = formatirajDatum(tomorrow);

  const dayAfterTomorrow = new Date();
  dayAfterTomorrow.setDate(dayAfterTomorrow.getDate() + 2);
  const dayAfterTomorrowFormatted = formatirajDatum(dayAfterTomorrow);

  return [tomorrowFormatted, dayAfterTomorrowFormatted]
}