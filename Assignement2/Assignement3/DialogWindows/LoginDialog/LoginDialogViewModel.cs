using Assignement3.Commands;
using Assignement3.Models;
using Assignement3.DialogServices;
using Assignement3.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Assignement3.DialogWindows.LoginDialog
{
    public class LoginDialogViewModel : DialogViewModelBase<LoginViewModel>
    {

        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
                LoginCommand.RaiseCanExecuteChanged();



            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(password));
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand<IDialogWindow> LoginCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        public LoginDialogViewModel(string title, string message) : base(title, message)
        {
            LoginCommand = new RelayCommand<IDialogWindow>(OnLoginCommand, CanExcecuteLogin);
            ResetCommand = new RelayCommand<IDialogWindow>(OnResetCommand);
            

        }

        private bool CanExcecuteLogin(IDialogWindow arg)
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }

        private void OnLoginCommand(IDialogWindow dialogWindow)
        {
            LoginViewModel userLogin = new LoginViewModel();
            userLogin.UserName = UserName;
            userLogin.Password = Password;

            CloseDialogResult(dialogWindow, userLogin);
        }

        private void OnResetCommand(IDialogWindow dialogWindow)
        {
            UserName = string.Empty;
            Password = string.Empty;
        }
    }
}
