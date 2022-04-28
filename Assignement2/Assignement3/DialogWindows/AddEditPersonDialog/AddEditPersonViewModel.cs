using Assignement3.Commands;
using Assignement3.DialogServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Assignement3.ViewModels
{
    public class AddEditPersonViewModel : DialogViewModelBase<PersonViewModel>
    {

        private string personName;

        public string PersonName
        {
            get { return personName; }
            set
            {
                personName = value;
                OnPropertyChanged(nameof(PersonName));
                AddPersonCommand.RaiseCanExecuteChanged();
            }
        }

        private string aboutInformation;
        public string AboutInformation
        {
            get { return aboutInformation; }
            set
            {
                aboutInformation = value;
                OnPropertyChanged(nameof(AboutInformation));
                AddPersonCommand.RaiseCanExecuteChanged();
            }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
                AddPersonCommand.RaiseCanExecuteChanged();
            }
        }

        private string selectedGender;
        public string SelectedGender
        {
            get { return selectedGender; }
            set
            {
                selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
                AddPersonCommand.RaiseCanExecuteChanged();
            }
        }


        public RelayCommand<IDialogWindow> AddPersonCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        private ObservableCollection<string> genderList;
        public ObservableCollection<string> GenderList
        {
            get { return genderList; }
            set
            {
                genderList = value;
                OnPropertyChanged(nameof(GenderList));
            }
        }

        public AddEditPersonViewModel(string title, string message) : base(title, message)
        {
            GenderList = new ObservableCollection<string>()
            {
                "Male",
                "Female"
            };

            AddPersonCommand = new RelayCommand<IDialogWindow>(OnAddCommand, CanAddCommand);
            ResetCommand = new RelayCommand<IDialogWindow>(OnResetCommand);
            DateOfBirth = DateTime.Today;
        }

        public AddEditPersonViewModel(PersonViewModel person, string title, string message) : base(title, message)
        {
            AddPersonCommand = new RelayCommand<IDialogWindow>(OnEditCommand, CanAddCommand);
            ResetCommand = new RelayCommand<IDialogWindow>(OnResetCommand);

            GenderList = new ObservableCollection<string>()
            {
                "Male",
                "Female"
            };

            PersonName = person.PersoneName;
            AboutInformation = person.AboutInformation;
            SelectedGender = person.Gender;
            DateOfBirth = person.DateOfBirth;
            
        }



        private void OnAddCommand(IDialogWindow dialogWindow)
        {
            PersonViewModel addedPerson = new PersonViewModel();
            addedPerson.PersoneName = PersonName;
            addedPerson.Gender = SelectedGender;
            addedPerson.AboutInformation = AboutInformation;
            addedPerson.DateOfBirth = DateOfBirth;
            addedPerson.IsSelected = false;

            CloseDialogResult(dialogWindow, addedPerson);

        }

        private bool CanAddCommand(IDialogWindow dialogWindow)
        {
            return !string.IsNullOrEmpty(PersonName) && !string.IsNullOrEmpty(AboutInformation)
                   && !string.IsNullOrEmpty(SelectedGender) && !DateOfBirth.Date.Equals(DateTime.Today);
        }


        private void OnEditCommand(IDialogWindow dialogWindow)
        {
            PersonViewModel updatePerson = new PersonViewModel();
            updatePerson.PersoneName = PersonName;
            updatePerson.Gender = SelectedGender;
            updatePerson.AboutInformation = AboutInformation;
            updatePerson.DateOfBirth = DateOfBirth;
            updatePerson.IsSelected = false;

            CloseDialogResult(dialogWindow, updatePerson);

        }

        private void OnResetCommand(IDialogWindow obj)
        {
            PersonName = string.Empty;
            SelectedGender = null;
            AboutInformation = string.Empty;
            DateOfBirth = DateTime.Today;
        }
    }
}
