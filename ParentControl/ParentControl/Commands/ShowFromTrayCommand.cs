using ParentControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ParentControl.Commands
{
    class ShowFromTrayCommand : ICommand
    {
        public void Execute(object parameter)
        {
            ((ConfirmPasswordWindow)parameter).Show();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

    }
}
