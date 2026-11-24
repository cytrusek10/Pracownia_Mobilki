namespace Vet
{
    public partial class MainPage : ContentPage
    {
        private const int DogMaxAge = 18;
        private const int CatMaxAge = 20;
        private const int GuineaPigMaxAge = 9;

        private string selectedSpecies = "";
        private int age = 0;

        public MainPage()
        {
            InitializeComponent();
            SpeciesListView.ItemsSource = new List<string> { "Pies", "Kot", "Świnka morska" };
        }

        private void OnSpeciesTapped(object sender, ItemTappedEventArgs e)
        {
            selectedSpecies = e.Item.ToString();

            switch (selectedSpecies)
            {
                case "Pies": AgeSlider.Maximum = DogMaxAge; break;
                case "Kot": AgeSlider.Maximum = CatMaxAge; break;
                case "Świnka morska": AgeSlider.Maximum = GuineaPigMaxAge; break;
            }
        }

        private void OnAgeChanged(object sender, ValueChangedEventArgs e)
        {
            age = (int)Math.Round(e.NewValue); // wiek zawsze jako liczba całkowita
            AgeLabel.Text = age.ToString();
        }

        private void OnConfirmClicked(object sender, EventArgs e)
        {
            SummaryLabel.Text = $"{OwnerEntry.Text}, {selectedSpecies}, {age}, " +
                                $"{PurposeEntry.Text}, {VisitTimePicker.Time:hh\\:mm}";
        }
    }
}
