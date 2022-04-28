using Assignement2.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignement2.Commands
{
    public class SwitchCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (origin.Equals("A"))
            {
                mainViewModel.ListB.Add(mainViewModel.SelectedItemA);
                mainViewModel.ListA.Remove(mainViewModel.SelectedItemA);
                mainViewModel.SelectedItemA = null;
            }
            else
            {
                if (origin.Equals("B"))
                {
                    mainViewModel.ListA.Add(mainViewModel.SelectedItemB);
                    mainViewModel.ListB.Remove(mainViewModel.SelectedItemB);
                    mainViewModel.SelectedItemB = null;
                }
            }
        }

        public override bool CanExecute(object parameter)
        {
            bool canExecute = false;
            if (origin.Equals("A"))
            {
                canExecute = mainViewModel.SelectedItemA != null;
            }
            else
            {
                if (origin.Equals("B"))
                {
                    canExecute = mainViewModel.SelectedItemB != null;
                }
            }

            return canExecute && base.CanExecute(parameter);
        }
            



        private readonly MainViewModel mainViewModel;
        private readonly string origin;
        public SwitchCommand(MainViewModel mainViewModel, string origin)
        {
            this.mainViewModel = mainViewModel;
            this.origin = origin;
            this.mainViewModel.PropertyChanged += MainViewModel_PropertyChanged;

        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainViewModel.SelectedItemB) || e.PropertyName==nameof(MainViewModel.SelectedItemA))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
