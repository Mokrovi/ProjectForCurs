using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectForCurs.Model;

internal partial class PaymentMethod
{
    public int Id { set; get; }
    public string NumberOfCard { set; get; } = "";
    public string TheHoldersName { set; get; } = "";
    public string Cvc { set; get; } = "";
    public DateOnly DeadLine { set; get; }
    public int UserId { set; get; }
    public virtual User User { set; get; } = new();
    
    public List<string> ValidateNumberOfCard()
    {
        var errors = new List<string>();

        if (!MyRegex().IsMatch(NumberOfCard))
            errors.Add("Номер карты должен состоять из четырёх квартетов");

        return errors;
    }

    public List<string> ValidateTheHoldersName()
    {
        var errors = new List<string>();

        if (TheHoldersName.Length >= 60)
            errors.Add("Держатель карты слишком длинный");

        if (!MyRegex1().IsMatch(TheHoldersName))
            errors.Add("Должно состоять из двух слов на латинице");
        
        return errors;
    }

    public List<string> ValidateCvc()
    {
        var errors = new List<string>();

        if (!MyRegex2().IsMatch(Cvc))
            errors.Add("Cvc должен состоять из трёх цифр");
        
        return errors;
    }

    public List<string> ValidateDeadLine()
    {
        var errors = new List<string>();

        if (DateOnly.FromDateTime(DateTime.Now) >= DeadLine)
            errors.Add("Карта не должна быть просрочена");
        
        return errors;
    }
    

    [GeneratedRegex("^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
    private static partial Regex MyRegex();
    
    [GeneratedRegex("^[A-Z][a-z]+ [A-Z][a-z]+$")]
    private static partial Regex MyRegex1();
    
    [GeneratedRegex("^[0-9]{3}$")]
    private static partial Regex MyRegex2();
}