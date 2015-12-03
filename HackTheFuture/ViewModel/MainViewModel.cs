using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

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
        private int width = 30;
        public PeopleHackTheFutureEntities Context { get; set; }
        public ObservableCollection<People> Lijst { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            using (Context = new PeopleHackTheFutureEntities())
            { 
                var data = Context.People.OrderBy(p => p.Id).Skip(i * width).Take(width);
                Lijst = new ObservableCollection<People>(data);
            }
        }
    }
}