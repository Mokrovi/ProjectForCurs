using System.Collections.ObjectModel;
using ProjectForCurs.Model;
using ProjectForCurs.Services.Database;

namespace ProjectForCurs.ViewModel.ModelViewModel.PaymentViewModels;

internal abstract class AbstractViewModel :
    BaseViewModel
{
    private ObservableCollection<User>? _users;

    protected readonly IDbCrud<PaymentMethod> database = new PaymentMethodDb();
    protected PaymentMethod selectedPaymentMethod = new();
    
    public ObservableCollection<User> Users
    {
        set => SetField(ref _users, value);
        get => _users ??= database.GetUsers();
    }
}