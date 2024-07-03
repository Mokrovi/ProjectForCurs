using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.MovieViewModels;

internal class DeleteViewModel : 
    AbstractViewModel
{
    private ObservableCollection<Movie>? _movies;

    public ObservableCollection<Movie> Movies
    {
        set => SetField(ref _movies, value);
        get => _movies ??= database.GetMovies();
    }

    public Movie SelectedMovie
    {
        set => SetField(ref selectedMovie, value);
        get => selectedMovie;
    }
    
    protected override async Task CommandFunc()
    {
        var result = await database.DeleteAsync(SelectedMovie);


        if (result)
        {
            Movies.Remove(SelectedMovie);
            SelectedMovie = new();
            MessageBox.Show("Фильм был удалён");
        }
        else
        {
            MessageBox.Show("Произошла ошибка");
        }

    }

    protected override bool CanExecute() =>
        SelectedMovie.Id != 0;
}