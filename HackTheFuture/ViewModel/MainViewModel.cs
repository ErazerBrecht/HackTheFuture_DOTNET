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
        private IWorkSpace _selectedWorkspace;
        public IWorkSpace SelectedWorkspace
        {
            get
            {
                return _selectedWorkspace;
            }
            set
            {
                _selectedWorkspace = value;
            }
        }

        public ObservableCollection<IWorkSpace> Workspaces { get; }

        public MainViewModel()
        {
            Workspaces = new ObservableCollection<IWorkSpace>();
            Workspaces.Add(new OldPersonsViewModel());
            SelectedWorkspace = Workspaces.First();
        }
    }
}