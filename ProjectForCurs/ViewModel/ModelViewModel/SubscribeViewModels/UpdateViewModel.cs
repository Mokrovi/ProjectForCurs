using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.SubscribeViewModels;

internal class UpdateViewModel :
    ModelAbstraction
{
    private ObservableCollection<Subscribe>? _subscribes;
    private string _startName = "";

    public ObservableCollection<Subscribe>? Subscribes
    {
        set => SetField(ref _subscribes, value);
        get => _subscribes ??= database.GetSubscribes();
    }

    public Subscribe SelectedSubscribe
    {
        set
        {
            SetField(ref selectedSubscribe, value);

            _startName = value.Name ?? "";

            UpdateAllProperties();
        }
        get => selectedSubscribe;
    }

    public override string Name
    {
        set
        {
            if (selectedSubscribe.Name == value)
                return;

            selectedSubscribe.Name = value;

            if (value != _startName)
                Validate(selectedSubscribe.ValidateName());
            else
                ClearErrors(nameof(Name));
        }
        get => selectedSubscribe.Name ?? "";
    }

    protected override async Task CommandFunc()
    {
        var result = await database.UpdateAsync(selectedSubscribe);

        MessageBox.Show(result ? "Подписка обновлена" : "Подписка не обновлена");
    }

    protected override bool CanExecute() =>
        !HasErrors && selectedSubscribe.Id != 0;
}