namespace ProjectForCurs.ViewModel.ModelViewModel.SubscribeViewModels;

internal abstract class ModelAbstraction :
    AbstractViewModel
{
    public virtual string Name
    {
        set
        {
            if (selectedSubscribe.Name == value)
                return;
            
            selectedSubscribe.Name = value;
            Validate(selectedSubscribe.ValidateName());
        }
        get => selectedSubscribe.Name ?? "";
    }

    public string Description
    {
        set
        {
            if (selectedSubscribe.Description == value)
                return;
            
            selectedSubscribe.Description = value;
            Validate(selectedSubscribe.ValidateDescription());
        }
        get => selectedSubscribe.Description ?? "";
    }

    public int Price
    {
        set
        {
            if (selectedSubscribe.Price == value)
                return;
            
            selectedSubscribe.Price = value;
            Validate(selectedSubscribe.ValidatePrice());
        }
        get => selectedSubscribe.Price;
    }
    
    protected virtual void UpdateAllProperties()
    {
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(Description));
        OnPropertyChanged(nameof(Price));
    }
}