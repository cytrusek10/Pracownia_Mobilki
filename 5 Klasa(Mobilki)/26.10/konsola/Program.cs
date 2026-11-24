using System;
using System.Collections.Generic;

namespace SieveOfEratosthenes
{
    internal class Program
    {
        private const int Limit = 100; // n = 100

        /*******************************************************
         nazwa funkcji: FillSieve
         parametry wejściowe: isPrime - tablica wartości logicznych indeksowana liczbami 0..n
                              (po wykonaniu funkcji true oznacza liczbę pierwszą)
         wartość zwracana: brak (void), wynik zapisywany jest w przekazanej tablicy
         informacje: wypełnia tablicę wartościami true i wykreśla wielokrotności liczb
                     algorytmem sita Eratostenesa dla przedziału 2..n
         autor: 00000000000
        *******************************************************/
        public static void FillSieve(bool[] isPrime)
        {
            for (int i = 2; i < isPrime.Length; i++)
            {
                isPrime[i] = true;
            }

            int n = isPrime.Length - 1;
            for (int i = 2; i * i <= n; i++) // i nie większe niż pierwiastek z n
            {
                if (isPrime[i])
                {
                    for (int j = 2 * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
        }

        private static void Main()
        {
            bool[] isPrime = new bool[Limit + 1]; // indeksy 0 i 1 nie są używane
            FillSieve(isPrime);

            var primes = new List<int>();
            for (int number = 2; number <= Limit; number++)
            {
                if (isPrime[number]) primes.Add(number);
            }

            Console.WriteLine($"Liczby pierwsze w przedziale 2..{Limit}:");
            Console.WriteLine(string.Join(", ", primes));
            Console.WriteLine($"Znaleziono {primes.Count} liczb pierwszych.");
        }
    }
}
