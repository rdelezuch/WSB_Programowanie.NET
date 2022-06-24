using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public Osoba(string imie, string nazwisko, string adres)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Adres = adres;
        }
    }
}