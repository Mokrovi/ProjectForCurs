using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjectForCurs.Model;

internal partial class Subscribe
{
    public int Id { set; get; }
    public string Name { set; get; } = "";
    public string Description { set; get; } = "";
    public int Price { set; get; }
    public List<User> Users { set; get; } = new();

    public List<string> ValidateName()
    {
        var errors = new List<string>();
        
            if (Name.Trim().Length == 0)
                errors.Add("Имя не может быть пустым");

            if (SpaceCheckerRegex().IsMatch(Name))
                errors.Add("Не должно быть нескольких пробелов");
            
            if (Name.Length >= 60)
                errors.Add("Имя слишком большое");

            if (CheckUniqueName(Name))
                errors.Add("Имя уже есть");

        return errors;
    }

    public List<string> ValidateDescription()
    {
        var errors = new List<string>();
        
        if (Description.Trim().Length == 0)
            errors.Add("Описание не может быть пустым");
        
        if (SpaceCheckerRegex().IsMatch(Description))
            errors.Add("Не должно быть нескольких пробелов");

        if (Description.Length >= 60)
            errors.Add("Описание слишком большое");
        
        return errors;
    }

    public List<string> ValidatePrice()
    {
        var errors = new List<string>();
        
        if (Price < 0)
            errors.Add("Цена не может быть отрицательной");

        return errors;
    }

    private static bool CheckUniqueName(string name)
    {
        using var context = new AppContext();

        var subscribes = context.Subscribes
            .Where(s => s.Name == name)
            .ToList();

        return subscribes.Any();
    }
    
    [GeneratedRegex("\\s+")]
    private static partial Regex SpaceCheckerRegex();
}