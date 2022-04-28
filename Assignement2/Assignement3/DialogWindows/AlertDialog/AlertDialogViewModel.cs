using Assignement3.Commands;
using Assignement3.DialogServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Assignement3.AlertDialog
{
    public class AlertDialogViewModel : DialogViewModelBase<string>
    {
        public ICommand OKCommand { get; set; }

        public AlertDialogViewModel(string title, string message): base(title, message)
        {
            OKCommand = new RelayCommand<IDialogWindow>(OK);
        }

        private void OK(IDialogWindow dialogWindow)
        {
            CloseDialogResult(dialogWindow, "OK");
        }
    }
}
