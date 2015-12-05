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
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;

namespace HackTheFuture.ViewModel
{
    class OldPersonsViewModel : ViewModelBase, IWorkSpace
    {
        private int _i = 0;
        private double count = 0.0;
        private const int WidthShow = 25;
        private const int WidthCalc = 2000;
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
            count = Context.People.Count();
            var data = Context.People.OrderBy(p => p.Id).Skip(_i * WidthShow).Take(WidthShow);
            Lijst = new ObservableCollection<People>(data);
        }

        public void Next()
        {
            if (_i < Math.Ceiling(count / WidthShow))
            {
                _i++;
                var data = Context.People.OrderBy(p => p.Id).Skip(_i * WidthShow).Take(WidthShow);
                Lijst = new ObservableCollection<People>(data); 
            }
        }

        public void Previous()
        {
            if (_i > 0)
            {
                _i--;
                var data = Context.People.OrderBy(p => p.Id).Skip(_i * WidthShow).Take(WidthShow);
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
            //Context.Configuration.AutoDetectChangesEnabled = false;

            //Calculate how many times we have to execute our for loop
            int max = Convert.ToInt32(Math.Ceiling(count/WidthCalc));
            for (int l = 0; l < max; l++)
            {
                _people = Context.People.Take(WidthCalc).ToList();
                _newPeoples = new List<NewPeople>();

                foreach (var p in _people)
                {
                    var add = new NewPeople();
                    add.Create(p);
                    _newPeoples.Add(add);
                }

                for(int j = 0; j < _newPeoples.Count; j++)
                {
                    var newP = _newPeoples.ElementAt(j);

                    foreach (var a in _arbeiden)
                    {
                        if (a.Check(newP))
                            break;
                    }

                    //Check if person has a partner
                    //If not find one
                    if (newP.Partner == null)
                    {
                        for (int k = j + 1; k < _newPeoples.Count; k++)
                        {
                            var m = _newPeoples.ElementAt(k);
                            if (CalculatePartner(m, newP))
                                break;
                        }
                    }
                }

                //Context.People.RemoveRange(_people);
                Context.People.Take(WidthCalc).Delete();
                //Context.NewPeople.AddRange(_newPeoples);
                Context.BulkInsert(_newPeoples);

                //Save to DB
                Context.SaveChanges();

                //Update DataGrid
                _i = 0;
                var data = Context.People.Take(WidthShow);
                Lijst = new ObservableCollection<People>(data);
            }
        }

        private bool CalculatePartner(NewPeople m, NewPeople newP)
        {
            if (m.Partner == null)
            {
                if (m.Sex != newP.Sex)
                {
                    if (Math.Abs((m.DateOfBirth - newP.DateOfBirth).TotalDays) <= 6 * 365)
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
            }

            return false;
        }
    }
}
