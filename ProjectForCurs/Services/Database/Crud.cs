using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectForCurs.Model;
using AppContext = ProjectForCurs.Model.AppContext;

namespace ProjectForCurs.Services.Database;

internal abstract class Crud<T>:
    IDbCrud<T> 
    where T : class
{
    private Lazy<AppContext> _context = new ();

    protected AppContext Context => 
        _context.Value;
    
    public ObservableCollection<Subscribe> GetSubscribes()
    {
        return new(Context.Subscribes);
    }

    public ObservableCollection<User> GetUsers()
    {
        return new(Context.Users
            .Include(s => s.Profile)
            .Include(s => s.Subscribe));
    }

    public ObservableCollection<Movie> GetMovies()
    {
        return new(Context.Movies);
    }

    public ObservableCollection<PaymentMethod> GetPaymentMethods()
    {
        return new(Context.PaymentMethods
            .Include(p => p.User.Profile));
    }

    public abstract ValueTask<bool> AddAsync(T item);
    public abstract ValueTask<bool> UpdateAsync(T item);
    public abstract ValueTask<bool> DeleteAsync(T item);
}