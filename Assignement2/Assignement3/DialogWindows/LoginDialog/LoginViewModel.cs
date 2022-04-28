using Assignement3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignement3.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private string  userName;

        public string  UserName
        {
            get { return userName; }
            set 
            { 
                userName = value;
                OnPropertyChanged(nameof(UserName));
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
            }
        }
    }
}
