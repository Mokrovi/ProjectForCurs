using System;
using ProjectForCurs.Model;

namespace ProjectForCurs.ViewModel.ModelViewModel.PaymentViewModels;

internal abstract class ModelAbstraction :
    AbstractViewModel
{
    public string NumberOfCard
    {
        set
        {
            if (selectedPaymentMethod.NumberOfCard == value)
                return;
            
            selectedPaymentMethod.NumberOfCard = value;
            Validate(selectedPaymentMethod.ValidateNumberOfCard());
        }
        get => selectedPaymentMethod.NumberOfCard ?? "";
    }

    public string TheHoldersName
    {
        set
        {
            if (selectedPaymentMethod.TheHoldersName == value)
                return;
            
            selectedPaymentMethod.TheHoldersName = value;
            Validate(selectedPaymentMethod.ValidateTheHoldersName());
        }
        get => selectedPaymentMethod.TheHoldersName ?? "";
    }

    public string Cvc
    {
        set
        {
            if (selectedPaymentMethod.Cvc == value)
                return;
            
            selectedPaymentMethod.Cvc = value;
            Validate(selectedPaymentMethod.ValidateCvc());
        }
        get => selectedPaymentMethod.Cvc ?? "";
    }

    public DateTime DeadLine
    {
        set
        {
            var dateOnlyValue = DateOnly.FromDateTime(value);
            
            if (selectedPaymentMethod.DeadLine == dateOnlyValue)
                return;
            
            selectedPaymentMethod.DeadLine = dateOnlyValue;
            Validate(selectedPaymentMethod.ValidateDeadLine());
        }
        get => selectedPaymentMethod.DeadLine.ToDateTime(TimeOnly.MinValue);
    }

    public User User
    {
        set
        {
            if (selectedPaymentMethod.User == value)
                return;
            
            selectedPaymentMethod.User = value;
        }
        get => selectedPaymentMethod.User; 
    }
    
    protected virtual void UpdateAllProperties()
    {
        OnPropertyChanged(nameof(NumberOfCard));
        OnPropertyChanged(nameof(TheHoldersName));
        OnPropertyChanged(nameof(Cvc));
        OnPropertyChanged(nameof(DeadLine));
        OnPropertyChanged(nameof(User));
    }
}