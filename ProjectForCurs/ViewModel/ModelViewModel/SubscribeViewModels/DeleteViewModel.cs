using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.SubscribeViewModels;

internal class DeleteViewModel : 
    AbstractViewModel
{
    private ObservableCollection<Subscribe>? _subscribes;

    public ObservableCollection<Subscribe> Subscribes
    {
        set => SetField(ref _subscribes, value);
        get => _subscribes ??= database.GetSubscribes();
    }
    
    public Subscribe SelectedSubscribe
    {
        set => SetField(ref selectedSubscribe, value);
        get => selectedSubscribe;
    }
    
    protected override async Task CommandFunc()
    {
        var result = await database.DeleteAsync(SelectedSubscribe);

        if (result)
        {
            Subscribes.Remove(SelectedSubscribe);
            SelectedSubscribe = new();
            
            MessageBox.Show("Подписка удалена");
        }
        else
        {
            MessageBox.Show("Подписка не удалена");
        }
    }

    protected override bool CanExecute() =>
        SelectedSubscribe.Id != 0;
}