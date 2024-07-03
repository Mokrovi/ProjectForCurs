using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.PaymentViewModels;

internal class DeleteViewModel :
    AbstractViewModel
{
    private ObservableCollection<PaymentMethod>? _paymentMethods;

    public ObservableCollection<PaymentMethod> PaymentMethods
    {
        set => SetField(ref _paymentMethods, value);
        get => _paymentMethods ??= database.GetPaymentMethods();
    }

    public PaymentMethod SelectedPaymentMethod
    {
        set => SetField(ref selectedPaymentMethod, value);
        get => selectedPaymentMethod;
    }
    
    protected override async Task CommandFunc()
    {
        var result = await database.DeleteAsync(SelectedPaymentMethod);

        if (result)
        {
            PaymentMethods.Remove(SelectedPaymentMethod);
            SelectedPaymentMethod = new();
            MessageBox.Show("Способ оплаты удалён");
        }
        else
        {
            MessageBox.Show("Способ оплаты не удалён"); 
        }
    }

    protected override bool CanExecute() =>
        SelectedPaymentMethod.Id != 0;
}