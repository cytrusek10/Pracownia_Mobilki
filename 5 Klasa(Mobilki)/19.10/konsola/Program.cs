using System;

namespace EuclideanAlgorithm
{
    internal class Program
    {
        /**********************************************
         nazwa funkcji: Nwd
         opis funkcji: wyznacza największy wspólny dzielnik dwóch liczb algorytmem Euklidesa
                       (wersja z odejmowaniem, zgodnie ze schematem); bez operacji wejścia-wyjścia
         parametry: a - pierwsza liczba całkowita dodatnia
                    b - druga liczba całkowita dodatnia
         zwracany typ i opis: int, największy wspólny dzielnik liczb a i b
         autor: 00000000000
        ***********************************************/
        public static int Nwd(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }

        private static int ReadPositiveInteger(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("Wymagana jest liczba całkowita dodatnia. Spróbuj ponownie: ");
            }
            return value;
        }

        private static void Main()
        {
            // test działania funkcji
            Console.WriteLine("Test: NWD(48, 18) = " + Nwd(48, 18) + " (oczekiwano 6)");
            Console.WriteLine("Test: NWD(17, 5) = " + Nwd(17, 5) + " (oczekiwano 1)");
            Console.WriteLine();

            int a = ReadPositiveInteger("Podaj liczbę a: ");
            int b = ReadPositiveInteger("Podaj liczbę b: ");
            Console.WriteLine($"NWD({a}, {b}) = {Nwd(a, b)}");
        }
    }
}
