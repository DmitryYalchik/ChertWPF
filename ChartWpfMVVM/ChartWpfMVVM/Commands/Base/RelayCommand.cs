using System.Windows.Input;

namespace ChartWpfMVVM.Commands.Base
{
    public abstract class RelayCommand : ICommand
    {
        event EventHandler? ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested += value;
        }

        bool ICommand.CanExecute(object? parameter) => CanExecute(parameter);

        void ICommand.Execute(object? parameter)
        {
            if (((ICommand)this).CanExecute(parameter))
                Execute(parameter);
        }

        protected virtual bool CanExecute(object? p) => true;

        protected abstract void Execute(object? parameter);
    }
}
