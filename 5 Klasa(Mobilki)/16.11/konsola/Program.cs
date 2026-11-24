using System;

namespace NumberLottery
{
    internal class Program
    {
        private const int NumbersPerDraw = 6;
        private const int MinNumber = 1;
        private const int MaxNumber = 49;

        /**********************************************
         nazwa funkcji: FillDraws
         opis funkcji: wypełnia tablicę losowaniami; w każdym wierszu jest 6 różnych liczb z zakresu 1-49
         parametry: draws - dwuwymiarowa tablica int [n, 6] wypełniana wylosowanymi liczbami
                    random - generator liczb pseudolosowych
         zwracany typ i opis: brak (void), wynik zapisywany w tablicy draws
         autor: 00000000000
        **********************************************/
        public static void FillDraws(int[,] draws, Random random)
        {
            for (int drawIndex = 0; drawIndex < draws.GetLength(0); drawIndex++)
            {
                for (int column = 0; column < NumbersPerDraw; column++)
                {
                    int number;
                    do
                    {
                        number = random.Next(MinNumber, MaxNumber + 1);
                    }
                    while (IsInDraw(draws, drawIndex, column, number)); // liczby w zestawie nie mogą się powtarzać

                    draws[drawIndex, column] = number;
                }
            }
        }

        private static bool IsInDraw(int[,] draws, int drawIndex, int filledColumns, int number)
        {
            for (int column = 0; column < filledColumns; column++)
            {
                if (draws[drawIndex, column] == number) return true;
            }
            return false;
        }

        public static void PrintDraws(int[,] draws)
        {
            Console.WriteLine("Zestawy wylosowanych liczb:");
            for (int drawIndex = 0; drawIndex < draws.GetLength(0); drawIndex++)
            {
                Console.Write($"Losowanie {drawIndex + 1}:");
                for (int column = 0; column < NumbersPerDraw; column++)
                {
                    Console.Write(" " + draws[drawIndex, column]);
                }
                Console.WriteLine();
            }
        }

        public static int[] CountOccurrences(int[,] draws)
        {
            int[] occurrences = new int[MaxNumber + 1]; // indeks = liczba
            foreach (int number in draws)
            {
                occurrences[number]++;
            }
            return occurrences;
        }

        private static void PrintOccurrences(int[] occurrences)
        {
            for (int number = MinNumber; number <= MaxNumber; number++)
            {
                Console.WriteLine($"Wystąpienia liczby {number}: {occurrences[number]}");
            }
        }

        private static int ReadDrawsCount()
        {
            int count;
            Console.WriteLine("Ile wygenerować losowań?");
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.WriteLine("Podaj dodatnią liczbę całkowitą.");
            }
            return count;
        }

        private static void Main()
        {
            int drawsCount = ReadDrawsCount();
            int[,] draws = new int[drawsCount, NumbersPerDraw];

            FillDraws(draws, new Random());
            PrintDraws(draws);
            PrintOccurrences(CountOccurrences(draws));
        }
    }
}
