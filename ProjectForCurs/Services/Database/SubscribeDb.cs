using ProjectForCurs.Model;
using System.Threading.Tasks;

namespace ProjectForCurs.Services.Database;

internal class SubscribeDb : 
    Crud<Subscribe>
{
    public override async ValueTask<bool> AddAsync(Subscribe subscribe)
    {
        try
        {
            Context.Subscribes.Add(subscribe);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        
        return true;
    }

    public override async ValueTask<bool> DeleteAsync(Subscribe subscribe)
    {
        try
        {
            Context.Subscribes.Remove(subscribe);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }

    public override async ValueTask<bool> UpdateAsync(Subscribe subscribe)
    {
        try
        {
            Context.Subscribes.Update(subscribe);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }
}
