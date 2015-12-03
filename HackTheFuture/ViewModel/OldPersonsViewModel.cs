using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using HackTheFuture.Model;

namespace HackTheFuture.ViewModel 
{
    class OldPersonsViewModel : ViewModelBase, IWorkSpace
    {
        private int i = 0;
        private int widthShow = 25;
        private int widthCalc = 200;
        private Task _asyncTask;

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

        private List<People> _people = new List<People>();
        private List<Arbeid> _arbeiden = new List<Arbeid>();

        public ICommand NextButton { get; set; }
        public ICommand PreviousButton { get; set; }
        public ICommand SearchJobButton { get; set; }

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

            SearchJobButton = new RelayCommand(
                () => SearchJob(),
                () => true
                );

            _asyncTask = new Task(SearchJobAsync);
            _arbeiden.Add(new Ingenieur());
            _arbeiden.Add(new Kaartenmaker());

            Context = new PeopleHackTheFutureEntities();
            var data = Context.People.OrderBy(p => p.Id).Skip(i*widthShow).Take(widthShow);
            Lijst = new ObservableCollection<People>(data);
        }

        public void Next()
        {
            i++;
            var data = Context.People.OrderBy(p => p.Id).Skip(i * widthShow).Take(widthShow);
            Lijst = new ObservableCollection<People>(data);
        }

        public void Previous()
        {
            if (i > 0)
            {
                i--;
                var data = Context.People.OrderBy(p => p.Id).Skip(i * widthShow).Take(widthShow);
                Lijst = new ObservableCollection<People>(data);
            }
        }

        public void SearchJob()
        {
            if (_asyncTask.Status != TaskStatus.Running)
            {
                _asyncTask.Start();
            }
        }

        async void SearchJobAsync()
        {
            //@ The moment we hardcoded the lenghth of the DB to 1 000 000
            //TODO FIX THIS!!!
            //1 000 000 / 200 = 5000

            for (int l = 0; l < 5000; l++)
            {
                _people = Context.People.OrderBy(p => p.Id).Skip(l * widthCalc).Take(widthCalc).ToList();
                foreach (var p in _people)
                {
                    foreach (var a in _arbeiden)
                    {
                        if (a.Check(p))
                        {
                            Debug.WriteLine(p.FirstName + " is een " + a.Naam);
                            break;
                        }
                    }
                }
            }
        }

    }
}
