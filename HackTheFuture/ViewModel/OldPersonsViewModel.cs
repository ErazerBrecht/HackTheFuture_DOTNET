using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Input;
using HackTheFuture.Model;

namespace HackTheFuture.ViewModel
{
    class OldPersonsViewModel : ViewModelBase, IWorkSpace
    {
        private int i = 0;
        private int widthShow = 25;
        private int widthCalc = 500;
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
        private List<NewPeople> _newPeoples = new List<NewPeople>();
        private readonly List<Arbeid> _arbeiden = new List<Arbeid>();

        public ICommand NextButton { get; set; }
        public ICommand PreviousButton { get; set; }
        public ICommand SearchJobButton { get; set; }

        public OldPersonsViewModel()
        {
            Header = "Old Persons";

            #region Buttons
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
            #endregion

            _asyncTask = new Task(SearchJobAsync);
            _arbeiden.Add(new Ingenieur());
            _arbeiden.Add(new Ordehandhaver());
            _arbeiden.Add(new Elektrisch_ingenieur());
            _arbeiden.Add(new Opvoeder());
            _arbeiden.Add(new Dokter());
            _arbeiden.Add(new Verzorger());
            _arbeiden.Add(new Politieker());
            _arbeiden.Add(new Geoloog());
            _arbeiden.Add(new Kaartenmaker());
            _arbeiden.Add(new Energie());
            _arbeiden.Add(new Geschiedkundige());
            _arbeiden.Add(new GeheimAgent());
            _arbeiden.Add(new VoedingsDeskundige());
            _arbeiden.Add(new AfvalVerwerker());


            Context = new PeopleHackTheFutureEntities();
            var data = Context.People.OrderBy(p => p.Id).Skip(i * widthShow).Take(widthShow);
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
            //1 000 000 / 1000 = 1000

            for (int l = 0; l < 1000; l++)
            {
                _people = Context.People.Take(widthCalc).ToList();
                _newPeoples = new List<NewPeople>();

                foreach (var p in _people)
                {
                    var newP = new NewPeople();
                    newP.Create(p);

                    foreach (var a in _arbeiden)
                    {
                        if (a.Check(newP))
                            break;
                    }

                    _newPeoples.Add(newP);
                }

                Context.People.RemoveRange(_people);
                Context.NewPeople.AddRange(_newPeoples);

                //Why not in foreach above?
                //Otherwise EF will crash!
                //Because it needs to add foreign key to object that don't exist yet
                //By doing this, we're sure the object already exists!
                foreach (var newP in Context.NewPeople)
                {
                    //Check if person has a partner
                    //If not find one
                    if (newP.Partner == null)
                    {
                        foreach (var m in _newPeoples)
                        {
                            if (CalculatePartner(m, newP))
                                break;
                        }
                    }
                }

                //Save to DB
                Context.SaveChanges();

                i = 0;
                var data = Context.People.Take(widthShow);
                Lijst = new ObservableCollection<People>(data);

            }
        }
        private bool CalculatePartner(NewPeople m, NewPeople newP)
        {
            if (m.Sex != newP.Sex)
            {
                if (Math.Abs((m.DateOfBirth - newP.DateOfBirth).TotalDays) <= 6*365)
                {
                    if (m.LastName != newP.LastName)
                    {
                        if (Math.Abs(m.Strength - newP.Strength) >= 1 &&
                            Math.Abs(m.Strength - newP.Strength) <= 3)
                        {
                            if (Math.Abs(m.Perception - newP.Perception) >= 1 &&
                                Math.Abs(m.Perception - newP.Perception) <= 3)
                            {
                                if (Math.Abs(m.Endurance - newP.Endurance) >= 1 &&
                                    Math.Abs(m.Endurance - newP.Endurance) <= 3)
                                {
                                    if (Math.Abs(m.Charisma - newP.Charisma) >= 1 &&
                                        Math.Abs(m.Charisma - newP.Charisma) <= 3)
                                    {
                                        if (Math.Abs(m.Intelligence - newP.Intelligence) >= 1 &&
                                            Math.Abs(m.Intelligence - newP.Intelligence) <= 3)
                                        {
                                            if (Math.Abs(m.Agility - newP.Agility) >= 1 &&
                                                Math.Abs(m.Agility - newP.Agility) <= 3)
                                            {
                                                if (Math.Abs(m.Luck - newP.Luck) >= 1 &&
                                                    Math.Abs(m.Luck - newP.Luck) <= 3)
                                                {
                                                    newP.Partner = m.Id;
                                                    m.Partner = newP.Id;
                                                    Debug.WriteLine(newP.FirstName + " " + newP.LastName + " has a relation with " + m.FirstName + " " + m.LastName);
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
