using System.Threading.Tasks;
using System.Windows;

namespace ProjectForCurs.ViewModel.ModelViewModel.SubscribeViewModels;

internal class AddViewModel :
    ModelAbstraction
{
    public AddViewModel() =>
        AllValidate();
    

    protected override async Task CommandFunc()
    {
        var result = await database.AddAsync(selectedSubscribe);

        if (result)
        {
            selectedSubscribe = new();
            UpdateAllProperties();

            MessageBox.Show("Подписка добавлена");
        }
        else
        {
            MessageBox.Show("Подписка не добавлена");
        }
    }

    protected override bool CanExecute() =>
        !HasErrors;

    protected override void UpdateAllProperties()
    {
        base.UpdateAllProperties();
        
        AllValidate();
    }

    private void AllValidate()
    {
        Validate(selectedSubscribe.ValidateName(), nameof(Name));
        Validate(selectedSubscribe.ValidateDescription(), nameof(Description));
        Validate(selectedSubscribe.ValidatePrice(), nameof(Price));
    }
}