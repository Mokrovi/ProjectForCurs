using System.Collections.ObjectModel;
using ProjectForCurs.Model;
using ProjectForCurs.Services.Database;

namespace ProjectForCurs.ViewModel.ModelViewModel.UserViewModels;

internal class ReadViewModel :
    Notify
{
    private readonly IDbCrud<User> _database = new UserDb();

    private ObservableCollection<User>? _users;

    public ObservableCollection<User> Users
    {
        set => SetField(ref _users, value);
        get => _users ??= _database.GetUsers();
    }

}