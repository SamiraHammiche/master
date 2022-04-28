using Assignement3.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignement3.DialogServices
{
    public interface IDialogService {

        T OpenDialog<T>(DialogViewModelBase<T> viewModel);

    }
}
