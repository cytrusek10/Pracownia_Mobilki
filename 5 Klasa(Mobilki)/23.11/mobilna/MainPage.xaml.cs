using CommunityToolkit.Maui.Storage;
using System.Text;

namespace CaesarMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEncryptClicked(object sender, EventArgs e)
        {
            // niepoprawny klucz (brak liczby całkowitej) traktujemy jak 0
            int key = int.TryParse(KeyEntry.Text, out int parsedKey) ? parsedKey : 0;
            EncryptedTextLabel.Text = Encrypt(PlainTextEditor.Text ?? "", key);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(EncryptedTextLabel.Text ?? ""));
            await FileSaver.Default.SaveAsync("szyfr.txt", stream, CancellationToken.None); // systemowe okno zapisu
        }

        // ta sama logika co w aplikacji konsolowej (CaesarCipher.Encrypt)
        private static string Encrypt(string plainText, int key)
        {
            const int alphabetLength = 26;
            int shift = ((key % alphabetLength) + alphabetLength) % alphabetLength;
            var result = new char[plainText.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                char character = plainText[i];
                result[i] = (character >= 'a' && character <= 'z')
                    ? (char)('a' + (character - 'a' + shift) % alphabetLength)
                    : character;
            }
            return new string(result);
        }
    }
}
