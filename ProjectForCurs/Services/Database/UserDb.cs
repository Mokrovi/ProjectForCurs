using System;
using System.Diagnostics;
using ProjectForCurs.Model;
using System.Threading.Tasks;
using AppContext = ProjectForCurs.Model.AppContext;

namespace ProjectForCurs.Services.Database;

internal class UserDb :
    Crud<User>
{
    public override async ValueTask<bool> AddAsync(User user)
    {
        try
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
        }
        catch
        {   
            return false;
        }

        return true;
    }

    public override async ValueTask<bool> UpdateAsync(User user)
    {
        try
        {
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }

    public override async ValueTask<bool> DeleteAsync(User user)
    {
        try
        {
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }
}
