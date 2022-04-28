using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Assignement3.Commands
{

    public class RelayCommand : ICommand
    {
        Action executeMethod;
        Func<bool> canExecuteMethod;
        private Action<object> onOpenLoginDialig;

        public RelayCommand(Action executeMethod)
        {
            this.executeMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public RelayCommand(Action<object> onOpenLoginDialig)
        {
            this.onOpenLoginDialig = onOpenLoginDialig;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (canExecuteMethod != null)
            {
                return canExecuteMethod();
            }
            if (executeMethod != null)
            {
                return true;
            }
            return false;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (executeMethod != null)
            {
                executeMethod();
            }
        }
        #endregion
    }

    public class RelayCommand<T> : ICommand
    {
        Action<T> executeMethod;
        Func<T, bool> canExecuteMethod;
        private Action onCheckBoxCommand;

        public RelayCommand(Action<T> executeMethod)
        {
            this.executeMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public RelayCommand(Action onCheckBoxCommand)
        {
            this.onCheckBoxCommand = onCheckBoxCommand;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (canExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return canExecuteMethod(tparm);
            }
            if (executeMethod != null)
            {
                return true;
            }
            return false;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (executeMethod != null)
            {
                executeMethod((T)parameter);
            }
        }
        #endregion
    }
}
