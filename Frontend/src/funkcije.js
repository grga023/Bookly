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