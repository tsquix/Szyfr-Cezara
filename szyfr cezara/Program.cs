string alfa = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
char[] alfabet = alfa.ToCharArray();
//string input = "chroń półk swój i flag sześć";//input;

int x = 0;
int i = 0;
int spacja = 200;

Console.WriteLine("wybierz opcje: ");
Console.WriteLine("szyfrowanie - 1,deszyfrowanie - 2");

int opcja = int.Parse(Console.ReadLine());
Console.WriteLine("Podaj klucz 1-34");
int klucz = int.Parse(Console.ReadLine());
Console.WriteLine("Podaj tekst do szyfracji/deszyfracji: ");
string input = Console.ReadLine();
char[] litery = input.ToCharArray();
int[] pozycja = new int[litery.Length];
char[] zaszyfrowany = new char[pozycja.Length];
char[] odszyfrowany = new char[pozycja.Length];

switch (opcja)
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
            else if (alfabet[i] == litery[x])//sprawdza czy w tablicy litery[na pozycji x] znajduje się litera równa tej z alfabetu
            {
                pozycja[x] = i;
                x++;
                i = 0; // Zresetowanie wartości i do 0 po znalezieniu litery
            }
            else i++;
        }
        //int klucz = 3;
        for (int c = 0; c < pozycja.Length; c++)//bierze tablice pozycja z wartosciami indexu alfabetu danego slowa i dodaje do nich klucz
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
        //char[] zaszyfrowany= new char[pozycja.Length];
        for (i = 0; i < pozycja.Length; i++)// przekształca numery indeksu z tablicy pozycja na litery z tym indeksem z tablicy alfabet
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
        Console.WriteLine(zaszyfrowanystr);
        break;

    //@@@@@@@@@@@@@@@
    case 2:
        while (x < litery.Length)//ustala pozycje liter zawartych w inpucie
        {
            if (litery[x] == ' ')//ustawia wartosc 200 dla spacji
            {
                pozycja[x] = spacja;
                x++;
                i=0;
            }
            else if (alfabet[i] == litery[x])//sprawdza czy w tablicy litery[na pozycji x] znajduje się litera równa tej z alfabetu
            {
                pozycja[x] = i;
                x++;
                i = 0; // Zresetowanie wartości i do 0 po znalezieniu litery
            }
            else i++;
        }
        //int klucz = 3;
        for (int c = 0; c < pozycja.Length; c++)//bierze tablice pozycja z wartosciami indexu alfabetu danego slowa i dodaje do nich klucz
        {
            if ((pozycja[c] - klucz) < 0 && pozycja[c]<100)
            {
                int pozycjaPozaIndeksem = (35+(pozycja[c]- klucz));// (pozycja[c]-klucz)-35;
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
        //char[] zaszyfrowany= new char[pozycja.Length];
        for (i = 0; i < pozycja.Length; i++)// przekształca numery indeksu z tablicy pozycja na litery z tym indeksem z tablicy alfabet
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
        Console.WriteLine(odszyfrowanystr);
        break;
}