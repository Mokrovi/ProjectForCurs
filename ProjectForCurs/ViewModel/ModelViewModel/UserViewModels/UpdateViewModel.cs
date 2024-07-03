using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.UserViewModels;

internal class UpdateViewModel : 
    ModelAbstraction
{
    private ObservableCollection<User>? _users;
    private string _startEmail = "";
    private string _startNickname = "";
    private string _newPassword = "";
    
    public ObservableCollection<User> Users
    {
        set => SetField(ref _users, value);
        get => _users ??= database.GetUsers();
    }

    public User SelectedUser
    {
        set
        {
            SetField(ref selectedUser, value);

            _startNickname = value.Profile.Nickname ?? "";
            _startEmail = value.Profile.Email ?? "";
            
            UpdateAllProperty();
        }
        get => selectedUser;
    }

    public override string Nickname
    {
        set
        {
            if (selectedUser.Profile.Nickname == value)
                return;

            selectedUser.Profile.Nickname = value;
            
            if (value != _startNickname)
                Validate(Profile.ValidateNickname(value));   
            else 
                ClearErrors(nameof(Nickname));
        }
        get => selectedUser.Profile.Nickname ??= "";
    }

    public override string Email
    {
        set
        {
            if (selectedUser.Profile.Email == value)
                return;

            selectedUser.Profile.Email = value;
            
            if (value != _startEmail)
                Validate(Profile.ValidateEmail(value));
            else
                ClearErrors(nameof(Email));
        }
        get => selectedUser.Profile.Email ?? "";
    }

    public override string Password 
    {
        set
        {
            _newPassword = value;
            
            if (!string.IsNullOrWhiteSpace(_newPassword))
                Validate(Profile.ValidatePassword(value));
            else 
                ClearErrors(nameof(Password));
        } 
        get => _newPassword;
        
    }

    protected override async Task CommandFunc()
    {
        if (!string.IsNullOrWhiteSpace(_newPassword))
        {
            selectedUser.Profile.Password = _newPassword; 
            selectedUser.Profile.HashPassword();
        }
        
        var result = await database.UpdateAsync(selectedUser);
        
        MessageBox.Show(result ? "Пользователь обновлён" : "Пользователь не обновлён");
    }

    protected override bool CanExecute() =>
        !HasErrors && SelectedUser.Id != 0;
}