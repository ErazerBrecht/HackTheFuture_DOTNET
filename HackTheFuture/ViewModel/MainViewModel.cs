using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace HackTheFuture.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private int i = 0;
        private int width = 20;
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
        public MainViewModel()
        {
            NextButton = new RelayCommand(
                () => Next(),
                () => true
            );

            PreviousButton = new RelayCommand(
                () => Previous(),
                () => true
            );

            Context = new PeopleHackTheFutureEntities();
            //var data = Context.People.OrderBy(p => p.Id).Skip(i * width).Take(width);
            var data = Context.People.OrderBy(p => p.Id).Where(p => p.Agility == 3);
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
                var data = Context.People.OrderBy(p => p.Id).Skip(i*width).Take(width);
                Lijst = new ObservableCollection<People>(data);
            }
        }
    }
}