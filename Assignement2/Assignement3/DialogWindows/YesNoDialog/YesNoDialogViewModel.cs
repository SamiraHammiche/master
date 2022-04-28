using Assignement3.Commands;
using Assignement3.DialogServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Assignement3.DialogWindows.YesNoDialog
{
    public class YesNoDialogViewModel : DialogViewModelBase<string>
    {
        public ICommand YesCommand { get; set; }

        public ICommand NoCommand { get; set; }


        public YesNoDialogViewModel(string title, string message) : base (title, message)
        {
            YesCommand = new RelayCommand<IDialogWindow>(OnYesCommand);

            NoCommand = new RelayCommand<IDialogWindow>(OnNoCommand);
        }

        private void OnNoCommand(IDialogWindow dialogWindow)
        {
            CloseDialogResult(dialogWindow, "No");
        }

        private void OnYesCommand(IDialogWindow dialogResult)
        {
            CloseDialogResult(dialogResult, "Yes");
        }
    }
}
