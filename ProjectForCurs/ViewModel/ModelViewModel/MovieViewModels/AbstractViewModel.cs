using ProjectForCurs.Model;
using ProjectForCurs.Services.Database;

namespace ProjectForCurs.ViewModel.ModelViewModel.MovieViewModels;

internal abstract class AbstractViewModel :
    BaseViewModel
{
    protected readonly IDbCrud<Movie> database = new MovieDb();
    protected Movie selectedMovie = new();
}