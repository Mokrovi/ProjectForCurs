using ProjectForCurs.Model;
using System.Threading.Tasks;

namespace ProjectForCurs.Services.Database;

internal class PaymentMethodDb :
    Crud<PaymentMethod>
{
    public override async ValueTask<bool> AddAsync(PaymentMethod paymentMethod)
    {
        try
        {
            Context.PaymentMethods.Add(paymentMethod);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        
        return true;
    }

    public override async ValueTask<bool> DeleteAsync(PaymentMethod paymentMethod)
    {
        try
        {
            Context.PaymentMethods.Remove(paymentMethod);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
     
        return true;
    }

    public override async ValueTask<bool> UpdateAsync(PaymentMethod paymentMethod)
    {
        try
        {
            Context.PaymentMethods.Update(paymentMethod);
            await Context.SaveChangesAsync();
        }
        catch
        {
            return false; 
        }

        return true;
    }
}
