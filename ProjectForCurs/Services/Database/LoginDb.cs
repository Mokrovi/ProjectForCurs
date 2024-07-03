using System;
using System.Linq;
using ProjectForCurs.Model;
using AppContext = ProjectForCurs.Model.AppContext;

namespace ProjectForCurs.Services.Database;

internal class LoginDb : IDbLoginService
{
    private Lazy<AppContext> _context;

    private AppContext Context => _context.Value;

    public LoginDb()
    {
        _context = new();
    }
    
    public Profile? GetProfileOrNull(string email)
    {
        try
        {
            return Context.Profiles.FirstOrDefault(p => p.Email == email);
        }
        catch
        {
            return null;
        }
    }
}