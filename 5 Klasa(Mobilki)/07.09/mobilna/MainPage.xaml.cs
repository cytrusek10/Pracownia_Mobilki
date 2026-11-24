namespace Mobilna;

public partial class MainPage : ContentPage
{
    // Nazwy plików grafik kości - dostosuj do plików z pliki1.zip (np. "1.jpg" -> "kostka1.jpg")
    private const string QuestionImage = "question.jpg";
    private readonly string[] diceImages = { "kostka1.jpg", "kostka2.jpg", "kostka3.jpg", "kostka4.jpg", "kostka5.jpg", "kostka6.jpg" };

    private readonly Random random = new Random();
    private Image[] diceControls;
    private int gameScore = 0;

    public MainPage()
    {
        InitializeComponent();
        diceControls = new[] { Dice1, Dice2, Dice3, Dice4, Dice5 };
    }

    private int CountPoints(int[] results)
    {
        int[] occurrences = new int[7];
        foreach (int value in results) occurrences[value]++;

        int points = 0;
        for (int value = 1; value <= 6; value++)
            if (occurrences[value] >= 2) points += value * occurrences[value];
        return points;
    }

    private void OnRollClicked(object sender, EventArgs e)
    {
        int[] results = new int[5];
        for (int i = 0; i < 5; i++)
        {
            results[i] = random.Next(1, 7);
            diceControls[i].Source = diceImages[results[i] - 1];
        }
        int rollScore = CountPoints(results);
        gameScore += rollScore;
        RollScoreLabel.Text = "Wynik tego losowania: " + rollScore;
        GameScoreLabel.Text = "Wynik gry: " + gameScore;
    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        foreach (Image dice in diceControls) dice.Source = QuestionImage;
        gameScore = 0;
        RollScoreLabel.Text = "Wynik tego losowania: 0";
        GameScoreLabel.Text = "Wynik gry: 0";
    }
}
