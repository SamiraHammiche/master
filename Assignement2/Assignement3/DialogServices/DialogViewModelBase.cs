using Assignement3.DialogServices;
using Assignement3.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignement3.DialogServices
{
    public abstract class DialogViewModelBase<T>: ViewModelBase
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public T DialogResult { get; set; }

        public DialogViewModelBase(string title, string message)
        {
            Title = title;
            Message = message;

        }

        public DialogViewModelBase(string title) : this(title, string.Empty) { }


        public DialogViewModelBase() : this(string.Empty, string.Empty) { }

        public void CloseDialogResult(IDialogWindow dialog, T result)
        {
            DialogResult = result;
            if (dialog !=null)
            {
                dialog.DialogResult = true;
            }

        }
    }
}
