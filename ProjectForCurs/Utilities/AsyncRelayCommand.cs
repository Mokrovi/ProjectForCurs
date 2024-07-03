using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectForCurs.Utilities;

public class AsyncRelayCommand : ICommand
{
    private readonly Func<Task> _execute;
    private readonly Func<bool>? _canExecute;

    private bool _isNotExecuting = true;

    public AsyncRelayCommand(Func<Task> execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => 
        _isNotExecuting && (_canExecute == null || _canExecute());

    public async void Execute(object? parameter)
    {
        _isNotExecuting = false;
        
        await _execute();

        _isNotExecuting = true;
    }
}