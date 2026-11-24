namespace mobile
{
    public partial class MainPage : ContentPage
    {
        private int likesCount = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLikeClicked(object sender, EventArgs e)
        {
            likesCount++;
            RefreshLikesLabel();
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            likesCount = Math.Max(0, likesCount - 1); // licznik nie może być niższy niż 0
            RefreshLikesLabel();
        }

        private void RefreshLikesLabel()
        {
            LikesLabel.Text = $"{likesCount} polubień";
        }
    }
}
