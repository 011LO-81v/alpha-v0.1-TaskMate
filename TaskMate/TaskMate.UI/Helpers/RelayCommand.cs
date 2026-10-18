using System;
using System.Windows.Input;

namespace TaskMate.UI.Helpers
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executeWithParam;
        private readonly Predicate<object> _canExecuteWithParam;
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        // Constructor sin parámetro
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Constructor con parámetro
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _executeWithParam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithParam = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_execute != null) return _canExecute == null || _canExecute();
            return _canExecuteWithParam == null || _canExecuteWithParam(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute != null) _execute();
            else _executeWithParam?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Método auxiliar para forzar reevaluación
        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
    }
}
