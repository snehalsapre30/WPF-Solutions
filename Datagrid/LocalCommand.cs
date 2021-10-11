using System;
using System.Windows.Input;

namespace GitSpecificApp
{
    /// <summary>
    /// 
    /// </summary>
    public class LocalCommand : ICommand
    {
        Action<object> _execute;
        Func<object, bool> _canExecute;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public LocalCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Can execute method
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// CanExecuteChanged event
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Execute implementation.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

}
