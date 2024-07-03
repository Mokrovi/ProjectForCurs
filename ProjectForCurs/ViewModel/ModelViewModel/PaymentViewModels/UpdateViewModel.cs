using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.PaymentViewModels;

internal class UpdateViewModel :
    ModelAbstraction
{
    private ObservableCollection<PaymentMethod>? _paymentMethods;

    public ObservableCollection<PaymentMethod> PaymentMethods
    {
        set => SetField(ref _paymentMethods, value);
        get => _paymentMethods ??= database.GetPaymentMethods();
    }

    public PaymentMethod SelectedPaymentMethod
    {
        set
        {
            SetField(ref selectedPaymentMethod, value);
            
            UpdateAllProperties();
        }
        get => selectedPaymentMethod;
    }

    protected override async Task CommandFunc()
    {
        var result = await database.UpdateAsync(selectedPaymentMethod);

        MessageBox.Show(result ? "Метод оплаты обновлён" : "Метод оплаты не обновлён");
    }

    protected override bool CanExecute() =>
        !HasErrors && selectedPaymentMethod.Id != 0 && selectedPaymentMethod.User.Id != 0;
}