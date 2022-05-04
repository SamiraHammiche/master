using System;

namespace Assignement3.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {

        private string personName;

        public string PersonName
        {
            get { return personName; }
            set
            {
                personName = value;
                OnPropertyChanged(nameof(PersonName));
            }
        }

        private string about;

        public string AboutInformation
        {
            get { return about; }
            set
            {
                about = value;
                OnPropertyChanged(nameof(AboutInformation));
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
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }


        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
