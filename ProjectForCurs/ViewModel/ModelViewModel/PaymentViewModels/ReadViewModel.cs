using System.Collections.ObjectModel;
using ProjectForCurs.Model;
using ProjectForCurs.Services.Database;

namespace ProjectForCurs.ViewModel.ModelViewModel.PaymentViewModels;

internal class ReadViewModel :
    Notify
{
    private readonly IDbCrud<PaymentMethod> _database = new PaymentMethodDb();
   
    private ObservableCollection<PaymentMethod>? _paymentMethods;

    public ObservableCollection<PaymentMethod> PaymentMethods
    {
        set => SetField(ref _paymentMethods, value);
        get => _paymentMethods ??= _database.GetPaymentMethods();
    }
}