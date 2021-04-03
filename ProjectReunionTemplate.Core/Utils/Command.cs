using System;
using System.Windows.Input;

namespace ProjectReunionTemplate.Core.Utils
{
    public class Command : ICommand
    {
        private readonly Func<bool> _targetCanExecuteMethod;
        private readonly Action _targetExecuteMethod;

        public Command(Action executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public Command(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null) return _targetCanExecuteMethod();

            if (_targetExecuteMethod != null) return true;

            return false;
        }

        public void Execute(object parameter)
        {
            _targetExecuteMethod?.Invoke();
        }
    }

    public class Command<T> : ICommand
    {
        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _execute;

        public Command(Action<T> execute)
            : this(execute, null)
        {
        }

        public Command(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T) parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T) parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}