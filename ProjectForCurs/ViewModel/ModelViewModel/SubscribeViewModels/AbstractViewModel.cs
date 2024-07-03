using ProjectForCurs.Model;
using ProjectForCurs.Services.Database;

namespace ProjectForCurs.ViewModel.ModelViewModel.SubscribeViewModels;

internal abstract class AbstractViewModel : 
    BaseViewModel
{
    protected readonly IDbCrud<Subscribe> database = new SubscribeDb();
    protected Subscribe selectedSubscribe = new();
}