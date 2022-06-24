using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
    public class Service1 : ISzukajOsoby
    {
        public string WedlugNazwiska(string value)
        {
            List<Osoba> Osoby = new List<Osoba>()
            {
                new Osoba("Mariusz", "Kociołek", "Warszawa, ul. Kolorowa 13"),
                new Osoba("Maja", "Ziobro", "Gdańsk, ul. Smakoszy 2"),
                new Osoba("Igor", "Poprzeczka", "Katowice, ul. 3Maja 4"),
                new Osoba("Robert", "Nowak", "Wrocław, ul. Kolibra 543"),
                new Osoba("Jacek", "Zaborski", "Łódź, ul. Straszna 1"),
            };

            var Wynik = "Brak takiej osoby";

            foreach (var osoba in Osoby)
            {
                if (osoba.Nazwisko.Equals(value))
                {
                    Wynik = $"{osoba.Imie} {osoba.Nazwisko} Adres: {osoba.Adres}";
                    break;
                }
            }

            return Wynik;
        }
    }
}
