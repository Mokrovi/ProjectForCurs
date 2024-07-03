using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.UserViewModels;

internal class AddViewModel :
    ModelAbstraction
{
    public AddViewModel() =>
        AllValidate();

    protected override async Task CommandFunc()
    {  
        selectedUser.Profile.HashPassword();
        var result = await database.AddAsync(selectedUser);

        if (result)
        {
            selectedUser = new();
            UpdateAllProperty();

            MessageBox.Show("Пользователь добавлен");
        }
        else
        {
            MessageBox.Show("Пользователь не добавлен");
        }
    }

    protected override bool CanExecute() =>
        !HasErrors;

    protected override void UpdateAllProperty()
    {
        base.UpdateAllProperty();
        
        AllValidate();
    }

    private void AllValidate()
    {
        Validate(Profile.ValidateNickname(""), nameof(Nickname));
        Validate(Profile.ValidateName(""), nameof(Name));
        Validate(Profile.ValidateSurname(""), nameof(Surname));
        Validate(Profile.ValidateLastName(""), nameof(LastName));
        Validate(Profile.ValidateEmail(""), nameof(Email));
        Validate(Profile.ValidatePassword(""), nameof(Password));
    }
}