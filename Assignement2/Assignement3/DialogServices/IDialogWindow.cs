using Assignement3.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignement3.DialogServices
{
    public interface IDialogWindow
    {

        bool? DialogResult { get; set;  }

        object DataContext { get; set; }

        bool? ShowDialog();
    }
}
