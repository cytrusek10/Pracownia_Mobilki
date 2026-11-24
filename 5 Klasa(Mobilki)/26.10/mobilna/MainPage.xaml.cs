namespace mobile
{
    public partial class MainPage : ContentPage
    {
        private const int PostalCodeLength = 5;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCheckPriceClicked(object sender, EventArgs e)
        {
            if (LetterRadio.IsChecked)
            {
                ShowShipment("list.png", "Cena: 1,5 zł");
            }
            else if (ParcelRadio.IsChecked)
            {
                ShowShipment("paczka.png", "Cena: 10 zł");
            }
            else
            {
                ShowShipment("pocztowka.png", "Cena: 1 zł");
            }
        }

        private void ShowShipment(string imageName, string priceText)
        {
            ShipmentImage.Source = imageName;
            PriceLabel.Text = priceText;
        }

        private async void OnConfirmClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Przesyłka", ValidatePostalCode(PostalCodeEntry.Text ?? ""), "OK");
        }

        private static string ValidatePostalCode(string postalCode)
        {
            if (postalCode.Length != PostalCodeLength)
            {
                return "Nieprawidłowa liczba cyfr w kodzie pocztowym";
            }

            foreach (char character in postalCode)
            {
                if (character < '0' || character > '9')
                {
                    return "Kod pocztowy powinien się składać z samych cyfr";
                }
            }

            return "Dane przesyłki zostały wprowadzone";
        }
    }
}
