using System;
using System.Windows.Input;

namespace LAB10_MAUI_AttaxxPlus.ViewModel
{
    
    public abstract class CommandBase : ICommand
    {
#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
        public bool CanExecute(object parameter) => true;
        public abstract void Execute(object parameter);
    }
}