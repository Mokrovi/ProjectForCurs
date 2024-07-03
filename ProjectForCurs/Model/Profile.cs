using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectForCurs.Model;

internal partial class Profile
{
    public int Id { set; get; }
    public string Nickname { set; get; } = "";
    public string Name { set; get; } = "";
    public string Surname { set; get; } = "";
    public string LastName { set; get; } = "";
    public string Email { set; get; } = "";
    public string Password { set; get; } = "";
    public bool IsAdmin { set; get; }
    
    public User? User { set; get; }
    
    public void HashPassword()
    {
        var inputBytes = Encoding.UTF8.GetBytes(Password);
        var hashBytes = SHA256.HashData(inputBytes);

        Password = Convert.ToBase64String(hashBytes);
    }

    public bool CheckCorrectPassword(string password)
    {
        var inputBytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(inputBytes);
        password = Convert.ToBase64String(hash);

        return string.Equals(Password, password);
    }

    public static List<string> ValidateEmail(string email)
    {
        var errors = new List<string>();

        if (!EmailRegex().IsMatch(email))
            errors.Add("Почта должна содержать собаку и домен");

        if (!CheckUniqueEmail(email))
            errors.Add("Почта уже есть");

        return errors;
    }

    public static List<string> ValidatePassword(string password)
    {
        var errors = new List<string>();

        if (password.Contains(' '))
            errors.Add("Пароль должен быть без пробелов");

        if (password.Length is <= 5 or >= 30)
            errors.Add("Пароль должен быть от 5 до 30 символов");
        
        if (!password.Any(char.IsUpper))
            errors.Add("Пароль должен содержать заглавную букву");
        
        if (!password.Any(char.IsLower))
            errors.Add("Пароль должен содержать прописную букву");
        
        if (!password.Any(char.IsDigit))
            errors.Add("Пароль должен содержать цифру");
        
        return errors;
    }

    public static List<string> ValidateNickname(string nickname)
    {
        var errors = new List<string>();

        if (nickname.Length >= 60)
            errors.Add("Ник слишком большой");

        if (!NicknameRegex().IsMatch(nickname))
            errors.Add("Ник должен содержать только латиницу или цифры");

        if (!CheckUniqueNickName(nickname))
            errors.Add("Такой ник уже есть");
        
        return errors;
    }

    public static List<string> ValidateName(string name)
    {
        var errors = new List<string>();

        if (name.Length >= 60)
            errors.Add("Имя слишком большое");

        if (!NameRegex().IsMatch(name))
            errors.Add("Имя должно содержать только кириллицу");
        
        return errors;
    }
    
    public static List<string> ValidateLastName(string lastName)
    {
        var errors = new List<string>();

        if (lastName.Length >= 60)
            errors.Add("Фамилия слишком большая");

        if (!NameRegex().IsMatch(lastName))
            errors.Add("Фамилия должна содержать только кириллицу");
        
        return errors;
    }
    
    public static List<string> ValidateSurname(string surname)
    {
        var errors = new List<string>();
        
        if (surname.Length >= 60)
            errors.Add("Отчество слишком большое");
        
        if (!NameRegex().IsMatch(surname))
            errors.Add("Отчество должно содержать только кириллицу");

        return errors;
    }

    private static bool CheckUniqueEmail(string email)
    {
        using var context = new AppContext();

        return !context.Profiles
           .Any(p => p.Email == email);
    }

    private static bool CheckUniqueNickName(string nickname)
    {
        using var context = new AppContext();

        return !context.Profiles
           .Any(p => p.Nickname == nickname);
    }

    [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,40}$")]
    private static partial Regex EmailRegex();
    
    [GeneratedRegex("^[A-Za-z0-9]+$")]
    private static partial Regex NicknameRegex();
    
    [GeneratedRegex("^[А-Яа-я]+$")]
    private static partial Regex NameRegex();
    
}