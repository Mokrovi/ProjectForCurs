using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using ProjectForCurs.Services.Database;
using ProjectForCurs.Utilities;

namespace ProjectForCurs.ViewModel;

internal class LoginViewModel : Notify
{
    private IDbLoginService? _database = new LoginDb();
    private readonly Window _window;
    
    private string? _email;
    private string? _password;

    public string Email
    {
        set
        {
            SetField(ref _email, value);
            Validate(ValidateEmail());
        }
        get => _email ??= "";
    }

    public string Password
    {
        set
        {
            SetField(ref _password, value);
            Validate(ValidatePassword());
        }
        get => _password ??= "";
    }

    public ICommand LoginCommand { private set; get; }

    public LoginViewModel(Window window)
    {
        _window = window;

        LoginCommand = new RelayCommand(Login, CanExecute);
    }

    private void Login()
    {
        if (!ValidCredentials())
        {
            MessageBox.Show("Не верные данные"); 
            return ;
        }
        
        MenuWindow menuWindow = new()
        {
            Width = _window.Width,
            Height = _window.ActualHeight,
            WindowState = WindowState.Maximized

        };

        menuWindow.Show();
        _window.Close();
    }

    private bool ValidCredentials()
    {
        var profile = (_database ??= new LoginDb()).GetProfileOrNull(Email);
        
        return profile is not null 
               && profile.CheckCorrectPassword(Password)
               && profile.IsAdmin;
    }

    private bool CanExecute() =>
        !HasErrors;

    private List<string> ValidatePassword()
    {
        var errors = new List<string>();
        
        if (Password.Length >= 50)
            errors.Add("Пароль слишком длинный");
        
        return errors;
    }

    private List<string> ValidateEmail()
    {
        var errors = new List<string>();
        var result = Regex.IsMatch(Email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,40}$");

        if (!result)
            errors.Add("Почта должна содержать собаку и домен");

        return errors;
    }
}