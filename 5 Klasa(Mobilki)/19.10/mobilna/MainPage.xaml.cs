namespace mobile
{
    public partial class MainPage : ContentPage
    {
        private const string LowerLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string SpecialCharacters = "!@#$%^&*()_+-=";

        private readonly Random random = new Random();
        private string generatedPassword = "";

        public MainPage()
        {
            InitializeComponent();
            PositionPicker.ItemsSource = new List<string>
            {
                "Kierownik", "Starszy programista", "Młodszy programista", "Tester"
            };
        }

        private async void OnGeneratePasswordClicked(object sender, EventArgs e)
        {
            int length = int.TryParse(PasswordLengthEntry.Text, out int parsed) ? Math.Max(parsed, 0) : 0;
            generatedPassword = GeneratePassword(length);
            await DisplayAlert("Hasło", generatedPassword, "OK");
        }

        private async void OnConfirmClicked(object sender, EventArgs e)
        {
            string position = PositionPicker.SelectedItem?.ToString() ?? "";
            string message = $"Dane pracownika: {FirstNameEntry.Text} {LastNameEntry.Text} {position} Hasło: {generatedPassword}";
            await DisplayAlert("Pracownik", message, "OK");
        }

        private string GeneratePassword(int length)
        {
            var characters = new char[length];
            for (int i = 0; i < length; i++)
            {
                characters[i] = LowerLetters[random.Next(LowerLetters.Length)];
            }

            // pozycje, na które trafią znaki z zaznaczonych zestawów (bez powtórzeń pozycji)
            var freePositions = new List<int>();
            for (int i = 0; i < length; i++) freePositions.Add(i);

            if (LettersCheckBox.IsChecked)
                PlaceRandomCharacter(characters, freePositions, UpperLetters);
            if (DigitsCheckBox.IsChecked)
                PlaceRandomCharacter(characters, freePositions, Digits);
            if (SpecialCheckBox.IsChecked)
                PlaceRandomCharacter(characters, freePositions, SpecialCharacters);

            return new string(characters);
        }

        private void PlaceRandomCharacter(char[] characters, List<int> freePositions, string characterSet)
        {
            if (freePositions.Count == 0) return;

            int listIndex = random.Next(freePositions.Count);
            int position = freePositions[listIndex];
            freePositions.RemoveAt(listIndex);
            characters[position] = characterSet[random.Next(characterSet.Length)];
        }
    }
}
