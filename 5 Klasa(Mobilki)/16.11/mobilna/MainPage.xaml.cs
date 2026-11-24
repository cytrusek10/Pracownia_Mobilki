namespace ColorPicker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            // zdarzenie może wystąpić w trakcie inicjalizacji, zanim powstaną wszystkie kontrolki
            if (RedSlider == null || GreenSlider == null || BlueSlider == null || BlueValueLabel == null)
                return;

            int red = (int)Math.Round(RedSlider.Value);
            int green = (int)Math.Round(GreenSlider.Value);
            int blue = (int)Math.Round(BlueSlider.Value);

            RedValueLabel.Text = red.ToString();
            GreenValueLabel.Text = green.ToString();
            BlueValueLabel.Text = blue.ToString();

            PreviewBox.Color = Color.FromRgb(red, green, blue);
        }

        private void OnPickClicked(object sender, EventArgs e)
        {
            int red = (int)Math.Round(RedSlider.Value);
            int green = (int)Math.Round(GreenSlider.Value);
            int blue = (int)Math.Round(BlueSlider.Value);

            PickedColorLabel.Text = $"{red}, {green}, {blue}";
            PickedColorLabel.BackgroundColor = Color.FromRgb(red, green, blue);
        }
    }
}
