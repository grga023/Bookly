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