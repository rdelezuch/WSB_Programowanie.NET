﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PESELWalidator
{
    public class PeselWalidator
    {
        protected int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        protected int[] pesel = new int[10];

        public PeselWalidator(String pesel)
        {
            WczytajPesel(pesel);
        }

        public int[] WczytajPesel(String pesel)
        {
            var temp = pesel.ToList();

            if (SprawdzPesel(pesel))
            {
                for (int i = 0; i < 10; i++)
                {
                    this.pesel[i] = Convert.ToInt32(temp[i].ToString());
                }
            }

            return this.pesel;
        }

        public int SumaKontrolna()
        {
            int sumaKontrolna = 0;

            for (int i = 0; i < 10; i++)
            {
                sumaKontrolna += (pesel[i] * wagi[i]);
            }

            sumaKontrolna = 10 - (sumaKontrolna % 10);

            return sumaKontrolna;
        }

        public String DataUrodzenia()
        {
            string data = null;
            bool rocznikDwaTysiace = false;

            if (pesel[2] > 1)
            {
                rocznikDwaTysiace = true;
            }

            for (int i = 5; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    if (rocznikDwaTysiace && i == 3)
                    {
                        data += (pesel[i - 1] - 2).ToString();
                    }
                    else
                    {
                        data += pesel[i - 1].ToString();
                    }
                }
                else
                {
                    data += pesel[i+1].ToString();
                }

                if (i % 2 == 0 && i != 0)
                {
                    data += ".";
                }

                if (i == 2)
                {
                    if (rocznikDwaTysiace)
                    {
                        data += "20";
                    }
                    else
                    {
                        data += "19";
                    }
                }
            }

            return data;
        }

        public String Plec()
        {
            string plec;

            if (pesel[9] % 2 == 0)
            {
                plec = "Kobieta";
            }
            else
            {
                plec = "Mężczyzna";
            }

            return plec;
        }

        public Boolean SprawdzPesel(string bazaPesel)
        {
            bool prawidlowyPesel = Regex.IsMatch(bazaPesel, $"^\\d{{11}}$");

            return prawidlowyPesel;
        }

    }
}
