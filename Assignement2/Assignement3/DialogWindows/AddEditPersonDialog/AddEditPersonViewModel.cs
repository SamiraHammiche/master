using Assignement3.Commands;
using Assignement3.DialogServices;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
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

            PersonName = person.PersonName;
            AboutInformation = person.AboutInformation;
            SelectedGender = person.Gender;
            DateOfBirth = person.DateOfBirth;
            
        }



        private void OnAddCommand(IDialogWindow dialogWindow)
        {
            PersonViewModel addedPerson = new PersonViewModel();
            addedPerson.PersonName = PersonName;
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
            updatePerson.PersonName = PersonName;
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


     
       

        public override string ToString()
        {
            return base.ToString();
        }

        public interface ITestClass
        {
            string Property { get; set; }
            string Property2 { get; set; }
        }

        public abstract class TestClassBase
        {
            public  string Property { get; set; }

            public string Property2 { get; set; }

            protected static int Double(int number)
            {
                return number + number;
            }

            protected static int square(int number)
            {
                return number * number;
            }
        }

        public class TestClass : TestClassBase, ITestClass
        {
            private int id;

            private TestClass(int id, string property, string property2)
            {
                this.id = id;
                Property = property;
                Property2 = property2;

                try
                {

                }
                catch (Exception e)
                {
                    
                }

                try
                {
                    int number = 4;
                    int cube = square(number) * number;
                    int triple = Double(number) + number;

                }
                finally
                {
                    
                }
            }

            public static TestClass OnCreateInstance(int id, string property, string property2)
            {
                return new TestClass(id, property, property2);
            }

            public string Property { get; set; }
        }

      
        
    }
}
