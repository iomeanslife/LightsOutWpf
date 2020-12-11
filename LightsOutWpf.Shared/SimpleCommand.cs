using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LightsOutWpf.Shared
{
    public class SimpleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Func<Object,bool> CanExecuteDelegate;
        public Action<Object> ExecuteDelegate;

        protected virtual void OnCanExecuteChanged()
        {   
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteDelegate.Invoke(parameter);
        }
    }
}
