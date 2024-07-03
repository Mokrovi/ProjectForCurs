using ProjectForCurs.Model;
using System.Threading.Tasks;

namespace ProjectForCurs.Services.Database;

internal class MovieDb :
     Crud<Movie>
{
    public override async ValueTask<bool> AddAsync(Movie movie)
    {
        try
        {
            Context.Movies.Add(movie);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }

    public override async ValueTask<bool> UpdateAsync(Movie movie)
    {
        try
        {
            Context.Movies.Update(movie);
            await Context.SaveChangesAsync();
        }
        catch 
        {
            return false;
        }

        return true;
    }

    public override async ValueTask<bool> DeleteAsync(Movie movie)
    {
        try
        {
            Context.Movies.Remove(movie);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }
}
