using Assignement3.AlertDialog;
using Assignement3.Commands;
using Assignement3.DialogWindows.LoginDialog;
using Assignement3.DialogWindows.YesNoDialog;
using Assignement3.DialogServices;
using System;
using System.Windows.Threading;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Assignement3.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // properties

        private LoginViewModel loginViewModel = new LoginViewModel();

        private PersonListViewModel personListViewModel;

        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        // Services
        private IDialogService dialogService;

        // Commands
        public RelayCommand OpenLoginDialogCommand { get; private set; }

        public RelayCommand OpenAlertDialogCommand { get; private set; }

        public RelayCommand OpenYesNoDialogCommand { get; private set; }

        public RelayCommand OpenModalLoginDialogCommand { get; set; }

       

        private void OnOpenLoginDialiog()
        {
            CurrentViewModel = loginViewModel;
            
        }
        private void OnOpenAlertDialog()
        {
            var alertDialog = new AlertDialogViewModel("Alert Title", "This is an alert");
            var result = dialogService.OpenDialog(alertDialog);

            // should return OK
            var dialogResult = result;

        }

        private void OnOpenYesNoDialog()
        {
            var yesNoDialog = new YesNoDialogViewModel("Yes No Dialog", "This is a dialog with Yes, No buttons");
            var result = dialogService.OpenDialog(yesNoDialog);

            // should return Yes or No
            var dialogResult = result;
        }

        private void OnOpenModalLoginDialog()
        {
            var modalDialog = new LoginDialogViewModel("Modal Login", string.Empty);
            var result = dialogService.OpenDialog(modalDialog);

            // should return LoginViewModel
            var loggedUser = result;
            if (loggedUser !=null)
            {
                personListViewModel = new PersonListViewModel(loggedUser.UserName);

                CurrentViewModel = personListViewModel;
            }
           
        }

        // Constructor
        public MainWindowViewModel()
        {
            dialogService = new DialogService();
            OpenLoginDialogCommand = new RelayCommand(OnOpenLoginDialiog);
            OpenAlertDialogCommand = new RelayCommand(OnOpenAlertDialog);
            OpenYesNoDialogCommand = new RelayCommand(OnOpenYesNoDialog);
            OpenModalLoginDialogCommand = new RelayCommand(OnOpenModalLoginDialog);
        }

        
    }
}
