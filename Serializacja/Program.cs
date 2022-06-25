using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serializacja
{
    class Program
    {
        static void Main(string[] args)
        {
            //serializer
            XmlSerializer serializer = new XmlSerializer(typeof(osoba));

            osobaAdres OsobaAdres = new osobaAdres();
            OsobaAdres.miejscowosc = "Gdańsk";
            OsobaAdres.ulica = "Kolorowa";
            OsobaAdres.nrDomu = "123";
            OsobaAdres.nrLokalu = "1";

            osobaAdres[] listaAdres = new osobaAdres[] { OsobaAdres };

            osoba Osoba = new osoba();
            Osoba.imie = "Robert";
            Osoba.nazwisko = "Nowak";
            Osoba.pesel = 12345678910;
            Osoba.adresy = listaAdres;

            //serializacja
            TextWriter strumienZapisu = new StreamWriter("osoba.xml");
            serializer.Serialize(strumienZapisu, Osoba);
            strumienZapisu.Close();

            //deserializacja
            Stream strumienOdczytu = File.OpenRead("osoba.xml");
            var OdczytanaOsoba = serializer.Deserialize(strumienOdczytu);
            osoba odczytanaOsoba = new osoba();
            osobaAdres odczytanyAdres = new osobaAdres();
            odczytanaOsoba = (osoba)OdczytanaOsoba;

            string Imie = odczytanaOsoba.imie;
            string Nazwisko = odczytanaOsoba.nazwisko;
            long Pesel = odczytanaOsoba.pesel;
            osobaAdres[] adres = odczytanaOsoba.adresy;
            odczytanyAdres = adres[0];
            string Ulica = odczytanyAdres.ulica;
            string NrDomu = odczytanyAdres.nrDomu;
            string NrLokalu = odczytanyAdres.nrLokalu;
            string Miejscowosc = odczytanyAdres.miejscowosc;

            Console.WriteLine($"Imię i nazwisko: {Imie} {Nazwisko}");
            Console.WriteLine($"Pesel: {Pesel}");
            Console.WriteLine($"Adres: {Ulica} {NrDomu}/{NrLokalu}, {Miejscowosc}");

            Console.ReadKey();
        }
    }
}
