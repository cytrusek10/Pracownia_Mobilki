namespace Mobilna;

public partial class MainPage : ContentPage
{
    private bool vacuumOn = false;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnConfirmClicked(object sender, EventArgs e)
    {
        if (int.TryParse(WashEntry.Text, out int number) && number >= 1 && number <= 12)
            WashLabel.Text = "Numer prania: " + number;
    }

    private void OnVacuumClicked(object sender, EventArgs e)
    {
        vacuumOn = !vacuumOn;
        VacuumButton.Text = vacuumOn ? "Wyłącz" : "Włącz";
        VacuumLabel.Text = vacuumOn ? "Odkurzacz włączony" : "Odkurzacz wyłączony";
    }
}
