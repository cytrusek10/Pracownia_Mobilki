namespace Mobilna;

public partial class MainPage : ContentPage
{
    private readonly string[] quotes = { "Dzień dobry", "Good morning", "Buenos dias" };
    private int quoteIndex = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        int size = (int)Math.Round(e.NewValue);
        SizeLabel.Text = "Rozmiar: " + size;
        QuoteLabel.FontSize = size;
    }

    private void OnNextQuoteClicked(object sender, EventArgs e)
    {
        quoteIndex = (quoteIndex + 1) % quotes.Length;
        QuoteLabel.Text = quotes[quoteIndex];
    }
}
