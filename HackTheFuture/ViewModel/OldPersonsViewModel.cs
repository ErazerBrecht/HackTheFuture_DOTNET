using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace HackTheFuture.ViewModel 
{
    class OldPersonsViewModel : ViewModelBase, IWorkSpace
    {
        private int i = 0;
        private int width = 20;

        public string Header { get; set; }

        public PeopleHackTheFutureEntities Context { get; set; }
        #region Lijst Full property
        private ObservableCollection<People> _lijst;

        public ObservableCollection<People> Lijst
        {
            get
            {
                return _lijst;
            }

            set
            {
                _lijst = value;
                RaisePropertyChanged("Lijst");
            }
        }
        #endregion

        public ICommand NextButton { get; set; }
        public ICommand PreviousButton { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public OldPersonsViewModel()
        {
            Header = "Old Persons";

            NextButton = new RelayCommand(
                () => Next(),
                () => true
            );

            PreviousButton = new RelayCommand(
                () => Previous(),
                () => true
            );

            Context = new PeopleHackTheFutureEntities();
            var data = Context.People.OrderBy(p => p.Id).Skip(i * width).Take(width);
            Lijst = new ObservableCollection<People>(data);
        }

        public void Next()
        {
            i++;
            var data = Context.People.OrderBy(p => p.Id).Skip(i * width).Take(width);
            Lijst = new ObservableCollection<People>(data);
        }

        public void Previous()
        {
            if (i > 0)
            {
                i--;
                var data = Context.People.OrderBy(p => p.Id).Skip(i * width).Take(width);
                Lijst = new ObservableCollection<People>(data);
            }
        }
    }
}
