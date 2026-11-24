namespace CaesarCipherApp
{
    public static class CaesarCipher
    {
        private const int AlphabetLength = 26;

        /**********************************************
         nazwa funkcji: Encrypt
         opis funkcji: szyfruje tekst szyfrem Cezara (małe litery a-z, spacje bez zmian)
         parametry: plainText - tekst jawny (małe litery i spacje)
                    key - klucz szyfrowania, liczba całkowita (dodatnia, ujemna lub 0, może być większa od 26)
         zwracany typ i opis: string, tekst zaszyfrowany
         autor: 00000000000
        **********************************************/
        public static string Encrypt(string plainText, int key)
        {
            int shift = ((key % AlphabetLength) + AlphabetLength) % AlphabetLength; // klucz sprowadzony do 0..25
            char[] result = new char[plainText.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                char character = plainText[i];
                if (character >= 'a' && character <= 'z')
                {
                    result[i] = (char)('a' + (character - 'a' + shift) % AlphabetLength);
                }
                else
                {
                    result[i] = character; // spacja i inne znaki bez zmian
                }
            }
            return new string(result);
        }
    }
}
