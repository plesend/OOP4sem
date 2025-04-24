using System.Windows.Input;
using System;

public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute ?? (_ => true);  // Если canExecute не передан, всегда возвращаем true
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute(parameter);
    }

    // Метод Execute выполняет команду
    public void Execute(object parameter)
    {
        _execute(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}