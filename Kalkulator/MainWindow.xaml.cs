using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int wynik = 0;
        private int tempWynik = 0;
        private string stringWynik = null;
        private string znak = null;
        private bool rowna = false;
        private bool error = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PZero_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == null || stringWynik == "0")
            {
                stringWynik = "0";
            }
            else
            {
                stringWynik += "0";
                Pole.Text = stringWynik;
            }
        }

        private void PJeden_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "1";
            Pole.Text = stringWynik;
        }

        private void PDwa_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "2";
            Pole.Text = stringWynik;
        }

        private void PTrzy_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "3";
            Pole.Text = stringWynik;
        }

        private void PCztery_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "4";
            Pole.Text = stringWynik;
        }

        private void PPiec_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "5";
            Pole.Text = stringWynik;
        }

        private void PSzesc_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "6";
            Pole.Text = stringWynik;
        }

        private void PSiedem_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "7";
            Pole.Text = stringWynik;
        }

        private void POsiem_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "8";
            Pole.Text = stringWynik;
        }

        private void PDziewiec_Click(object sender, RoutedEventArgs e)
        {
            if (stringWynik == "0")
            {
                stringWynik = null;
            }

            stringWynik += "9";
            Pole.Text = stringWynik;
        }

        private void PPlus_Click(object sender, RoutedEventArgs e)
        {
            Dzialanie("plus");
        }

        private void PMinus_Click(object sender, RoutedEventArgs e)
        {
            Dzialanie("minus");
        }

        private void PMnozenie_Click(object sender, RoutedEventArgs e)
        {
            Dzialanie("mnozenie");
        }

        private void PDzielenie_Click(object sender, RoutedEventArgs e)
        {
            Dzialanie("dzielenie");
        }

        private void PRowna_Click(object sender, RoutedEventArgs e)
        {
            rowna = true;
            Dzialanie(znak);
            stringWynik = Convert.ToString(wynik);

            if (error == false)
            {
                Pole.Text = stringWynik;
            }

            error = false;
            stringWynik = null;
            rowna = false;
        }

        private void PUsun_Click(object sender, RoutedEventArgs e)
        {
            stringWynik = null;
            wynik = 0;
            tempWynik = 0;
            Pole.Text = "0";
        }

        private void Dzialanie(string znak)
        {
            tempWynik = Convert.ToInt32(stringWynik);
            this.znak = znak;

            switch (znak)
            {
                case "plus":
                    wynik += tempWynik;
                    tempWynik = 0;
                    stringWynik = null;
                    break;
                case "minus":
                    if (rowna == false && tempWynik != 0)
                    {
                        wynik = tempWynik;
                    }
                    else
                    {
                        wynik -= tempWynik;
                    }
                    tempWynik = 0;
                    stringWynik = null;
                    break;
                case "mnozenie":
                    if (tempWynik == 0 && (rowna == false || stringWynik == null))
                    {
                        break;
                    }
                    else
                    {
                        if (wynik == 0 && rowna == false)
                        {
                            wynik = tempWynik;
                        }
                        else
                        {
                            wynik *= tempWynik;
                        }
                    }

                    tempWynik = 0;
                    stringWynik = null;
                    break;
                case "dzielenie":
                    if (tempWynik == 0 && rowna == true)
                    {
                        Pole.Text = "Nie można dzielić przez 0";
                        error = true;
                    }
                    else if (tempWynik == 0 && rowna == false)
                    {
                        break;
                    }
                    else
                    {
                        if (wynik == 0 && rowna == false)
                        {
                            wynik = tempWynik;
                        }
                        else
                        {
                            wynik /= tempWynik;
                        }
                    }

                    tempWynik = 0;
                    stringWynik = null;
                    break;
                default:
                    tempWynik = 0;
                    stringWynik = null;
                    break;
            }
        }
    }
}
