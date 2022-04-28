using Assignement3.Commands;
using Assignement3.DialogServices;
using Assignement3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;
using System.Linq;

namespace Assignement3.ViewModels
{
    public class PersonListViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private string currentDate;
        public string CurrentDate
        {
            get { return currentDate; }
            set
            {
                currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));

            }
        }

        private string currentTime;
        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        // Dispatcher time
        public int TotalSeconds { get; set; }
        private readonly DispatcherTimer dispatcherTimer = null;


        private string timerText;
        public string TimerText
        {
            get
            {
                return timerText;
            }
            set
            {
                this.timerText = value;
                OnPropertyChanged(nameof(TimerText));
            }
        }

        private string loggedUserName;
        public string LoggedUserName
        {
            get
            {
                return loggedUserName;
            }
            set
            {
                this.loggedUserName = value;
                OnPropertyChanged(nameof(LoggedUserName));
            }
        }

        private PersonViewModel selectedPerson;
        public PersonViewModel SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                this.selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
                
            }
        }

        
        // Person list
        private ObservableCollection<PersonViewModel> personList;
        public ObservableCollection<PersonViewModel> PersonList
        {
            get
            {
                return personList;
            }
            set
            {
                this.personList = value;
                OnPropertyChanged(nameof(PersonList));
            }
        }

        // Commands section
        public RelayCommand OpenAddPersonCommand { get; set; }
        public RelayCommand<PersonViewModel> CheckBoxCommand { get; set; }


        public RelayCommand<PersonViewModel> EditSelectedPerson { get; set; }

        public RelayCommand<PersonViewModel> DeleteSelectedPerson { get; set; }

        private void OnAddPersonDialog()
        {
            var modalDialog = new AddEditPersonViewModel("Add a new person", string.Empty);
            var result = dialogService.OpenDialog(modalDialog);

            // should return PersonViewModel
            PersonViewModel addedPerson = result;
            PersonList.Add(addedPerson);
        }

        private bool CanEditDeletePerson(PersonViewModel arg)
        {
            return SelectedPerson != null && SelectedPerson.IsSelected;
        }

        private void OnDeletePerson(PersonViewModel person)
        {
            var personToDelete = PersonList.First(x => x.PersoneName.Equals(person.PersoneName));
            PersonList.Remove(person);
        }

        private void OnEditPerson(PersonViewModel person)
        {
            //var personToUpdate = PersonList.First(x => x.PersoneName.Equals(person.PersoneName));
            var modalDialog = new AddEditPersonViewModel(person, "Edit a person", string.Empty);
            var result = dialogService.OpenDialog(modalDialog);

            // should return PersonViewModel
            PersonViewModel updateddPerson = result;

            var existingPerson = PersonList.First(x => x.PersoneName.Equals(person.PersoneName));
            existingPerson.PersoneName = updateddPerson.PersoneName;
            existingPerson.AboutInformation = updateddPerson.AboutInformation;
            existingPerson.DateOfBirth = updateddPerson.DateOfBirth;
            existingPerson.Gender = updateddPerson.Gender;
            
        }

        private void OnCheckBoxCommand(PersonViewModel selectedPerson)
        {
            if (selectedPerson.IsSelected)
            {
                foreach (var person in PersonList)
                {
                    if (!person.PersoneName.Equals(selectedPerson.PersoneName))
                    {
                        person.IsSelected = false;
                    }
                }
            }
            SelectedPerson = selectedPerson;
            EditSelectedPerson.RaiseCanExecuteChanged();
            DeleteSelectedPerson.RaiseCanExecuteChanged();
        }


        // Constructor
        public PersonListViewModel(string loggedUser)
        {
            LoggedUserName = loggedUser;
            dialogService = new DialogService();
            CurrentDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
            CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");


            OpenAddPersonCommand = new RelayCommand(OnAddPersonDialog);
            CheckBoxCommand = new RelayCommand<PersonViewModel>(OnCheckBoxCommand);
            EditSelectedPerson = new RelayCommand<PersonViewModel>(OnEditPerson, CanEditDeletePerson);
            DeleteSelectedPerson = new RelayCommand<PersonViewModel>(OnDeletePerson, CanEditDeletePerson);

            // Dispatcher section
            dispatcherTimer = new DispatcherTimer();
            TotalSeconds = 0;
            dispatcherTimer.Tick += new EventHandler(DispatcherTimerTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            // person list
            PersonList = new ObservableCollection<PersonViewModel>();
        }

        





        // event management
        private void DispatcherTimerTick(object sender, EventArgs e)
        {
            TotalSeconds += 1;
            TimerText = string.Format("{0:hh\\:mm\\:ss}", TimeSpan.FromSeconds(TotalSeconds).Duration());
            CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
