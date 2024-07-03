using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.UserViewModels;

internal class DeleteViewModel :
    AbstractViewModel
{
    private ObservableCollection<User>? _users;

    public ObservableCollection<User> Users
    {
        set => SetField(ref _users, value);
        get => _users ??= database.GetUsers();
    }

    public User SelectedUser
    {
        set => SetField(ref selectedUser, value);
        get => selectedUser;
    }

    protected override async Task CommandFunc()
    {
        var result = await database.DeleteAsync(selectedUser);

        if (result)
        {
            Users.Remove(selectedUser);
            selectedUser = new();

            MessageBox.Show("Пользователь удалён");
        }
        else
        {
            MessageBox.Show("Пользователь не удалён");
        }
    }

    protected override bool CanExecute() =>
        SelectedUser.Id != 0;
}