using System;

namespace Szyfr_Cezara
{
    class Program
    {
        static void Main(string[] args)
        {
            string ver = "0.0.4";

            Console.Title = $"Szyfr Cezara {ver}";

            Class1.start(ver);

            for (;;)
            {
                Class1.menu();

                char wybor = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (wybor)
                {
                    case '1':
                        string tekst = "";
                        int liczba = 0;

                        tekst = Class1.sprawdzZakres();

                        liczba = Class1.sprawdzCzyLiczba();

                        Console.WriteLine("Tekst po szyfrowaniu: " + Class1.szyfr(tekst.ToLower(), liczba));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '2':
                        tekst = "";

                        tekst = Class1.sprawdzZakres();

                        liczba = Class1.sprawdzCzyLiczba();

                        Console.WriteLine("Tekst po deszyfrowaniu: " + Class1.deszyfr(tekst.ToLower(), liczba));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '3':
                        tekst = "";

                        tekst = Class1.sprawdzZakres();

                        Console.Clear();

                        for (int i = 1; i < 26; i++)
                        {
                            Console.WriteLine(i + $" próba = {Class1.szyfr(tekst.ToLower(), i)}");
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
    }
}
