using System.Collections.ObjectModel;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.UserViewModels;

internal abstract class ModelAbstraction :
    AbstractViewModel
{
    private ObservableCollection<Subscribe>? _subscribes;
    
    public ObservableCollection<Subscribe> Subscribes
    {
        set => SetField(ref _subscribes, value);
        get => _subscribes ??= database.GetSubscribes();
    }

    public virtual string Nickname
    {
        set
        {
            if (selectedUser.Profile.Nickname == value)
                return;

            selectedUser.Profile.Nickname = value;
            Validate(Profile.ValidateNickname(value));
        }
        get => selectedUser.Profile.Nickname ?? "";
    }
    
    public string Name
    {
        set
        {
            if (selectedUser.Profile.Name == value)
                return;

            selectedUser.Profile.Name = value;
            Validate(Profile.ValidateName(value));
        }
        get => selectedUser.Profile.Name ?? "";
    }
    
    public string Surname
    {
        set
        {
            if (selectedUser.Profile.Surname == value)
                return;

            selectedUser.Profile.Surname = value;
            Validate(Profile.ValidateSurname(value));
        }
        get => selectedUser.Profile.Surname ?? "";
    }
    
    public string LastName
    {
        set
        {
            if (selectedUser.Profile.LastName == value)
                return;

            selectedUser.Profile.LastName = value;
            Validate(Profile.ValidateLastName(value));
        }
        get => selectedUser.Profile.LastName ?? "";
    }
    
    public virtual string Email
    {
        set
        {
            if (selectedUser.Profile.Email == value)
                return;

            selectedUser.Profile.Email = value;
            Validate(Profile.ValidateEmail(value));
        }
        get => selectedUser.Profile.Email ?? "";
    }
    
    public virtual string Password
    {
        set
        {
            if (selectedUser.Profile.Password == value)
                return;

            selectedUser.Profile.Password = value;
            Validate(Profile.ValidatePassword(value));
        }
        get => selectedUser.Profile.Password ?? "";
    }

    public bool IsAdmin
    {
        set
        {
            if (selectedUser.Profile.IsAdmin == value)
                return;
            
            selectedUser.Profile.IsAdmin = value;
        }
        get => selectedUser.Profile.IsAdmin;
    }
    
    public Subscribe Subscribe
    {
        set
        {
            if (selectedUser.Subscribe == value)
                return;
            
            selectedUser.Subscribe = value;
        }
        get => selectedUser.Subscribe ?? new Subscribe();
    }
    
    protected virtual void UpdateAllProperty()
    {
        OnPropertyChanged(nameof(Nickname));
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(Surname));
        OnPropertyChanged(nameof(LastName));
        OnPropertyChanged(nameof(Email));
        OnPropertyChanged(nameof(Password));
        OnPropertyChanged(nameof(IsAdmin));
        OnPropertyChanged(nameof(Subscribe));
    }
}