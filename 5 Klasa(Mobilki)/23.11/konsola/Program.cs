using System;

namespace CaesarCipherApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Podaj tekst jawny (małe litery i spacje): ");
            string plainText = Console.ReadLine() ?? "";

            int key;
            Console.Write("Podaj klucz (liczba całkowita): ");
            while (!int.TryParse(Console.ReadLine(), out key))
            {
                Console.Write("To nie jest liczba całkowita. Podaj klucz ponownie: ");
            }

            Console.WriteLine("Tekst zaszyfrowany: " + CaesarCipher.Encrypt(plainText, key));
        }
    }
}
