using Assignement2.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Assignement2.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // collections
        private ObservableCollection<string> listA;

        public ObservableCollection<string> ListA
        {
            get { return listA; }
            set { listA = value; }
        }

        private ObservableCollection<string> listB;

        public ObservableCollection<string> ListB
        {
            get { return listB; }
            set { listB = value; }
        }

        // selected items
        private string selectedItemA;

        public string SelectedItemA
        {
            get { return selectedItemA; }
            set
            {
                selectedItemA = value;
                OnPropertyChanged(nameof(SelectedItemA));
            }
        }

        private string selectedItemB;

        public string SelectedItemB
        {
            get { return selectedItemB; }
            set
            { 
                selectedItemB = value;
                OnPropertyChanged(nameof(SelectedItemB));
            }
        }


        // Commands
        public ICommand MoveAToBCommand { get; set; }

        public ICommand MoveBToACommand { get; set; }

        public MainViewModel()
        {
            listA = new ObservableCollection<string>()
            {
                "ItemA1",
                "ItemA2",
                "ItemA3",
                "ItemA4"
            };

            listB = new ObservableCollection<string>()
            {
                "ItemB1",
                "ItemB2",
                "ItemB3",
                "ItemB4"
            };

            // command init
            MoveAToBCommand = new SwitchCommand(this, "A");
            MoveBToACommand = new SwitchCommand(this, "B");
        }

    }
}
