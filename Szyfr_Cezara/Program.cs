using System;

namespace Szyfr_Cezara
{
    class Program
    {
        static void Main(string[] args)
        {
            string ver = "0.0.3";

            Console.Title = $"Szyfr Cezara {ver}";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Program do szyfru cezara, wersja {ver}, Autor: Adiks", ver);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Program służy do zabawy razem ze znajomymi, można kodować wiadomości i podawać sobie liczbę przesunięć liter, program może posłużyć również jako łamacz szyfru cezara gdyby znajomy nie chciał nam podać liczby przesuniętych liter, miłej zabawy :)");
            Console.ResetColor();
            Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz...");
            Console.ReadKey();
            Console.Clear();
            for (;;)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("- 1. Szyfrowanie     -");
                Console.WriteLine("- 2. Deszyfrowanie   -");
                Console.WriteLine("- 3. Łamanie szyfru  -");
                Console.WriteLine("- 4. Zakończ program -");
                Console.WriteLine("----------------------");
                Console.Write("Wybór: ");
                char wybor = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (wybor)
                {
                    case '1':
                        string x, tekst = "";
                        int liczba;

                        while(tekst.Length < 3 || sprawdz(tekst) == false)
                        {
                            Console.Write("Wprowadź tekst do szyfrowania: ");
                            tekst = Console.ReadLine();
                            if(sprawdz(tekst) == false)
                            {
                                Console.WriteLine("Tekst musi być z zakresu od a do z");
                                continue;
                            }
                            if (tekst.Length < 3)
                            {
                                Console.WriteLine("Wyraz musi mieć minimum 3 znaki");
                            }
                        }

                    tutaj:

                        Console.Write("Wprowadź szyfr (od -25 znaków do 25 znaków): ");
                        x = Console.ReadLine();

                        bool spr = int.TryParse(x, out liczba);

                        while (!spr)
                        {
                            goto tutaj;
                        }

                        if (liczba>25 || liczba<-25)
                        {
                            Console.WriteLine("Przesunięcie musi być w zakresie od -25 do 25");
                            goto tutaj;
                        }
                        
                        Console.WriteLine(szyfr(tekst.ToLower(), liczba));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '2':
                        tekst = "";
                        while (tekst.Length < 3 || sprawdz(tekst) == false)
                        {
                            Console.Write("Wprowadź tekst do deszyfrowania: ");
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

                    tutaj2:

                        Console.Write("Wprowadź szyfr: ");
                        x = Console.ReadLine();

                        spr = int.TryParse(x, out liczba);

                        while (!spr)
                        {
                            goto tutaj2;
                        }
                        if (liczba > 25 || liczba < -25)
                        {
                            Console.WriteLine("Przesunięcie musi być w zakresie od -25 do 25");
                            goto tutaj;
                        }

                        Console.WriteLine(deszyfr(tekst.ToLower(), liczba));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '3':
                        tekst = "";
                        while (tekst.Length < 3 || sprawdz(tekst) == false)
                        {
                            Console.Write("Wprowadź tekst do złamania: ");
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

                        for (int i = 1; i < 26; i++)
                        {
                            Console.WriteLine("Przesunięcie o +" + i + $" = {szyfr(tekst.ToLower(), i)}");
                            Console.WriteLine("");
                        }
                        for (int i = 1; i < 26; i++)
                        {
                            Console.WriteLine("Przesunięcie o -" + i + $" = {deszyfr(tekst.ToLower(), i)}");
                            Console.WriteLine("");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '4':
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Błędny wybór!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        
        static string szyfr(string tekst, int liczba)
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
        static string deszyfr(string tekst, int liczba)
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
        static bool sprawdz(string tekst)
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
    }
}
