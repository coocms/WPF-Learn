using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Learn.Command
{
    internal class ButtonCommand : ICommand
    {
        Action action;
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action();
        }
        public ButtonCommand(Action action)
        {
            this.action = action;
        }


    }
}
