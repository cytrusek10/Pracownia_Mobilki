using System;
using System.Text;

namespace StringTools
{
    /*****************************************************
     klasa: StringUtils
     opis: statyczna biblioteka narzędziowa do operacji na łańcuchach znaków
     metody: CountVowels - zwraca liczbę samogłosek w łańcuchu (int)
             RemoveRepeatedCharacters - zwraca łańcuch bez powtórzeń znaków występujących obok siebie (string)
     autor: 00000000000
    *****************************************************/
    public static class StringUtils
    {
        private const string Vowels = "aąeęiouóyAĄEĘIOUÓY";

        public static int CountVowels(string text)
        {
            if (string.IsNullOrEmpty(text)) return 0;

            int vowelsCount = 0;
            foreach (char character in text)
            {
                if (Vowels.Contains(character)) vowelsCount++;
            }
            return vowelsCount;
        }

        public static string RemoveRepeatedCharacters(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";

            var result = new StringBuilder();
            result.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != text[i - 1]) result.Append(text[i]);
            }
            return result.ToString();
        }
    }

    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Write("Wpisz tekst: ");
            string text = Console.ReadLine();

            Console.WriteLine("Liczba samogłosek: " + StringUtils.CountVowels(text));
            Console.WriteLine("Tekst bez powtórzeń: " + StringUtils.RemoveRepeatedCharacters(text));
        }
    }
}
