using System.Collections.ObjectModel;
using ProjectForCurs.Model;
using ProjectForCurs.Services.Database;

namespace ProjectForCurs.ViewModel.ModelViewModel.MovieViewModels;

internal class ReadViewModel 
{
    private readonly IDbCrud<Movie> _database = new MovieDb();
    
    private ObservableCollection<Movie>? _movies;

    public ObservableCollection<Movie> Movies
    {
        set => _movies = value;
        get => _movies ??= _database.GetMovies();
    }
}