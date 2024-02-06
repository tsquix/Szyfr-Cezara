using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace interfejsszyfru
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int opcja = 1;
            string inputInt = textbox1.Text;
            int.TryParse(inputInt, out int inputNumber);
            string inputString = textbox2.Text;
            string output = ProcessInput(inputNumber, inputString, opcja);
                labelson.Content = "Zaszyfrowany tekst: " + output;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int opcja = 2;
            string inputInt = kluczodszyfr.Text;
            int.TryParse(inputInt, out int inputNumber);
            string inputString = odszyfr.Text;
            string output = ProcessInput(inputNumber, inputString, opcja);
            odszyfrlabelson.Content = "Odszyfrowany tekst: " + output;

        }
        private string ProcessInput(int intInput, string stringInput, int opcja)
        {
            string alfa = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            char[] alfabet = alfa.ToCharArray();
            string input = stringInput;
            char[] litery = input.ToCharArray();
            int x = 0;
            int i = 0;
            int klucz = intInput;
            int[] pozycja = new int[litery.Length];
            char[] zaszyfrowany = new char[pozycja.Length];
            char[] odszyfrowany = new char[pozycja.Length];
          
            int spacja = 200;
            int opsja = opcja;

            switch (opsja)
            {
                case 1:

                    while (x < litery.Length)//ustala pozycje liter zawartych w inpucie
                    {
                        if (litery[x] == ' ')//ustawia wartosc 200 dla spacji
                        {
                            pozycja[x] = spacja;
                            x++;
                            i=0;
                        }
                        else if (alfabet[i] == litery[x])//sprawdza czy w tablicy litery[na pozycji x]
                                                         //znajduje się litera równa tej z alfabetu
                        {
                            pozycja[x] = i;
                            x++;
                            i = 0; // Zresetowanie wartości i do 0 po znalezieniu litery
                        }
                        else i++;
                    }
                    //bierze tablice pozycja z wartosciami indexu alfabetu danego slowa i dodaje do nich klucz
                    for (int c = 0; c < pozycja.Length; c++)
                    {
                        if (pozycja[c]+ klucz > 34 && pozycja[c]<200)
                        {
                            int pozycjaPozaIndeksem = (pozycja[c]+klucz)-35;
                            pozycja[c]= pozycjaPozaIndeksem;
                        }
                        else
                        {
                            pozycja[c]= pozycja[c] + klucz;
                        }
                    }
                    // przekształca numery indeksu z tablicy pozycja na litery z tym indeksem z tablicy alfabet
                    for (i = 0; i < pozycja.Length; i++)
                    {
                        int z = pozycja[i];
                        if (z == (spacja+klucz))
                        {
                            zaszyfrowany[i] = ' ';
                        }
                        else
                        {
                            zaszyfrowany[i] =  alfabet[z];
                        }
                    }
                    string zaszyfrowanystr = new(zaszyfrowany);
                    return zaszyfrowanystr;
                    break;

                case 2:
                    while (x < litery.Length)//ustala pozycje liter zawartych w inpucie
                    {
                        if (litery[x] == ' ')//ustawia wartosc 200 dla spacji
                        {
                            pozycja[x] = spacja;
                            x++;
                            i=0;
                        }
                        //sprawdza czy w tablicy litery[na pozycji x] znajduje się litera równa tej z alfabetu
                        else if (alfabet[i] == litery[x])
                        {
                            pozycja[x] = i;
                            x++;
                            i = 0; // Zresetowanie wartości i do 0 po znalezieniu litery
                        }
                        else i++;
                    }
                    //bierze tablice pozycja z wartosciami indexu alfabetu danego slowa i odejmuje od nich klucz
                    for (int c = 0; c < pozycja.Length; c++)
                    {
                        if ((pozycja[c] - klucz) < 0 && pozycja[c]<100)
                        {
                            int pozycjaPozaIndeksem = (35+(pozycja[c]- klucz));
                            pozycja[c]= pozycjaPozaIndeksem;
                        }
                        else if (klucz <0)
                        {
                            pozycja[c]= pozycja[c] + klucz;
                        }
                        else
                        {
                            pozycja[c]= pozycja[c] - klucz;
                        }
                    }
                    // przekształca numery indeksu z tablicy pozycja na litery z tym indeksem z tablicy alfabet
                    for (i = 0; i < pozycja.Length; i++)
                    {
                        int z = pozycja[i];
                        if (z == (spacja-klucz))
                        {
                            odszyfrowany[i] = ' ';
                        }
                        else
                        {
                            odszyfrowany[i] =  alfabet[z];
                        }
                    }
                    string odszyfrowanystr = new string(odszyfrowany);

                    return odszyfrowanystr;
                    break;
            }
            return "została wybrana niepoprawna opcja: wybierz 1 lub 2";
        }
    }
}
    

