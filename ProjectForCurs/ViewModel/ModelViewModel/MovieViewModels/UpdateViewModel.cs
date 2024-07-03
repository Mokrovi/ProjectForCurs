using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.MovieViewModels;

internal class UpdateViewModel : 
    ModelAbstraction
{
    private ObservableCollection<Movie>? _movies;

    public Movie SelectedMovie
    {
        set
        {
            SetField(ref selectedMovie, value);

            UpdateAllProperties();
        }
        get => selectedMovie;
    }

    public ObservableCollection<Movie> Movies
    {
        set => SetField(ref _movies, value);
        get => _movies ??= database.GetMovies();
    }

    protected override async Task CommandFunc()
    {
        var result = await database.UpdateAsync(selectedMovie);

        MessageBox.Show(result ? "Фильм обновлён" : "Фильм не обновлён");
    }

    protected override bool CanExecute() =>
        !HasErrors && selectedMovie.Id != 0;
}