using System.Threading.Tasks;
using System.Windows.Input;
using ProjectForCurs.Utilities;

namespace ProjectForCurs.ViewModel.ModelViewModel;

internal abstract class BaseViewModel : 
    Notify
{
    public ICommand Command { protected set; get; }
    
    protected abstract Task CommandFunc();
    protected abstract bool CanExecute();
    
    protected BaseViewModel()
    {
        Command = new AsyncRelayCommand(CommandFunc, CanExecute);
    }
}

