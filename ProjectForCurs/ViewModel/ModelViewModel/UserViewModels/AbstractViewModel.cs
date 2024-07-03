using ProjectForCurs.Model;
using ProjectForCurs.Services.Database;

namespace ProjectForCurs.ViewModel.ModelViewModel.UserViewModels;

internal abstract class AbstractViewModel :
    BaseViewModel
{
    protected readonly IDbCrud<User> database = new UserDb();
    protected User selectedUser = new();
}