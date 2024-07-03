using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ProjectForCurs.ViewModel;

internal abstract class Notify :
    INotifyPropertyChanged, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _errors = new();

    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    
    public bool HasErrors => 
        _errors.Count > 0;
    
    public IEnumerable GetErrors(string? propertyName) =>
        (_errors.ContainsKey(propertyName ?? "") ? _errors[propertyName ?? ""] : null)!;
    

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;

        field = value;
        OnPropertyChanged(propertyName);
        CommandManager.InvalidateRequerySuggested();

        return true;
    }
    
    protected delegate List<string> ValidateFunc();
    
    protected void Validate(List<string> errors, [CallerMemberName] string propertyName = "")
    {
        ClearErrors(propertyName);

        foreach (var error in errors)
        {
            AddError(propertyName, error);
        }
    }

    protected void ClearErrors(string propertyName)
    {
        if (!_errors.ContainsKey(propertyName)) return;
    
        _errors.Remove(propertyName);
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
    
    private void AddError(string propertyName, string error)
    {
        if (!_errors.ContainsKey(propertyName))
        {
            _errors[propertyName] = new List<string>();
        }
        
        
        _errors[propertyName].Add(error);
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}
