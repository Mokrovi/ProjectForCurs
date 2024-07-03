using System.Threading.Tasks;
using System.Windows;

namespace ProjectForCurs.ViewModel.ModelViewModel.MovieViewModels;

internal class AddViewModel : 
    ModelAbstraction
{
    public AddViewModel() =>
        AllValidate();

    protected override async Task CommandFunc()
    {
        var result = await database.AddAsync(selectedMovie);

        if (result)
        {
            selectedMovie = new();
            UpdateAllProperties();
            MessageBox.Show("Фильм добавлен");
        }
        else
        {
            MessageBox.Show("Фильм не добавлен");
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
        Validate(selectedMovie.ValidateName(), nameof(Name));
        Validate(selectedMovie.ValidateOriginName(), nameof(OriginName));
        Validate(selectedMovie.ValidateDescription(), nameof(Description));
        Validate(selectedMovie.ValidateScore(), nameof(Score));
    }
}