using System.Threading.Tasks;
using System.Windows;

namespace ProjectForCurs.ViewModel.ModelViewModel.PaymentViewModels;

internal class AddViewModel :
    ModelAbstraction
{
    public AddViewModel() =>
        AllValidate();

    protected override async Task CommandFunc()
    {
        var result = await database.AddAsync(selectedPaymentMethod);

        if (result)
        {
            selectedPaymentMethod = new();
            UpdateAllProperties();
            
            MessageBox.Show("Метод оплаты добавлен");
        }
        else
        {
            MessageBox.Show("Метод оплаты не добавлен");
        }
    }

    protected override bool CanExecute() =>
        !HasErrors && selectedPaymentMethod.User.Id != 0;

    protected override void UpdateAllProperties()
    {
        base.UpdateAllProperties();
        
        AllValidate();
    }

    private void AllValidate()
    {
        Validate(selectedPaymentMethod.ValidateNumberOfCard(), nameof(NumberOfCard));
        Validate(selectedPaymentMethod.ValidateTheHoldersName(), nameof(TheHoldersName));
        Validate(selectedPaymentMethod.ValidateCvc(), nameof(Cvc));
        Validate(selectedPaymentMethod.ValidateDeadLine(), nameof(DeadLine));
    }
}