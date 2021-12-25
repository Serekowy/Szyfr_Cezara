using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szyfr_Cezara
{
    internal class Class1
    {
        public static void start(string ver)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Program do szyfru cezara, wersja {ver}, Autor: Adiks", ver);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Program służy do zabawy razem ze znajomymi, można kodować wiadomości i podawać sobie liczbę przesunięć liter, " +
                "program może posłużyć również jako łamacz szyfru cezara gdyby znajomy nie chciał nam podać liczby przesuniętych liter, miłej zabawy :)");
            Console.ResetColor();
            Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void menu()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("- 1. Szyfrowanie     -");
            Console.WriteLine("- 2. Deszyfrowanie   -");
            Console.WriteLine("- 3. Łamanie szyfru  -");
            Console.WriteLine("- 4. Zakończ program -");
            Console.WriteLine("----------------------");
            Console.Write("Wybór: ");
        }
        public static string sprawdzZakres()
        {
            string tekst = "";
            while (tekst.Length < 3 || sprawdz(tekst) == false)
            {
                Console.Write("Wprowadź tekst do szyfrowania: ");
                tekst = Console.ReadLine();
                if (sprawdz(tekst) == false)
                {
                    Console.WriteLine("Tekst musi być z zakresu od a do z");
                    continue;
                }
                if (tekst.Length < 3)
                {
                    Console.WriteLine("Wyraz musi mieć minimum 3 znaki");
                }
            }
            return tekst;
        }
        public static int sprawdzCzyLiczba()
        {
            bool spr = false;
            int liczba = 0;
            string x = "";
            while (!spr)
            {
                Console.Write("Wprowadź szyfr (od -25 znaków do 25 znaków): ");
                x = Console.ReadLine();

                spr = int.TryParse(x, out liczba);

                if (!spr)
                {
                    continue;
                }

                if (liczba > 25 || liczba < -25)
                {
                    Console.WriteLine("Przesunięcie musi być w zakresie od -25 do 25");
                    spr = false;
                    continue;
                }
                return liczba;
            }
            return 0;
        }
        public static bool sprawdz(string tekst)
        {
            int licznik = 0;
            tekst = tekst.ToLower();

            for (int i = 0; i < tekst.Length; i++)
            {
                char litera = tekst[i];

                if ((litera < 97 || litera > 122) && litera != 32)
                {
                    licznik++;
                }
            }

            if (licznik > 0)
            {
                return false;
            }

            return true;
        }
        public static string deszyfr(string tekst, int liczba)
        {
            char[] buffer = tekst.ToCharArray();
            tekst = tekst.ToLower();

            for (int i = 0; i < tekst.Length; i++)
            {
                char litera = tekst[i];

                if (litera == 32)
                {
                    goto przeskok;
                }

                litera = (char)(litera - liczba);

                if (litera > 'z')
                {
                    litera = (char)(litera - 26);
                }
                else if (litera < 'a')
                {
                    litera = (char)(litera + 26);
                }
            przeskok:
                buffer[i] = litera;
            }

            return new string(buffer);
        }
        public static string szyfr(string tekst, int liczba)
        {
            char[] buffer = tekst.ToCharArray();
            tekst = tekst.ToLower();

            for (int i = 0; i < tekst.Length; i++)
            {
                char litera = tekst[i];

                if (litera == 32)
                {
                    goto przeskok;
                }

                litera = (char)(litera + liczba);

                if (litera > 'z')
                {
                    litera = (char)(litera - 26);
                }
                else if (litera < 'a')
                {
                    litera = (char)(litera + 26);
                }
            przeskok:
                buffer[i] = litera;
            }

            return new string(buffer);
        }
    }
}
