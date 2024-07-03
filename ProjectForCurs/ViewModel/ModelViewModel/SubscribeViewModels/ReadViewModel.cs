using System.Collections.ObjectModel;
using ProjectForCurs.Model;
using ProjectForCurs.Services.Database;

namespace ProjectForCurs.ViewModel.ModelViewModel.SubscribeViewModels;

internal class ReadViewModel :
    Notify
{
    private readonly IDbCrud<Subscribe> _database = new SubscribeDb();
    private ObservableCollection<Subscribe>? _subscribes;

    public ObservableCollection<Subscribe> Subscribes
    {
        set => SetField(ref _subscribes, value);
        get => _subscribes ??=  _database.GetSubscribes();
    }
}