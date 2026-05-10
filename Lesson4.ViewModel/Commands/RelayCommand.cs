using System.Windows.Input;

namespace Lesson4.ViewModel.Commands;

public class RelayCommand(CancelCommand cancelCommand, Action<Action> changeStateView, Action<object?> execute) : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private bool _isCanExecute = true;
    public bool IsCanExecute 
    {
        get => _isCanExecute;
        set
        {
            _isCanExecute = value;
            changeStateView.Invoke(() => CanExecuteChanged?.Invoke(this, EventArgs.Empty));
        }
    }

    public bool CanExecute(object? parameter)
    {
        return IsCanExecute;
    }

    public void Execute(object? parameter)
    {
        IsCanExecute = false;
        cancelCommand.IsCanExecute = true;

        execute.Invoke(parameter);
    }
}
