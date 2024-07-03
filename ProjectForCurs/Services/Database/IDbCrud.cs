using ProjectForCurs.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProjectForCurs.Services.Database;

internal interface IDbCrud<in T> where T : class
{
    public ObservableCollection<Subscribe> GetSubscribes();
    public ObservableCollection<User> GetUsers();
    public ObservableCollection<Movie> GetMovies();
    public ObservableCollection<PaymentMethod> GetPaymentMethods();
    public ValueTask<bool> AddAsync(T item);
    public ValueTask<bool> UpdateAsync(T item);
    public ValueTask<bool> DeleteAsync(T item);
}
