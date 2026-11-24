using System;
using System.Text;

namespace SentinelSearch
{
    internal class Program
    {
        private const int ArraySize = 50;
        private const int MinValue = 1;
        private const int MaxValue = 100;

        /******************************************************
         nazwa funkcji: SearchWithSentinel
         argumenty: arrayWithSentinel - tablica liczb z jednym dodatkowym miejscem na końcu na wartownika
                    elementsCount - liczba właściwych elementów tablicy (bez wartownika)
                    searchedValue - szukana wartość
         typ zwracany: int, indeks pierwszego wystąpienia szukanej wartości lub -1, gdy jej nie ma
         informacje: wyszukiwanie liniowe z wartownikiem - szukana wartość jest wstawiana
                     na koniec tablicy, dzięki czemu pętla nie wymaga sprawdzania granic
         autor: 00000000000
        ******************************************************/
        public static int SearchWithSentinel(int[] arrayWithSentinel, int elementsCount, int searchedValue)
        {
            arrayWithSentinel[elementsCount] = searchedValue; // wartownik

            int index = 0;
            while (arrayWithSentinel[index] != searchedValue)
            {
                index++;
            }

            // trafiliśmy na wartownika - w tablicy nie było szukanej wartości
            return index == elementsCount ? -1 : index;
        }

        public static void FillWithRandomNumbers(int[] array, int elementsCount, Random random)
        {
            for (int i = 0; i < elementsCount; i++)
            {
                array[i] = random.Next(MinValue, MaxValue + 1);
            }
        }

        private static string FormatArray(int[] array, int elementsCount)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < elementsCount; i++)
            {
                if (i > 0) builder.Append(", ");
                builder.Append(array[i]);
            }
            return builder.ToString();
        }

        private static int ReadSearchedValue()
        {
            int value;
            Console.Write($"Podaj wartość do wyszukania ({MinValue}-{MaxValue}): ");
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("To nie jest liczba całkowita. Spróbuj ponownie: ");
            }
            return value;
        }

        private static void RunSearchAndPrint(int[] array, int searchedValue)
        {
            int index = SearchWithSentinel(array, ArraySize, searchedValue);

            Console.WriteLine("Zawartość tablicy: " + FormatArray(array, ArraySize));
            if (index >= 0)
                Console.WriteLine($"Wartość {searchedValue} znaleziono pod indeksem {index}.");
            else
                Console.WriteLine($"Wartości {searchedValue} nie ma w tablicy.");
        }

        private static void Main()
        {
            var random = new Random();
            int[] numbers = new int[ArraySize + 1]; // +1 miejsce na wartownika
            FillWithRandomNumbers(numbers, ArraySize, random);

            // test działania: wartość na pewno obecna w tablicy oraz taka, której nie ma
            Console.WriteLine("--- Test działania ---");
            RunSearchAndPrint(numbers, numbers[ArraySize / 2]);
            RunSearchAndPrint(numbers, MaxValue + 1);

            Console.WriteLine();
            Console.WriteLine("--- Wyszukiwanie użytkownika ---");
            RunSearchAndPrint(numbers, ReadSearchedValue());
        }
    }
}
