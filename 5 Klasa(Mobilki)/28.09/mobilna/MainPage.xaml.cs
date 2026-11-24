using System.Collections.ObjectModel;

namespace Mobilna;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<string> notes = new ObservableCollection<string>
    {
        "Zakupy: chleb, masło, ser",
        "Do zrobienia: obiad, umyć podłogi",
        "weekend: kino, spacer z psem"
    };

    public MainPage()
    {
        InitializeComponent();
        NotesListView.ItemsSource = notes;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        notes.Add(NoteEntry.Text);
        NoteEntry.Text = string.Empty;
    }
}
