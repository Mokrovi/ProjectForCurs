namespace ProjectForCurs.ViewModel.ModelViewModel.MovieViewModels;

internal abstract class ModelAbstraction :
    AbstractViewModel
{
    public string Name
    {
        set
        {
            if (selectedMovie.Name == value)
                return;

            selectedMovie.Name = value;
            Validate(selectedMovie.ValidateName());
        }
        get => selectedMovie.Name ?? "";
    }

    public string OriginName
    {
        set
        {
            if (selectedMovie.OriginName == value)
                return;

            selectedMovie.OriginName = value;
            Validate(selectedMovie.ValidateOriginName());
        }
        get => selectedMovie.OriginName ?? "";
    }

    public string Description
    {
        set
        {
            if (selectedMovie.Description == value)
                return;

            selectedMovie.Description = value;
            Validate(selectedMovie.ValidateDescription());
        }
        get => selectedMovie.Description ?? "";
    }

    public int Score
    {
        set
        {
            if (selectedMovie.Score == value)
                return;

            selectedMovie.Score = value;
            Validate(selectedMovie.ValidateScore());
        }
        get => selectedMovie.Score;
    }

    public bool IsCanToWatch
    {
        set
        {
            if (selectedMovie.IsCanToWatch == value)
                return;

            selectedMovie.IsCanToWatch = value;
        }
        get => selectedMovie.IsCanToWatch;
    }
    
    protected virtual void UpdateAllProperties()
    {
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(OriginName));
        OnPropertyChanged(nameof(Description));
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(IsCanToWatch));
    }
}